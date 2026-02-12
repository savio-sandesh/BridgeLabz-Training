using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace NotifyHub
{
    public static class NotificationValidator
    {
        public static ValidationResultModel Validate(Notification notification)
        {
            var context = new ValidationContext(notification);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(notification, context, results, true);

            return new ValidationResultModel
            {
                IsValid = isValid,
                ErrorMessage = isValid ? null : results.First().ErrorMessage
            };
        }
    }

    public class ValidationResultModel
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
    }
}
