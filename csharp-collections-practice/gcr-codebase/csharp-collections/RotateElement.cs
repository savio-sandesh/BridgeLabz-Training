using System;
using System.Collections.Generic;

class RotateElement
{
    static void Main()
    {
        List<int> list = new List<int>();

        // Step 1: Read list elements
        Console.Write("Enter number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter element " + (i + 1) + ": ");
            list.Add(Convert.ToInt32(Console.ReadLine()));
        }

        int choice;

        // Step 2: Menu after input
        do
        {
            Console.WriteLine("\n1. Rotate list");
            Console.WriteLine("2. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Enter number of positions to rotate: ");
                int k = Convert.ToInt32(Console.ReadLine());

                // Normalize rotation count if greater than list size
                k = k % list.Count;

                // Rotate list k times
                for (int i = 0; i < k; i++)
                {
                    // Store first element
                    int first = list[0];

                    // Shift elements to the left
                    for (int j = 0; j < list.Count - 1; j++)
                    {
                        list[j] = list[j + 1];
                    }

                    // Place first element at the end
                    list[list.Count - 1] = first;
                }

                // Display rotated list
                Console.WriteLine("Rotated List:");
                foreach (int item in list)
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
}
