using System;
using System.Text.RegularExpressions;

class ProgrammingLanguageExtraction
{
    static void Main()
    {
        Console.WriteLine("Enter text:");
        string input = Console.ReadLine();

        string pattern = @"\b(Java|Python|JavaScript|Go)\b";
        MatchCollection matches = Regex.Matches(input, pattern);

        if (matches.Count == 0)
        {
            Console.WriteLine("No programming languages found.");
        }
        else
        {
            Console.WriteLine("Programming languages found:");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
