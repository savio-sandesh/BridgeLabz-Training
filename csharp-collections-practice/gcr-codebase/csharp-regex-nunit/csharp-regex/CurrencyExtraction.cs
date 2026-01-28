using System;
using System.Text.RegularExpressions;

class CurrencyExtraction
{
    static void Main()
    {
        Console.WriteLine("Enter text containing currency values:");
        string input = Console.ReadLine();

        string pattern = @"\$?\s?\d+\.\d{2}";
        MatchCollection matches = Regex.Matches(input, pattern);

        if (matches.Count == 0)
        {
            Console.WriteLine("No currency values found.");
        }
        else
        {
            Console.WriteLine("Currency values found:");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value.Trim());
            }
        }
    }
}
