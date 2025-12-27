using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_string
{
    internal class ReverseAString
    {
        static void Main(string[] args)
        {
            // asking user to enter the string
            Console.WriteLine("Enter a string to reverse: ");
            string text = Console.ReadLine();


            // variable to hold the reversed string
            string reversedText = "";

            // loop through the string in reverse order
            for (int i = text.Length - 1; i >= 0; i--)
            {
                reversedText += text[i];
            }
            // displaying the reversed string
            Console.WriteLine($"Reversed String:{reversedText}");
        }
    }
}
