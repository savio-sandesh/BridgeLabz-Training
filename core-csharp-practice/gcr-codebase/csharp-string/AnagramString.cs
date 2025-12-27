using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_string
{
    internal class AnagramString
    {
        static void Main(string[] args)
        {
            // anagrams are words or phrases made by
            // rearranging the letters of another word or phrase of same letters
            
            // take first string input from user
            Console.WriteLine("Enter the first string: ");
            string strOne = Console.ReadLine()!;

            // take second string input from user
            Console.WriteLine("Enter the second string: ");
            string strTwo = Console.ReadLine()!;

            // if length differs, they cannot be anagrams
            if (strOne.Length != strTwo.Length)
            {
                Console.WriteLine("The strings are not anagrams.");
                return;
            }

            // convert strings to character arrays
            char[] charArrayOne = strOne.ToCharArray();
            char[] charArrayTwo = strTwo.ToCharArray();

            // sort both character arrays
            Array.Sort(charArrayOne);
            Array.Sort(charArrayTwo);

            // compare sorted arrays
            bool areAnagrams = charArrayOne.SequenceEqual(charArrayTwo);
            if (areAnagrams)
            {
                Console.WriteLine("The strings are anagrams.");
            }
            else
            {
                Console.WriteLine("The strings are not anagrams.");
            }
        }
    }
}
