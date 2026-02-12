using System;
using System.ComponentModel.DataAnnotations;

namespace NotifyHub
{
    public class Notification
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [NotificationRecipient]
        public string Recipient { get; set; }


        [Required]
        public string Message { get; set; }

        public NotificationPriority Priority { get; set; }
        public NotificationType Type { get; set; }

        public DateTime CreatedTime { get; set; }

        public NotificationStatus Status { get; set; }
    }

    public enum NotificationPriority
    {
        High = 1,
        Medium = 2,
        Low = 3
    }

    public enum NotificationType
    {
        Email = 1,
        Sms = 2,
        AppAlert = 3
    }

    public enum NotificationStatus
    {
        Pending,
        Processing,
        Sent,
        Failed
    }
}
