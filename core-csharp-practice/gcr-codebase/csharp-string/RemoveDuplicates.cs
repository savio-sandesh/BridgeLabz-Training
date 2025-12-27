using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_string
{
    internal class RemoveDuplicates
    {
        static void Main(string[] args)
        {
            // asking user to enter the string
            Console.WriteLine("Enter a string: ");
            string userInput = Console.ReadLine();

            string check="";

            // variable to hold the result string without duplicates
            string result = "";
            // loop through each character in the input string
            foreach (char ch in userInput)
            {
                // convert character to lowercase
                char lowerCaseChar = char.ToLower(ch);


                // check if the character is not already in the result string
                if (!check.Contains(lowerCaseChar))
                {
                    check += lowerCaseChar;
                    result += ch;
                }
            }
            // displaying the result string without duplicates
            Console.WriteLine($"String after removing duplicates: {result}");
        }
    }
}
