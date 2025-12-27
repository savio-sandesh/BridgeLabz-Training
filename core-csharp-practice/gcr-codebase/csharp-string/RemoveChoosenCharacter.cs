using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_string
{
    internal class RemoveChoosenCharacter
    {
        static void Main(string[] args)
        {
            // ASKING USER TO ENTER THE INPUT STRING
            Console.WriteLine("Enter a string: ");
            string inputText = Console.ReadLine()!;

            // ASKING USER TO ENTER THE CHARACTER TO BE REMOVED
            Console.WriteLine("Enter the character to be removed: ");
            char charToRemove = Console.ReadLine()![0];

            // VARIABLE TO HOLD THE RESULT STRING  
            string resultText = "";

            // LOOP THROUGH EACH CHARACTER IN THE STRING
            foreach (char ch in inputText)
            {
                // CHECK IF THE CHARACTER IS NOT THE ONE TO BE REMOVED
                if (ch != charToRemove)
                {
                    // ADD THE CHARACTER TO THE RESULT STRING
                    resultText += ch;
                }
            }

            // DISPLAYING THE RESULT
            Console.WriteLine("Modified String: " + resultText);
        }
    }
}
