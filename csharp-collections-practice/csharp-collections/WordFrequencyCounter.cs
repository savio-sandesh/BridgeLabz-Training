using System;
using System.Collections.Generic;

class WordFrequencyCounter
{
    static void Main()
    {
        Console.Write("Enter a text: ");
        string input = Console.ReadLine().ToLower();

        // Split input text into words
        string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> frequency = new Dictionary<string, int>();

        int choice;

        // Menu after input
        do
        {
            Console.WriteLine("\n1. Find word frequency");
            Console.WriteLine("2. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                frequency.Clear();

                // Count frequency of each word
                foreach (string word in words)
                {
                    if (frequency.ContainsKey(word))
                    {
                        frequency[word]++;
                    }
                    else
                    {
                        frequency[word] = 1;
                    }
                }

                // Display result
                Console.WriteLine("\nWord Frequency:");
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
