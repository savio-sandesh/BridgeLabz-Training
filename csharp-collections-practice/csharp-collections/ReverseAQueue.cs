using System;
using System.Collections.Generic;

class ReverseQueue
{
    static void Main()
    {
        Queue<int> queue = new Queue<int>();

        // Step 1: Read queue elements
        Console.Write("Enter number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter element " + (i + 1) + ": ");
            queue.Enqueue(Convert.ToInt32(Console.ReadLine()));
        }

        int choice;

        // Step 2: Menu after input
        do
        {
            Console.WriteLine("\n1. Reverse queue");
            Console.WriteLine("2. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                ReverseQueue(queue);

                Console.WriteLine("Reversed Queue:");
                foreach (int item in queue)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            else if (choice == 2)
            {
                Console.WriteLine("Exiting program...");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }

        } while (choice != 2);
    }

    // Recursive method to reverse the queue using only queue operations
    static void ReverseQueue(Queue<int> queue)
    {
        // Base condition: if queue is empty, return
        if (queue.Count == 0)
            return;

        // Remove front element
        int front = queue.Dequeue();

        // Reverse remaining queue
        ReverseQueue(queue);

        // Add removed element at the end
        queue.Enqueue(front);
    }
}
