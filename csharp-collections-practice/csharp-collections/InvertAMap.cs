using System;
using System.Collections.Generic;

class InvertAMap
{
    static void Main()
    {
        Dictionary<string, int> originalMap = new Dictionary<string, int>();

        // Step 1: Read key-value pairs
        Console.Write("Enter number of entries: ");
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter key: ");
            string key = Console.ReadLine();

            Console.Write("Enter value: ");
            int value = Convert.ToInt32(Console.ReadLine());

            originalMap[key] = value;
        }

        int choice;

        // Step 2: Menu after input
        do
        {
            Console.WriteLine("\n1. Invert the map");
            Console.WriteLine("2. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Dictionary<int, List<string>> invertedMap =
                    new Dictionary<int, List<string>>();

                // Invert the map
                foreach (var pair in originalMap)
                {
                    if (invertedMap.ContainsKey(pair.Value))
                    {
                        invertedMap[pair.Value].Add(pair.Key);
                    }
                    else
                    {
                        List<string> keys = new List<string>();
                        keys.Add(pair.Key);
                        invertedMap[pair.Value] = keys;
                    }
                }

                // Display inverted map
                Console.WriteLine("\nInverted Map:");
                foreach (var pair in invertedMap)
                {
                    Console.Write(pair.Key + " : ");
                    foreach (string k in pair.Value)
                    {
                        Console.Write(k + " ");
                    }
                    Console.WriteLine();
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
