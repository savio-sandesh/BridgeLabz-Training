namespace NotifyHub
{
    public interface INotificationService
    {
        void AddNotification(Notification notification);
        void StartProcessing();
        void StopProcessing();
        void DisplayAll();
    }
}
