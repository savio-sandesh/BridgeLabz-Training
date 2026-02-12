using System;
using NotifyHub.Senders;

using System.Threading.Tasks;

namespace NotifyHub.Senders
{
    public class EmailSender : INotificationSender
    {
        public async Task SendAsync(Notification notification)
        {
            await Task.Delay(1000);
            Console.WriteLine($"Email sent to {notification.Recipient}");
        }
    }
}
