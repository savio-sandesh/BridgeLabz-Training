using System;

namespace NotifyHub
{
    public class NotificationMain
    {
        private readonly INotificationService _service;

        public NotificationMain()
        {
            _service = new NotificationServiceImplementation(workerCount: 3);
        }

        public void Run()
        {
            _service.StartProcessing();

            NotificationMenu menu = new NotificationMenu(_service);
            menu.Show();

            _service.StopProcessing();
        }
    }
}
