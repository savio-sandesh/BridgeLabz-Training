using System;
using System.Text.RegularExpressions;

class BadWordCensor
{
    static void Main()
    {
        Console.WriteLine("Enter a sentence:");
        string input = Console.ReadLine();

        string pattern = @"\b(damn|stupid)\b";
        string result = Regex.Replace(
            input,
            pattern,
            "****",
            RegexOptions.IgnoreCase
        );

        Console.WriteLine("Censored sentence:");
        Console.WriteLine(result);
    }
}
