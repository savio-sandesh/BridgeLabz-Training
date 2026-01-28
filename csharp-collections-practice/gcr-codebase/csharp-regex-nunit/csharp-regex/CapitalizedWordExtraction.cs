using System;
using System.Text.RegularExpressions;

class CapitalizedWordExtraction
{
    static void Main()
    {
        Console.WriteLine("Enter a sentence:");
        string input = Console.ReadLine();

        string pattern = @"\b[A-Z][a-z]*\b";
        MatchCollection matches = Regex.Matches(input, pattern);

        if (matches.Count == 0)
        {
            Console.WriteLine("No capitalized words found.");
        }
        else
        {
            Console.WriteLine("Capitalized words:");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
