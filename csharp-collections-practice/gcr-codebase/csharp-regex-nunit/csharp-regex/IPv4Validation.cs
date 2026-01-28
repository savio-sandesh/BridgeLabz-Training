using System;
using System.Text.RegularExpressions;

class IPv4Validation
{
    static void Main()
    {
        Console.Write("Enter IPv4 address: ");
        string ipAddress = Console.ReadLine();

        string pattern =
            @"^((25[0-5]|2[0-4]\d|[01]?\d\d?)\.){3}" +
            @"(25[0-5]|2[0-4]\d|[01]?\d\d?)$";

        if (Regex.IsMatch(ipAddress, pattern))
        {
            Console.WriteLine("Valid IPv4 Address");
        }
        else
        {
            Console.WriteLine("Invalid IPv4 Address");
        }
    }
}
