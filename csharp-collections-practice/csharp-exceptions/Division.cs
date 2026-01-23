// Write a C# program that asks the user to enter two numbers and divides them. Handle possible exceptions such as:
// DivideByZeroException if division by zero occurs.
// FormatException if the user enters a non-numeric value.

using System;

class Division
{
    static void Main()
    {
        try
        {
            // Input handling is done inside try to catch runtime conversion issues
            Console.Write("Enter first number: ");
            int firstNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            int secondNumber = int.Parse(Console.ReadLine());

            int result = firstNumber / secondNumber;
            Console.WriteLine("Result: " + result);
        }
        catch (DivideByZeroException)
        {
            // Handles invalid mathematical operation safely
            Console.WriteLine("Cannot divide by zero");
        }
        catch (FormatException)
        {
            // Ensures only numeric values are processed
            Console.WriteLine("Invalid input");
        }
    }
}
