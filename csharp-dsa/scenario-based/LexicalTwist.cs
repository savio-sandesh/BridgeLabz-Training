using System;
using System.Collections.Generic;


// Lexical Twist
// --------------
// This program takes two words and checks whether the second word
// is the reverse of the first (case-insensitive).

// • If reversed → reverse the first word, convert to lowercase,
//   and replace all vowels with '@'.
// • If not reversed → combine both words, convert to uppercase,
//   then compare vowel and consonant counts to decide the output.

// Validation:
// • If any input contains more than one word, it is treated as invalid.


class LexicalTwist
{
    static void Main()
    {
        Console.Write("Enter the first word : ");
        string firstWord = Console.ReadLine().Trim();

        // Reject input if it contains spaces
        if (!IsValidWord(firstWord)) return;

        Console.Write("Enter the second word : ");
        string secondWord = Console.ReadLine().Trim();

        // Reject input if it contains spaces
        if (!IsValidWord(secondWord)) return;

        // Check if second word is reverse of first
        if (IsReverse(firstWord, secondWord))
        {
            Console.WriteLine(TransformWord(firstWord));
        }
        else
        {
            AnalyzeWords(firstWord, secondWord);
        }
    }

    // Checks if input is a single valid word
    static bool IsValidWord(string word)
    {
        if (word.Contains(" "))
        {
            Console.WriteLine(word + " is an invalid word");
            return false;
        }
        return true;
    }

    // Verifies whether second word is reverse of first
    static bool IsReverse(string first, string second)
    {
        char[] chars = first.ToLower().ToCharArray();
        Array.Reverse(chars);
        return new string(chars) == second.ToLower();
    }

    // Reverses the word, lowercases it, and replaces vowels with '@'
    static string TransformWord(string word)
    {
        char[] chars = word.ToLower().ToCharArray();
        Array.Reverse(chars);

        for (int i = 0; i < chars.Length; i++)
        {
            if ("aeiou".Contains(chars[i]))
                chars[i] = '@';
        }

        return new string(chars);
    }

    // Combines words and compares vowel and consonant counts
    static void AnalyzeWords(string first, string second)
    {
        string combined = (first + second).ToUpper();

        int vowelCount = 0, consonantCount = 0;
        HashSet<char> vowels = new HashSet<char>();
        HashSet<char> consonants = new HashSet<char>();

        foreach (char c in combined)
        {
            if (!char.IsLetter(c)) continue;

            if ("AEIOU".Contains(c))
            {
                vowelCount++;
                vowels.Add(c);
            }
            else
            {
                consonantCount++;
                consonants.Add(c);
            }
        }

        if (vowelCount > consonantCount)
            PrintFirstTwo(vowels);
        else if (consonantCount > vowelCount)
            PrintFirstTwo(consonants);
        else
            Console.WriteLine("Vowels and consonants are equal");
    }

    // Prints first two unique characters
    static void PrintFirstTwo(HashSet<char> set)
    {
        int count = 0;
        foreach (char c in set)
        {
            Console.Write(c);
            if (++count == 2) break;
        }
        Console.WriteLine();
    }
}
