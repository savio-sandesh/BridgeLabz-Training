using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_string
{
    internal class MostFrequentCharacter
    {
        static void Main(string[] args)
        {
            // asking user to enter the input string
            Console.WriteLine("Enter a string: ");
            string inputText = Console.ReadLine()!;

            if (inputText.Length == 0)
            {
                Console.WriteLine("Empty string");
                return;
            }

            // assume first character is the most frequent
            char mostFrequentChar = inputText[0];

            int max = 0; // to hold the maximum count


            // outer loop to pick each character at a time 
            for (int i = 0; i < inputText.Length; i++)
            {
                int count = 0;

                // inner loop to count occurrences of the picked character
                for (int j = 0; j < inputText.Length; j++)
                {
                    if (inputText[i] == inputText[j])
                    {
                        count++;
                    }
                }

                // update most frequent character if current count is greater than max
                if (count > max)
                {
                    max = count;
                    mostFrequentChar = inputText[i];
                }

                // If multiple characters have the same maximum frequency,
                // the first one encountered is considered the most frequent.
            }
            Console.WriteLine($"The most frequent character is '{mostFrequentChar}' which appears {max} times.");
        }
    }
}
