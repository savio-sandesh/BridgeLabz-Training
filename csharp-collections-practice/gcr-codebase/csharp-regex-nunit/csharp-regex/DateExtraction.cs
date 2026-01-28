using System;
using System.Text.RegularExpressions;

class DateExtraction
{
    static void Main()
    {
        Console.WriteLine("Enter text containing dates:");
        string input = Console.ReadLine();

        string pattern = @"\b\d{2}/\d{2}/\d{4}\b";
        MatchCollection matches = Regex.Matches(input, pattern);

        if (matches.Count == 0)
        {
            Console.WriteLine("No dates found.");
        }
        else
        {
            Console.WriteLine("Dates found:");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
