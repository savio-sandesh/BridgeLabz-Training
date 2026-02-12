using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace NotifyHub
{
    public class NotificationRecipientAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var notification = (Notification)validationContext.ObjectInstance;
            var recipient = value as string;

            if (string.IsNullOrWhiteSpace(recipient))
                return new ValidationResult("Recipient is required.");

            return notification.Type switch
            {
                NotificationType.Email =>
                    IsValidEmail(recipient)
                        ? ValidationResult.Success!
                        : new ValidationResult("Invalid email format."),

                NotificationType.Sms =>
                    IsValidPhone(recipient)
                        ? ValidationResult.Success!
                        : new ValidationResult("Invalid phone number format (10 digits required)."),

                NotificationType.AppAlert =>
                    IsValidAppAlert(recipient)
                        ? ValidationResult.Success!
                        : new ValidationResult("AppAlert recipient must end with '.appalert'."),

                _ => new ValidationResult("Invalid notification type.")
            };
        }

        private bool IsValidEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }

        private bool IsValidPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^\d{10}$");
        }

        private bool IsValidAppAlert(string recipient)
        {
            return recipient.EndsWith(".appalert", StringComparison.OrdinalIgnoreCase);
        }
    }
}
