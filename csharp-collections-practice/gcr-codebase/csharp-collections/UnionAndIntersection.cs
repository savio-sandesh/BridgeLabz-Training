using System;
using System.Collections.Generic;

class UnionandIntersection
{
    static void Main()
    {
        HashSet<int> set1 = new HashSet<int>();
        HashSet<int> set2 = new HashSet<int>();

        // Input for first set
        Console.Write("Enter number of elements in Set 1: ");
        int n1 = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n1; i++)
        {
            Console.Write("Enter element " + (i + 1) + ": ");
            set1.Add(Convert.ToInt32(Console.ReadLine()));
        }

        // Input for second set
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
            Console.WriteLine("\n1. Find Union");
            Console.WriteLine("2. Find Intersection");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                HashSet<int> unionSet = new HashSet<int>();

                // Add all elements from both sets
                foreach (int item in set1)
                {
                    unionSet.Add(item);
                }
                foreach (int item in set2)
                {
                    unionSet.Add(item);
                }

                Console.WriteLine("Union of sets:");
                foreach (int item in unionSet)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            else if (choice == 2)
            {
                HashSet<int> intersectionSet = new HashSet<int>();

                // Add only common elements
                foreach (int item in set1)
                {
                    if (set2.Contains(item))
                    {
                        intersectionSet.Add(item);
                    }
                }

                Console.WriteLine("Intersection of sets:");
                foreach (int item in intersectionSet)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            else if (choice == 3)
            {
                Console.WriteLine("Exiting program...");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }

        } while (choice != 3);
    }
}
