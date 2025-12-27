using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_string
{
    internal class LongestWordInSentence
    {
        static void Main(string[] args)
        {
            // asking user to enter the sentence
            Console.WriteLine("Enter a sentence: ");
            string sentence = Console.ReadLine()!;

            // 'Console.ReadLine()' can return null.
            // '!' tells the compiler that we are sure the value will not be null here.

            // splitting the sentence into words
            string[] words = sentence.Split(' ');

            // variable to hold the longest word
            string longestWord = "";

            // loop through each word in the array
            foreach (string word in words)
            {
                // check if the current word is longer than the longest word found so far
                if (word.Length > longestWord.Length)
                {
                    longestWord = word;
                }
            }
            // displaying the longest word
            Console.WriteLine("The longest word is: " + longestWord);
        }
    }
}
