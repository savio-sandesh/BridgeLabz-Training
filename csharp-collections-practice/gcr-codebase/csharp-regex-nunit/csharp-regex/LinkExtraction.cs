using System;
using System.Text.RegularExpressions;

class LinkExtraction
{
    static void Main()
    {
        Console.WriteLine("Enter text containing links:");
        string input = Console.ReadLine();

        string pattern = @"https?://[^\s]+";
        MatchCollection matches = Regex.Matches(input, pattern);

        if (matches.Count == 0)
        {
            Console.WriteLine("No links found.");
        }
        else
        {
            Console.WriteLine("Links found:");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
