using System;
using System.Collections.Generic;

class SubsetCheck
{
    static void Main()
    {
        HashSet<int> setA = new HashSet<int>();
        HashSet<int> setB = new HashSet<int>();

        // Input for Set A
        Console.Write("Enter number of elements in Set A: ");
        int nA = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < nA; i++)
        {
            Console.Write("Enter element " + (i + 1) + ": ");
            setA.Add(Convert.ToInt32(Console.ReadLine()));
        }

        // Input for Set B
        Console.Write("\nEnter number of elements in Set B: ");
        int nB = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < nB; i++)
        {
            Console.Write("Enter element " + (i + 1) + ": ");
            setB.Add(Convert.ToInt32(Console.ReadLine()));
        }

        int choice;

        // Menu
        do
        {
            Console.WriteLine("\n1. Check if Set A is subset of Set B");
            Console.WriteLine("2. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                bool isSubset = true;

                // Check each element of Set A in Set B
                foreach (int item in setA)
                {
                    if (!setB.Contains(item))
                    {
                        isSubset = false;
                        break;
                    }
                }

                // Display result
                if (isSubset)
                {
                    Console.WriteLine("Set A is a subset of Set B.");
                }
                else
                {
                    Console.WriteLine("Set A is NOT a subset of Set B.");
                }
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
