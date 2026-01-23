// Create a C# program that performs array operations.
// Accept an integer array and an index number.
// Retrieve and print the value at that index.
// Handle the following exceptions:
// IndexOutOfRangeException if the index is out of range.
// NullReferenceException if the array is null.

using System;

class MultipleException
{
    static void Main()
    {
        int[] numbers = null;

        Console.WriteLine("1. Initialize array");
        Console.WriteLine("2. Get value by index");
        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        try
        {
            if (choice == 1)
            {
                // Array initialization is separated to simulate real runtime scenarios
                numbers = new int[] { 10, 20, 30, 40 };
                Console.WriteLine("Array initialized successfully");
            }
            else if (choice == 2)
            {
                Console.Write("Enter index: ");
                int index = int.Parse(Console.ReadLine());

                Console.WriteLine("Value at index " + index + ": " + numbers[index]);
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }
        }
        catch (IndexOutOfRangeException)
        {
            // Protects against accessing invalid memory positions
            Console.WriteLine("Invalid index!");
        }
        catch (NullReferenceException)
        {
            // Ensures array is initialized before usage
            Console.WriteLine("Array is not initialized!");
        }
    }
}
