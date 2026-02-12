using NotifyHub.Senders;

namespace NotifyHub
{
    public static class NotificationSenderFactory
    {
        public static INotificationSender Create(NotificationType type)
        {
            return type switch
            {
                NotificationType.Email => new EmailSender(),
                NotificationType.Sms => new SmsSender(),
                NotificationType.AppAlert => new AppAlertSender(),
                _ => throw new System.ArgumentException("Invalid type")
            };
        }
    }
}
