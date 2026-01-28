// Write a program that performs integer division and demonstrates the finally block execution.
// The program should:
// Take two integers from the user.
// Perform division.
// Handle DivideByZeroException (if dividing by zero).
// Ensure "Operation completed" is always printed using finally.

using System;

class FinallyBlock
{
    static void Main()
    {
        try
        {
            Console.Write("Enter first number: ");
            int firstValue = int.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            int secondValue = int.Parse(Console.ReadLine());

            int result = firstValue / secondValue;
            Console.WriteLine("Result: " + result);
        }
        catch (DivideByZeroException)
        {
            // Exception is handled to prevent abrupt termination
            Console.WriteLine("Cannot divide by zero");
        }
        finally
        {
            // Finally block guarantees execution regardless of exception
            Console.WriteLine("Operation completed");
        }
    }
}
