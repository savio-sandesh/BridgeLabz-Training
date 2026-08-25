using System.Text;
using System.Text.Json;
using BusinessLayer.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelLayer.DTOs;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Fundoo.BackgroundServices
{
    public class ReminderNotificationConsumer : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ReminderNotificationConsumer> _logger;
        private readonly IServiceProvider _serviceProvider;
        private const string QueueName = "reminder_notifications_queue";

        public ReminderNotificationConsumer(
            IConfiguration configuration,
            ILogger<ReminderNotificationConsumer> logger,
            IServiceProvider serviceProvider)
        {
            _configuration = configuration;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var uriString = _configuration["RabbitMQ:Uri"];
            if (string.IsNullOrEmpty(uriString))
            {
                _logger.LogWarning("RabbitMQ URI not found. Background consumer skipped.");
                return;
            }

            var factory = new ConnectionFactory
            {
                Uri = new Uri(uriString)
            };

            var connection = await factory.CreateConnectionAsync(stoppingToken);
            var channel = await connection.CreateChannelAsync(cancellationToken: stoppingToken);

            await channel.QueueDeclareAsync(
                queue: QueueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null,
                cancellationToken: stoppingToken
            );

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var json = Encoding.UTF8.GetString(body);

                try
                {
                    var message = JsonSerializer.Deserialize<ReminderNotificationMessage>(json);
                    if (message != null)
                    {
                        _logger.LogInformation(
                            " [RabbitMQ Consumer] Processing reminder for Note '{Title}' (User: {Email}) scheduled for {Time}",
                            message.NoteTitle, message.Email, message.ReminderTime
                        );

                        // Asynchronous SMTP Notification
                        using var scope = _serviceProvider.CreateScope();
                        var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

                        string subject = $"Reminder: {message.NoteTitle}";
                        string bodyContent = $"<p>Hello,</p><p>This is your reminder for: <strong>{message.NoteTitle}</strong> scheduled for <strong>{message.ReminderTime:g}</strong>.</p>";

                        await emailService.SendEmailAsync(message.Email, subject, bodyContent);
                    }

                    await channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to process RabbitMQ reminder message.");
                    await channel.BasicNackAsync(deliveryTag: ea.DeliveryTag, multiple: false, requeue: true);
                }
            };

            await channel.BasicConsumeAsync(
                queue: QueueName,
                autoAck: false,
                consumer: consumer,
                cancellationToken: stoppingToken
            );

            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
    }
}