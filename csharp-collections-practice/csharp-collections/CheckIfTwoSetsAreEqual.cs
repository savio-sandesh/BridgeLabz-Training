using System;
using System.Collections.Generic;

class SetEqualityProgram
{
    static void Main()
    {
        HashSet<int> set1 = new HashSet<int>();
        HashSet<int> set2 = new HashSet<int>();

        // Step 1: Read elements of first set
        Console.Write("Enter number of elements in Set 1: ");
        int n1 = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n1; i++)
        {
            Console.Write("Enter element " + (i + 1) + ": ");
            set1.Add(Convert.ToInt32(Console.ReadLine()));
        }

        // Step 2: Read elements of second set
        Console.Write("\nEnter number of elements in Set 2: ");
        int n2 = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n2; i++)
        {
            Console.Write("Enter element " + (i + 1) + ": ");
            set2.Add(Convert.ToInt32(Console.ReadLine()));
        }

        int choice;

        // Step 3: Menu
        do
        {
            Console.WriteLine("\n1. Check if sets are equal");
            Console.WriteLine("2. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                bool isEqual = true;

                // If counts are different, sets cannot be equal
                if (set1.Count != set2.Count)
                {
                    isEqual = false;
                }
                else
                {
                    // Check if every element of set1 exists in set2
                    foreach (int item in set1)
                    {
                        if (!set2.Contains(item))
                        {
                            isEqual = false;
                            break;
                        }
                    }
                }

                // Display result
                if (isEqual)
                {
                    Console.WriteLine("Both sets are equal.");
                }
                else
                {
                    Console.WriteLine("Sets are not equal.");
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
