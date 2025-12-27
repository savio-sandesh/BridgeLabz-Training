using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_string
{
    internal class ToggleCaseOfCharacters
    {
        static void Main(string[] args)
        {
            // asking user to enter the input string
            Console.WriteLine("Enter a string: ");
            string text = Console.ReadLine()!;

            // variable to hold the toggled case string
            string toggledText = "";

            // loop through each character in the string
            foreach (char ch in text)
            {
                // check if character is uppercase
                if (char.IsUpper(ch))
                {
                    // convert to lowercase and add to the result
                    toggledText += char.ToLower(ch);
                }
                // check if character is lowercase
                else if (char.IsLower(ch))
                {
                    // convert to uppercase and add to the result
                    toggledText += char.ToUpper(ch);
                }
                else
                {
                    // if not a letter, keep it unchanged
                    toggledText += ch;
                }
            }
            // displaying the result
            Console.WriteLine("Toggled Case String: " + toggledText);

        }
    }
}
