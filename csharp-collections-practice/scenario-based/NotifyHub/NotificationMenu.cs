using System;

namespace NotifyHub
{
    public class NotificationMenu
    {
        private readonly INotificationService _service;

        public NotificationMenu(INotificationService service)
        {
            _service = service;
        }

        public void Show()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- NotifyHub Menu ---");
                Console.WriteLine("1. Add Notification");
                Console.WriteLine("2. View All Notifications");
                Console.WriteLine("3. Exit");
                Console.Write("Select option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddNotification();
                        break;
                    case "2":
                        _service.DisplayAll();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        private void AddNotification()
        {
            Console.Write("Recipient: ");
            string recipient = Console.ReadLine();

            Console.Write("Message: ");
            string message = Console.ReadLine();

            Console.WriteLine("Priority: 1-High, 2-Medium, 3-Low");
            int priority = int.Parse(Console.ReadLine());

            Console.WriteLine("Type: 1-Email, 2-SMS, 3-AppAlert");
            int type = int.Parse(Console.ReadLine());

            Notification notification = new Notification
            {
                Id = Guid.NewGuid(),
                Recipient = recipient,
                Message = message,
                Priority = (NotificationPriority)priority,
                Type = (NotificationType)type,
                CreatedTime = DateTime.Now,
                Status = NotificationStatus.Pending
            };

            _service.AddNotification(notification);
        }
    }
}
