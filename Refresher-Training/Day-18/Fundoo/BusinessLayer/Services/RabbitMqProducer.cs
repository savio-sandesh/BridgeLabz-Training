using System.Text;
using System.Text.Json;
using BusinessLayer.Interfaces;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace BusinessLayer.Services
{
    public class RabbitMqProducer : IRabbitMqProducer
    {
        private readonly IConfiguration _configuration;

        public RabbitMqProducer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMessageAsync<T>(T message, string queueName)
        {
            var uriString = _configuration["RabbitMQ:Uri"];
            if (string.IsNullOrEmpty(uriString))
            {
                throw new InvalidOperationException("RabbitMQ URI is missing in configuration.");
            }

            var factory = new ConnectionFactory
            {
                Uri = new Uri(uriString)
            };

            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(
                queue: queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            var properties = new BasicProperties
            {
                DeliveryMode = DeliveryModes.Persistent
            };

            await channel.BasicPublishAsync(
                exchange: string.Empty,
                routingKey: queueName,
                mandatory: false,
                basicProperties: properties,
                body: body
            );
        }
    }
}