using System.Threading.Tasks;

namespace NotifyHub
{
    public interface INotificationSender
    {
        Task SendAsync(Notification notification);
    }
}
