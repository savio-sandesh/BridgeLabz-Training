using System;
using System.Text.RegularExpressions;

class LicensePlateValidation
{
    static void Main()
    {
        Console.Write("Enter license plate number: ");
        string plateNumber = Console.ReadLine();

        string pattern = @"^[A-Z]{2}\d{4}$";

        if (Regex.IsMatch(plateNumber, pattern))
        {
            Console.WriteLine("Valid License Plate Number");
        }
        else
        {
            Console.WriteLine("Invalid License Plate Number");
        }
    }
}
