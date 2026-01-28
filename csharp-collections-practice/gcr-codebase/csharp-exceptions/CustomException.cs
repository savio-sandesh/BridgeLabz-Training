// Create a custom exception called InvalidAgeException.
// Write a method ValidateAge(int age) that throws InvalidAgeException if the age is below 18.
// In Main(), take user input and call ValidateAge().
// If an exception occurs, display "Age must be 18 or above".

using System;

class InvalidAgeException : Exception
{
}

class CustomException
{
    static void ValidateAge(int age)
    {
        // Age validation is separated to demonstrate custom exception usage
        if (age < 18)
        {
            throw new InvalidAgeException();
        }
    }

    static void Main()
    {
        try
        {
            Console.Write("Enter age: ");
            int userAge = int.Parse(Console.ReadLine());

            ValidateAge(userAge);
            Console.WriteLine("Access granted!");
        }
        catch (InvalidAgeException)
        {
            // Custom exception is caught to enforce age restriction rule
            Console.WriteLine("Age must be 18 or above");
        }
    }
}