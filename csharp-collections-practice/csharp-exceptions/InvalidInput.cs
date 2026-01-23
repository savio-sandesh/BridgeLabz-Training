// Create a method CalculateInterest(double amount, double rate, int years) that:
// Throws ArgumentException if amount or rate is negative.
// Propagates the exception using throw and handles it in Main().

using System;

class InvalidInput
{
    static double CalculateInterest(double amount, double rate, int years)
    {
        // Validation is enforced here to keep calculation logic safe
        if (amount < 0 || rate < 0)
        {
            throw new ArgumentException();
        }

        return (amount * rate * years) / 100;
    }

    static void Main()
    {
        try
        {
            Console.Write("Enter amount: ");
            double amount = double.Parse(Console.ReadLine());

            Console.Write("Enter rate: ");
            double rate = double.Parse(Console.ReadLine());

            Console.Write("Enter years: ");
            int years = int.Parse(Console.ReadLine());

            double interest = CalculateInterest(amount, rate, years);
            Console.WriteLine("Calculated Interest: " + interest);
        }
        catch (ArgumentException)
        {
            // Centralized handling keeps user messaging consistent
            Console.WriteLine("Invalid input: Amount and rate must be positive");
        }
    }
}
