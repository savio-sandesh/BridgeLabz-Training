using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NotifyHub
{
    public class NotificationServiceImplementation : INotificationService
    {
        private readonly PriorityQueue<Notification, int> _queue = new();
        private readonly ConcurrentDictionary<Guid, Notification> _store = new();
        private readonly object _lock = new();
        private readonly int _workerCount;
        private bool _isRunning;
        private List<Task> _workers;

        public NotificationServiceImplementation(int workerCount)
        {
            _workerCount = workerCount;
            _workers = new List<Task>();
        }

        public void AddNotification(Notification notification)
        {
            var result = NotificationValidator.Validate(notification);

            if (!result.IsValid)
            {
                Console.WriteLine($"Rejected: {result.ErrorMessage}");
                return;
            }

            lock (_lock)
            {
                _queue.Enqueue(notification, (int)notification.Priority);
                _store.TryAdd(notification.Id, notification);
            }

            Console.WriteLine("Notification added successfully.");
        }

        public void StartProcessing()
        {
            _isRunning = true;

            for (int i = 0; i < _workerCount; i++)
            {
                _workers.Add(Task.Run(ProcessQueueAsync));
            }
        }

        public void StopProcessing()
        {
            _isRunning = false;
            Task.WaitAll(_workers.ToArray());
        }

        private async Task ProcessQueueAsync()
        {
            while (_isRunning)
            {
                Notification notification = null;

                lock (_lock)
                {
                    if (_queue.Count > 0)
                    {
                        notification = _queue.Dequeue();
                    }
                }

                if (notification == null)
                {
                    await Task.Delay(500);
                    continue;
                }

                try
                {
                    notification.Status = NotificationStatus.Processing;

                    var sender = NotificationSenderFactory.Create(notification.Type);
                    await sender.SendAsync(notification);

                    notification.Status = NotificationStatus.Sent;
                    Console.WriteLine($"Notification {notification.Id} sent successfully.");
                }
                catch (Exception ex)
                {
                    notification.Status = NotificationStatus.Failed;
                    Console.WriteLine($"Notification {notification.Id} failed: {ex.Message}");
                }
            }
        }

        public void DisplayAll()
        {
            foreach (var item in _store.Values)
            {
                Console.WriteLine($"{item.Id} | {item.Type} | {item.Priority} | {item.Status}");
            }
        }
    }
}
