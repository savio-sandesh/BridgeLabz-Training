using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_string
{
    internal class PalindromeString
    {
        static void Main(string[] args)
        {
            // asking user to enter the string
            Console.WriteLine("Enter a string: ");
            string text = Console.ReadLine();

            // converting to lowercase to avoid case sensitivity
            text = text.ToLower();

            // variable to hold the reversed string
            string reversedText = "";

            // loop through the string in reverse order
            for (int i = text.Length - 1; i >= 0; i--)
            {
                reversedText += text[i];
            }
            // checking if the original string is equal to the reversed string
            if (text.Equals(reversedText, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"{text} is a palindrome.");
            }
            else
            {
                Console.WriteLine($"{text} is not a palindrome.");
            }
        }
    }
}
