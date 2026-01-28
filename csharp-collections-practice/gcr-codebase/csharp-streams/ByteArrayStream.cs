using System;
using System.IO;

namespace ByteArrayStream
{
    internal class Program
    {
        // Problem Statement:
        // This program demonstrates the use of MemoryStream to convert an image file
        // into a byte array and recreate the image from that byte array. It verifies
        // data integrity by comparing the original and recreated image files.

        private static void Main()
        {
            // Menu-driven loop allows repeated operations until user exits
            while (true)
            {
                Console.WriteLine("\n--- Image ByteArray Menu ---");
                Console.WriteLine("1. Convert image to byte array and recreate image");
                Console.WriteLine("2. Exit");
                Console.Write("Enter your choice: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ConvertImage();
                        break;

                    case "2":
                        Console.WriteLine("Program exited successfully.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }

        private static void ConvertImage()
        {
            // Reads source and destination paths from the user
            Console.Write("Enter source image path: ");
            string? sourcePath = Console.ReadLine();

            Console.Write("Enter destination image path: ");
            string? destinationPath = Console.ReadLine();

            // Ensures the source image exists before processing
            if (string.IsNullOrWhiteSpace(sourcePath) || !File.Exists(sourcePath))
            {
                Console.WriteLine("Source image does not exist.");
                return;
            }

            try
            {
                // Loads the entire image file into a byte array
                byte[] imageBytes = File.ReadAllBytes(sourcePath);

                // MemoryStream temporarily holds the image data in memory
                using MemoryStream memoryStream = new MemoryStream(imageBytes);

                // Recreates the image file from the byte array
                File.WriteAllBytes(destinationPath, memoryStream.ToArray());

                VerifyImage(sourcePath, destinationPath);
            }
            catch (IOException ex)
            {
                // Handles file-related input/output exceptions
                Console.WriteLine($"I/O error occurred: {ex.Message}");
            }
        }

        private static void VerifyImage(string originalPath, string newPath)
        {
            // File size comparison is used to verify successful image recreation
            FileInfo originalFile = new FileInfo(originalPath);
            FileInfo newFile = new FileInfo(newPath);

            if (originalFile.Length == newFile.Length)
            {
                Console.WriteLine("Image recreated successfully. Files are identical in size.");
            }
            else
            {
                Console.WriteLine("Image verification failed. Files are not identical.");
            }
        }
    }
}
