using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_string
{
    internal class SubstringOccurrences
    {
        static void Main(string[] args)
        {
            // asking user to enter the main string
            Console.WriteLine("Enter the main string: ");
            string text = Console.ReadLine()!;

            // asking user to enter the substring to search for
            Console.WriteLine("Enter the substring to search for: ");
            string sub = Console.ReadLine()!;

            // variable to hold the count of occurrences
            int occurCount = 0;

            // loop through the main string to find occurrences of the substring
            for (int i = 0; i <= text.Length - sub.Length; i++)
            {
                // check if the substring matches the part of the main string
                if (text.Substring(i, sub.Length) == sub)
                {
                    occurCount++;
                }
            }

            // displaying the result 
            Console.WriteLine($"The substring '{sub}' occurs {occurCount} times in the main string.");
        }
    }
}
