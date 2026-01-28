using System;
using System.Text.RegularExpressions;

class SSNValidation
{
    static void Main()
    {
        Console.Write("Enter SSN (XXX-XX-XXXX): ");
        string ssn = Console.ReadLine();

        string pattern = @"^\d{3}-\d{2}-\d{4}$";

        if (Regex.IsMatch(ssn, pattern))
        {
            Console.WriteLine("Valid SSN");
        }
        else
        {
            Console.WriteLine("Invalid SSN");
        }
    }
}
