using System;
using System.Text.RegularExpressions;

class UsernameValidation
{
    static void Main()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        string pattern = @"^[A-Za-z][A-Za-z0-9_]{4,14}$";

        if (Regex.IsMatch(username, pattern))
        {
            Console.WriteLine("Valid Username");
        }
        else
        {
            Console.WriteLine("Invalid Username");
        }
    }
}
