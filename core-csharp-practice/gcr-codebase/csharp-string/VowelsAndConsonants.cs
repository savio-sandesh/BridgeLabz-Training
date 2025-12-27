using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_string
{
    internal class VowelsAndConsonants
    {
        static void Main(string[] args)
        {

            //asking user to enter the input string
            Console.WriteLine("Enter a string: ");
            string input = Console.ReadLine();

            // varibales to hold counts
            int vowelsCount = 0;
            int consonantsCount = 0;


            // loop through each character in the string
            foreach (char ch in input)
            {
                // check if character is a letter
                if (char.IsLetter(ch))
                {
                    // convert character to lowercase for uniformity
                    char lowerCh = char.ToLower(ch);

                    // check if character is a vowel
                    if (lowerCh == 'a' || lowerCh == 'e' || lowerCh == 'i' || lowerCh == 'o' || lowerCh == 'u')
                    {
                        vowelsCount++;
                    }
                    else
                    {
                        consonantsCount++;
                    }
                }
            }

            // displaying the result 
            Console.WriteLine($"Number of Vowels: {vowelsCount}");
            Console.WriteLine($"Number of Consonants: {consonantsCount}");
        }
    }
}
