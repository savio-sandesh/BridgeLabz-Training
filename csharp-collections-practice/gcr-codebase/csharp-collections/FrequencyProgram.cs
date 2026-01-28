using System;
using System.Collections.Generic;

class FrequencyProgram
{
    static void Main()
    {
        List<string> list = new List<string>();
        Dictionary<string, int> frequency = new Dictionary<string, int>();

        // Step 1: Read elements only once
        Console.Write("Enter number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter element " + (i + 1) + ": ");
            list.Add(Console.ReadLine());
        }

        int choice;

        // Step 2: Menu appears after elements are entered
        do
        {
            Console.WriteLine("\n1. Find frequency of elements");
            Console.WriteLine("2. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                // Clear dictionary to avoid duplicate counting
                frequency.Clear();

                // Count frequency of each element
                foreach (string item in list)
                {
                    if (frequency.ContainsKey(item))
                    {
                        frequency[item]++;
                    }
                    else
                    {
                        frequency[item] = 1;
                    }
                }

                // Display frequency result
                Console.WriteLine("\nElement Frequency:");
                foreach (var pair in frequency)
                {
                    Console.WriteLine(pair.Key + " : " + pair.Value);
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
