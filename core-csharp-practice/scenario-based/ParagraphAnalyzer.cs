using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// This program analyzes a given paragraph by counting the number of words, 
// identifying the longest word, and replacing a specified word in a case-insensitive manner,
// while handling edge cases like empty input.

// Workflow of the Program:
// Workflow:
// 1. Read paragraph input from the user.
// 2. Validate input manually (null / empty).
// 3. Remove punctuation using ASCII checks.
// 4. Extract words using loops instead of Split.
// 5. Count total number of words.
// 6. Find the longest word manually.
// 7. Take user input for word replacement.
// 8. Replace the word using manual, case-insensitive matching.
// 9. Display results.

namespace BridgeLabzTraining.csharp_extras.practice_problem_2
{

    internal class ParagraphAnalyzer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a paragraph:");
            string inputText = Console.ReadLine()!;

            // Check for null or empty input manually
            if (inputText == null || inputText.Length == 0)
            {
                Console.WriteLine("Given input paragraph is empty.");
                return;
            }

            // Step 1: Remove punctuation manually
            string cleanedText = RemovePunctuationManually(inputText);

            // Step 2: Extract words manually
            string[] words = ExtractWords(cleanedText, out int wordCount);

            Console.WriteLine("\nWord Count: " + wordCount);

            // Step 3: Find the longest word
            string longestWord = FindLongestWord(words, wordCount);
            Console.WriteLine("Longest Word: " + longestWord + " (Length: " + longestWord.Length + ")");

            // Step 4: Replace a word (case-insensitive)
            Console.WriteLine("\nEnter a word to replace:");
            string oldWord = Console.ReadLine();

            Console.WriteLine("Enter the new word:");
            string newWord = Console.ReadLine();

            string updatedParagraph = ReplaceWordManually(inputText, oldWord, newWord);

            Console.WriteLine("\nUpdated Paragraph:");
            Console.WriteLine(updatedParagraph);
        }

        // Removes punctuation using ASCII checks
        static string RemovePunctuationManually(string text)
        {
            char[] temp = new char[text.Length];
            int index = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];

                // Allow letters, digits, and spaces only
                if ((ch >= 'A' && ch <= 'Z') ||
                    (ch >= 'a' && ch <= 'z') ||
                    (ch >= '0' && ch <= '9') ||
                    ch == ' ')
                {
                    temp[index++] = ch;
                }
            }

            return BuildString(temp, index);
        }

        // Extracts words manually without using Split
        static string[] ExtractWords(string text, out int wordCount)
        {
            string[] words = new string[1000]; // enough for typical input
            char[] currentWord = new char[text.Length];

            int wordIndex = 0;
            int charIndex = 0;
            wordCount = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ' ')
                {
                    currentWord[charIndex++] = text[i];
                }
                else if (charIndex > 0)
                {
                    words[wordIndex++] = BuildString(currentWord, charIndex);
                    charIndex = 0;
                    wordCount++;
                }
            }

            // Add last word if present
            if (charIndex > 0)
            {
                words[wordIndex++] = BuildString(currentWord, charIndex);
                wordCount++;
            }

            return words;
        }

        // Finds the longest word using manual comparison
        static string FindLongestWord(string[] words, int count)
        {
            string longest = words[0];

            for (int i = 1; i < count; i++)
            {
                if (words[i].Length > longest.Length)
                {
                    longest = words[i];
                }
            }

            return longest;
        }

        // Replaces words manually in a case-insensitive way
        static string ReplaceWordManually(string text, string oldWord, string newWord)
        {
            char[] result = new char[text.Length * 2];
            int resultIndex = 0;

            for (int i = 0; i < text.Length;)
            {
                if (MatchWordIgnoreCase(text, i, oldWord))
                {
                    for (int j = 0; j < newWord.Length; j++)
                    {
                        result[resultIndex++] = newWord[j];
                    }
                    i += oldWord.Length;
                }
                else
                {
                    result[resultIndex++] = text[i];
                    i++;
                }
            }

            return BuildString(result, resultIndex);
        }

        // Checks word match ignoring case (ASCII logic)
        static bool MatchWordIgnoreCase(string text, int start, string word)
        {
            if (start + word.Length > text.Length)
                return false;

            for (int i = 0; i < word.Length; i++)
            {
                char a = text[start + i];
                char b = word[i];

                // Convert both to lowercase manually
                if (a >= 'A' && a <= 'Z') a = (char)(a + 32);
                if (b >= 'A' && b <= 'Z') b = (char)(b + 32);

                if (a != b)
                    return false;
            }

            return true;
        }

        // Builds a string from a character array
        static string BuildString(char[] chars, int length)
        {
            char[] finalText = new char[length];
            for (int i = 0; i < length; i++)
            {
                finalText[i] = chars[i];
            }
            return new string(finalText);
        }
    }
}

