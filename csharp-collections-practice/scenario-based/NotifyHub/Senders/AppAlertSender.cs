using System;
using NotifyHub.Senders;

using System.Threading.Tasks;

namespace NotifyHub.Senders
{
    public class AppAlertSender : INotificationSender
    {
        public async Task SendAsync(Notification notification)
        {
            await Task.Delay(500);
            Console.WriteLine($"App alert sent to {notification.Recipient}");
        }
    }
}
