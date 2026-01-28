using System;
using System.Text.RegularExpressions;

class SpaceReplacement
{
    static void Main()
    {
        Console.WriteLine("Enter a sentence with extra spaces:");
        string input = Console.ReadLine();

        string pattern = @"\s+";
        string result = Regex.Replace(input, pattern, " ");

        Console.WriteLine("After removing extra spaces:");
        Console.WriteLine(result);
    }
}
