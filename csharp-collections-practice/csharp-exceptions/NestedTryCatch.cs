// Write a C# program that:
// Takes an array and a divisor as input.
// Tries to access an element at an index.
// Tries to divide that element by the divisor.
// Uses nested try-catch to handle:
// IndexOutOfRangeException if the index is invalid.
// DivideByZeroException if the divisor is zero.

using System;

class NestedTryCatch
{
    static void Main()
    {
        int[] values = { 10, 20, 30, 40 };

        Console.WriteLine("1. Divide array element");
        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            try
            {
                Console.Write("Enter array index: ");
                int index = int.Parse(Console.ReadLine());

                try
                {
                    Console.Write("Enter divisor: ");
                    int divisor = int.Parse(Console.ReadLine());

                    int result = values[index] / divisor;
                    Console.WriteLine("Result: " + result);
                }
                catch (DivideByZeroException)
                {
                    // Inner catch handles arithmetic error specifically
                    Console.WriteLine("Cannot divide by zero!");
                }
            }
            catch (IndexOutOfRangeException)
            {
                // Outer catch handles invalid index access
                Console.WriteLine("Invalid array index!");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice");
        }
    }
}
