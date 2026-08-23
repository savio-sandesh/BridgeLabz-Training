using BusinessLayer.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace BusinessLayer.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task SendPasswordResetEmailAsync(string toEmail, string resetToken)
        {
            try
            {
                var server = _configuration["SmtpSettings:Server"] ?? "smtp.gmail.com";
                var port = int.Parse(_configuration["SmtpSettings:Port"] ?? "587");
                var senderEmail = _configuration["SmtpSettings:SenderEmail"] ?? throw new InvalidOperationException("SmtpSettings:SenderEmail is not configured");
                var senderName = _configuration["SmtpSettings:SenderName"] ?? "Fundoo Support";
                var password = _configuration["SmtpSettings:Password"] ?? throw new InvalidOperationException("SmtpSettings:Password is not configured");

                var email = new MimeMessage();
                email.From.Add(new MailboxAddress(senderName, senderEmail));
                email.To.Add(MailboxAddress.Parse(toEmail));
                email.Subject = "Fundoo Notes - Password Reset";

                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = $@"
                        <div style='font-family: Arial, sans-serif; padding: 20px; color: #333;'>
                            <h2>Fundoo Notes Password Reset</h2>
                            <p>You requested a password reset. Use the token below to reset your password:</p>
                            <div style='background: #f4f4f4; padding: 12px 18px; border-radius: 6px; font-weight: bold; font-size: 18px; display: inline-block; letter-spacing: 1px; color: #007bff;'>
                                {resetToken}
                            </div>
                            <p style='margin-top: 20px; font-size: 13px; color: #777;'>If you did not request this, please ignore this email.</p>
                        </div>"
                };

                email.Body = bodyBuilder.ToMessageBody();

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(server, port, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(senderEmail, password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

                _logger.LogInformation("Password reset email sent successfully to {Email}", toEmail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send password reset email to {Email}", toEmail);
                throw;
            }
        }
    }
}