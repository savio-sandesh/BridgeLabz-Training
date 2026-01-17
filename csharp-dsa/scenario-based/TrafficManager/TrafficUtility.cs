using System;

namespace TrafficManager
{
    // Handles roundabout flow using Circular Linked List and Queue
    public class TrafficUtility : ITrafficManager
    {
        // Circular Linked List (roundabout)
        private Vehicle tail;

        // Queue for waiting vehicles
        private Vehicle[] queue;
        private int front;
        private int rear;
        private int capacity;

        // Constructor initializes queue and roundabout
        public TrafficUtility()
        {
            capacity = 10; // Maximum waiting vehicles
            queue = new Vehicle[capacity];
            front = 0;
            rear = -1;
            tail = null;
        }

        // Adds a vehicle to the waiting queue
        public void AddVehicleToQueue()
        {
            if (rear == capacity - 1)
            {
                Console.WriteLine("Queue overflow: Waiting area is full.\n");
                return;
            }

            Console.Write("Enter Vehicle Number: ");
            string number = Console.ReadLine();

            Vehicle vehicle = new Vehicle();
            vehicle.VehicleNumber = number;

            rear++;
            queue[rear] = vehicle;

            Console.WriteLine("Vehicle added to queue.\n");
        }

        // Moves vehicle from queue into the roundabout
        public void AllowVehicleToEnter()
        {
            if (front > rear)
            {
                Console.WriteLine("Queue underflow: No vehicles waiting.\n");
                return;
            }

            Vehicle vehicle = queue[front];
            front++;

            AddToRoundabout(vehicle);
            Console.WriteLine("Vehicle entered the roundabout.\n");
        }

        // Removes a vehicle from the roundabout
        public void RemoveVehicleFromRoundabout()
        {
            if (tail == null)
            {
                Console.WriteLine("Roundabout is empty.\n");
                return;
            }

            Vehicle head = tail.Next;

            if (head == tail)
            {
                tail = null;
            }
            else
            {
                tail.Next = head.Next;
            }

            Console.WriteLine("Vehicle exited the roundabout.\n");
        }

        // Displays current roundabout state
        public void DisplayRoundabout()
        {
            if (tail == null)
            {
                Console.WriteLine("Roundabout is empty.\n");
                return;
            }

            Console.WriteLine("Vehicles in Roundabout:");

            Vehicle current = tail.Next;
            do
            {
                Console.WriteLine("Vehicle Number: " + current.VehicleNumber);
                current = current.Next;
            }
            while (current != tail.Next);

            Console.WriteLine();
        }

        // Adds a vehicle to the circular linked list
        private void AddToRoundabout(Vehicle vehicle)
        {
            if (tail == null)
            {
                tail = vehicle;
                tail.Next = tail;
            }
            else
            {
                vehicle.Next = tail.Next;
                tail.Next = vehicle;
                tail = vehicle;
            }
        }
    }
}
