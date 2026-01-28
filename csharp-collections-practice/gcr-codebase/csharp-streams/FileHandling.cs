
using System;
using System.IO;
using System.Text;


// The program reads the contents of a source text file 
// and writes them into a destination file using FileStream 
// with proper exception handling.

namespace FileHandling
{
    internal class Program
    {
        private static void Main()
        {
            // Keeps the menu running until the user exits
            while (true)
            {
                Console.WriteLine("\n--- File Handling Menu ---");
                Console.WriteLine("1. Read from a file and write to another file");
                Console.WriteLine("2. Display file contents on console");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CopyFileContent();
                        break;

                    case "2":
                        DisplayFileContent();
                        break;

                    case "3":
                        Console.WriteLine("Program terminated by user.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        private static void CopyFileContent()
        {
            // Collects file paths from the user
            Console.Write("Enter source file path: ");
            string? sourcePath = Console.ReadLine();

            Console.Write("Enter destination file path: ");
            string? destinationPath = Console.ReadLine();

            // Ensures the source file exists before processing
            if (string.IsNullOrWhiteSpace(sourcePath) || !File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist.");
                return;
            }

            try
            {
                using FileStream sourceStream = new FileStream(
                    sourcePath,
                    FileMode.Open,
                    FileAccess.Read
                );

                using FileStream destinationStream = new FileStream(
                    destinationPath,
                    FileMode.Create,
                    FileAccess.Write
                );

                byte[] buffer = new byte[1024];
                int bytesRead;

                // Copies data in buffered chunks for efficiency
                while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    destinationStream.Write(buffer, 0, bytesRead);
                }

                Console.WriteLine("File copied successfully.");
            }
            catch (IOException ex)
            {
                // Handles file I/O related failures
                Console.WriteLine($"I/O error occurred: {ex.Message}");
            }
        }

        private static void DisplayFileContent()
        {
            // Collects file path from the user
            Console.Write("Enter file path to display: ");
            string? filePath = Console.ReadLine();

            // Validates file existence
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                Console.WriteLine("File does not exist.");
                return;
            }

            try
            {
                using FileStream fileStream = new FileStream(
                    filePath,
                    FileMode.Open,
                    FileAccess.Read
                );

                byte[] buffer = new byte[1024];
                int bytesRead;
                StringBuilder content = new StringBuilder();

                // Reads file content and builds the output text
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    content.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                }

                Console.WriteLine("\n--- File Contents ---");
                Console.WriteLine(content.ToString());
                Console.WriteLine("----------------------");
            }
            catch (IOException ex)
            {
                // Handles read-related I/O errors
                Console.WriteLine($"I/O error occurred: {ex.Message}");
            }
        }
    }
}
