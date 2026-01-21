using System;
using System.Collections.Generic;

class SymmetricDifference
{
    static void Main()
    {
        HashSet<int> set1 = new HashSet<int>();
        HashSet<int> set2 = new HashSet<int>();

        // Input for Set 1
        Console.Write("Enter number of elements in Set 1: ");
        int n1 = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n1; i++)
        {
            Console.Write("Enter element " + (i + 1) + ": ");
            set1.Add(Convert.ToInt32(Console.ReadLine()));
        }

        // Input for Set 2
        Console.Write("\nEnter number of elements in Set 2: ");
        int n2 = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n2; i++)
        {
            Console.Write("Enter element " + (i + 1) + ": ");
            set2.Add(Convert.ToInt32(Console.ReadLine()));
        }

        int choice;

        // Menu
        do
        {
            Console.WriteLine("\n1. Find Symmetric Difference");
            Console.WriteLine("2. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                HashSet<int> result = new HashSet<int>();

                // Elements present in Set1 but not in Set2
                foreach (int item in set1)
                {
                    if (!set2.Contains(item))
                    {
                        result.Add(item);
                    }
                }

                // Elements present in Set2 but not in Set1
                foreach (int item in set2)
                {
                    if (!set1.Contains(item))
                    {
                        result.Add(item);
                    }
                }

                Console.WriteLine("Symmetric Difference:");
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
