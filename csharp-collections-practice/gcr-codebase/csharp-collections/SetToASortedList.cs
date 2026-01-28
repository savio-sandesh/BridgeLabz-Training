using System;
using System.Collections.Generic;

class SetToASortedLisT
{
    static void Main()
    {
        HashSet<int> set = new HashSet<int>();

        // Step 1: Read set elements
        Console.Write("Enter number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter element " + (i + 1) + ": ");
            set.Add(Convert.ToInt32(Console.ReadLine()));
        }

        int choice;

        // Step 2: Menu after input
        do
        {
            Console.WriteLine("\n1. Convert to sorted list");
            Console.WriteLine("2. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                List<int> list = new List<int>();

                // Convert set to list
                foreach (int item in set)
                {
                    list.Add(item);
                }

                // Simple sorting using nested loops (no built-in Sort)
                for (int i = 0; i < list.Count - 1; i++)
                {
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        if (list[i] > list[j])
                        {
                            int temp = list[i];
                            list[i] = list[j];
                            list[j] = temp;
                        }
                    }
                }

                // Display sorted list
                Console.WriteLine("Sorted List:");
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
