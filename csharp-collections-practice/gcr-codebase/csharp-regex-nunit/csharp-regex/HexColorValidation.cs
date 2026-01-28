using System;
using System.Text.RegularExpressions;

class HexColorValidation
{
    static void Main()
    {
        Console.Write("Enter hex color code: ");
        string colorCode = Console.ReadLine();

        string pattern = @"^#[A-Fa-f0-9]{6}$";

        if (Regex.IsMatch(colorCode, pattern))
        {
            Console.WriteLine("Valid Hex Color Code");
        }
        else
        {
            Console.WriteLine("Invalid Hex Color Code");
        }
    }
}
