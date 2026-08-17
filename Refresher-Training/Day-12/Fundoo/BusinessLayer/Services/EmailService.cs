using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace BusinessLayer.Services
{
    public interface IEmailService
    {
        Task SendPasswordResetEmailAsync(string toEmail, string resetToken);
    }

    // Demonstrates HttpClient usage for consuming an external API (Day 12 topic).
    // Swap the base address / endpoint for a real provider (SendGrid, Mailgun, etc.) later.
    public class EmailService : IEmailService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<EmailService> _logger;

        public EmailService(HttpClient httpClient, ILogger<EmailService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task SendPasswordResetEmailAsync(string toEmail, string resetToken)
        {
            try
            {
                var payload = new
                {
                    to = toEmail,
                    subject = "Fundoo Notes - Password Reset",
                    body = $"Your password reset token is: {resetToken}"
                };

                var response = await _httpClient.PostAsJsonAsync("send", payload);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("Email provider returned {StatusCode} for {Email}", response.StatusCode, toEmail);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send password reset email to {Email}", toEmail);
            }
        }
    }
}
