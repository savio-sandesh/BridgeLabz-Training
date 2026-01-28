using System;
using System.IO;

namespace ConsoleInput
{
    internal class Program
    {
        private const string FilePath = "UserDetails.txt";

        private static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n--- User Information Menu ---");
                Console.WriteLine("1. Enter user details");
                Console.WriteLine("2. Display saved user details");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        SaveUserDetails();
                        break;

                    case "2":
                        DisplayUserDetails();
                        break;

                    case "3":
                        Console.WriteLine("Program exited successfully.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        private static void SaveUserDetails()
        {
            try
            {
                using StreamReader reader = new StreamReader(Console.OpenStandardInput());

                Console.Write("Enter your name: ");
                string? name = reader.ReadLine();

                int age = ReadValidAge(reader);

                Console.Write("Enter your favorite programming language: ");
                string? language = reader.ReadLine();

                using StreamWriter writer = new StreamWriter(FilePath, append: true);

                writer.WriteLine("User Details");
                writer.WriteLine("------------");
                writer.WriteLine($"Name       : {name}");
                writer.WriteLine($"Age        : {age}");
                writer.WriteLine($"Language   : {language}");
                writer.WriteLine();

                Console.WriteLine("\nUser information saved successfully.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"I/O error occurred: {ex.Message}");
            }
        }

        private static int ReadValidAge(StreamReader reader)
        {
            while (true)
            {
                Console.Write("Enter your age: ");
                string? input = reader.ReadLine();

                if (int.TryParse(input, out int age) && age > 0 && age <= 120)
                {
                    return age;
                }

                Console.WriteLine("Invalid age. Please enter a valid number between 1 and 120.");
            }
        }

        private static void DisplayUserDetails()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    Console.WriteLine("No user details found.");
                    return;
                }

                using StreamReader reader = new StreamReader(FilePath);

                Console.WriteLine("\n--- Saved User Details ---");
                Console.WriteLine(reader.ReadToEnd());
            }
            catch (IOException ex)
            {
                Console.WriteLine($"I/O error occurred: {ex.Message}");
            }
        }
    }
}
