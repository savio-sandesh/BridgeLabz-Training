using System;
using System.Collections.Generic;

class RemoveDuplicatesProgram
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
            Console.WriteLine("\n1. Remove duplicates");
            Console.WriteLine("2. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                List<int> result = new List<int>();

                // Traverse original list
                foreach (int item in list)
                {
                    // Add element only if it is not already present
                    if (!result.Contains(item))
                    {
                        result.Add(item);
                    }
                }

                // Display list after removing duplicates
                Console.WriteLine("List after removing duplicates:");
                foreach (int item in result)
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
