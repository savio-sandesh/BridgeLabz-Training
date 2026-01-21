using System;
using System.Collections.Generic;

class GenerateBinaryNumber
{
    static void Main()
    {
        int choice;

        do
        {
            Console.WriteLine("\n1. Generate binary numbers");
            Console.WriteLine("2. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Enter value of N: ");
                int n = Convert.ToInt32(Console.ReadLine());

                Queue<string> queue = new Queue<string>();

                // Add first binary number
                queue.Enqueue("1");

                Console.WriteLine("Binary Numbers:");

                // Generate first N binary numbers
                for (int i = 0; i < n; i++)
                {
                    string current = queue.Dequeue();
                    Console.Write(current + " ");

                    queue.Enqueue(current + "0");
                    queue.Enqueue(current + "1");
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
}
