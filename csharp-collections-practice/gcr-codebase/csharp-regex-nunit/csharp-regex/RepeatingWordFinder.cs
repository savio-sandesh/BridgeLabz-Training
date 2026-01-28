using System;
using System.Text.RegularExpressions;

class RepeatingWordFinder
{
    static void Main()
    {
        Console.WriteLine("Enter a sentence:");
        string input = Console.ReadLine();

        string pattern = @"\b(\w+)\s+\1\b";
        MatchCollection matches = Regex.Matches(
            input,
            pattern,
            RegexOptions.IgnoreCase
        );

        if (matches.Count == 0)
        {
            Console.WriteLine("No repeating words found.");
        }
        else
        {
            Console.WriteLine("Repeating words found:");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[1].Value);
            }
        }
    }
}
