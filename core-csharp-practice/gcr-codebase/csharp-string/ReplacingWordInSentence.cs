using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_string
{
    internal class ReplacingWordInSentence
    {
        static void Main(string[] args)
        {
            // taking sentence input from user
            Console.WriteLine("Enter a sentence: ");
            string sentence = Console.ReadLine()!;

            // taking word to be replaced input from user
            Console.WriteLine("Enter the word to be replaced: ");
            string wordToReplace = Console.ReadLine()!;

            // taking new word input from user
            Console.WriteLine("Enter the new word: ");
            string newWord = Console.ReadLine()!;

            // calling ReplaceWord method to replace the word in the sentence
            string updatedSentence = ReplaceWord(sentence, wordToReplace, newWord);

            // displaying the updated sentence
            Console.WriteLine("Updated Sentence: " + updatedSentence);

            
        }

        // method to replace a word in a sentence
        static string ReplaceWord(string sentence, string wordToReplace, string newWord)
        {
            string res = "";

            string[] words = sentence.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Equals(wordToReplace))
                {
                    words[i] = newWord;
                }
                res += words[i] + " ";
            }

            return res.Trim();
        }
    }
}
