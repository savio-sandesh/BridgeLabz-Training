// File: Program.cs
using System;
using System.Diagnostics;
using System.IO;

// This program demonstrates efficient file copying in C# by using FileStream and BufferedStream.
// It copies a large file in fixed-size chunks of 4 KB and measures the execution time using Stopwatch. 
// The performance of buffered and unbuffered streams is compared to show how buffering improves file I/O efficiency, especially for large files.

namespace BufferedStreamMenuDriven
{
    internal class Program
    {
        // Buffer size set to 4 KB as per requirement
        private const int BufferSize = 4096;

        private static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n--- Buffered Stream File Copy Menu ---");
                Console.WriteLine("1. Copy file using normal FileStream");
                Console.WriteLine("2. Copy file using BufferedStream");
                Console.WriteLine("3. Compare performance (FileStream vs BufferedStream)");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PerformFileStreamCopy();
                        break;

                    case "2":
                        PerformBufferedStreamCopy();
                        break;

                    case "3":
                        ComparePerformance();
                        break;

                    case "4":
                        Console.WriteLine("Program exited successfully.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }

        private static void PerformFileStreamCopy()
        {
            Console.WriteLine("\n--- Normal FileStream Copy ---");

            Console.Write("Enter source file path: ");
            string? sourcePath = Console.ReadLine();

            Console.Write("Enter destination file path (with filename): ");
            string? destinationPath = Console.ReadLine();

            if (!IsSourceValid(sourcePath)) return;

            try
            {
                long timeTaken = CopyUsingFileStream(sourcePath!, destinationPath!);
                Console.WriteLine($"File copied successfully using FileStream in {timeTaken} ms.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"I/O Error: {ex.Message}");
            }
        }

        private static void PerformBufferedStreamCopy()
        {
            Console.WriteLine("\n--- BufferedStream Copy ---");

            Console.Write("Enter source file path: ");
            string? sourcePath = Console.ReadLine();

            Console.Write("Enter destination file path (with filename): ");
            string? destinationPath = Console.ReadLine();

            if (!IsSourceValid(sourcePath)) return;

            try
            {
                long timeTaken = CopyUsingBufferedStream(sourcePath!, destinationPath!);
                Console.WriteLine($"File copied successfully using BufferedStream in {timeTaken} ms.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"I/O Error: {ex.Message}");
            }
        }

        private static void ComparePerformance()
        {
            Console.WriteLine("\n--- Performance Comparison ---");

            Console.Write("Enter source file path: ");
            string? sourcePath = Console.ReadLine();

            if (!IsSourceValid(sourcePath)) return;

            Console.Write("Enter destination path for FileStream copy: ");
            string? fileStreamDest = Console.ReadLine();

            Console.Write("Enter destination path for BufferedStream copy: ");
            string? bufferedStreamDest = Console.ReadLine();

            try
            {
                long fileStreamTime = CopyUsingFileStream(sourcePath!, fileStreamDest!);
                long bufferedStreamTime = CopyUsingBufferedStream(sourcePath!, bufferedStreamDest!);

                Console.WriteLine("\n--- Execution Time Result ---");
                Console.WriteLine($"Normal FileStream Time   : {fileStreamTime} ms");
                Console.WriteLine($"BufferedStream Time     : {bufferedStreamTime} ms");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"I/O Error: {ex.Message}");
            }
        }

        private static long CopyUsingFileStream(string source, string destination)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            using FileStream sourceStream = new FileStream(source, FileMode.Open, FileAccess.Read);
            using FileStream destinationStream = new FileStream(destination, FileMode.Create, FileAccess.Write);

            byte[] buffer = new byte[BufferSize];
            int bytesRead;

            // Direct read and write without additional buffering
            while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                destinationStream.Write(buffer, 0, bytesRead);
            }

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        private static long CopyUsingBufferedStream(string source, string destination)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            using FileStream sourceFileStream = new FileStream(source, FileMode.Open, FileAccess.Read);
            using FileStream destinationFileStream = new FileStream(destination, FileMode.Create, FileAccess.Write);

            // BufferedStream reduces disk I/O calls by storing data temporarily in memory
            using BufferedStream bufferedInput = new BufferedStream(sourceFileStream, BufferSize);
            using BufferedStream bufferedOutput = new BufferedStream(destinationFileStream, BufferSize);

            byte[] buffer = new byte[BufferSize];
            int bytesRead;

            while ((bytesRead = bufferedInput.Read(buffer, 0, buffer.Length)) > 0)
            {
                bufferedOutput.Write(buffer, 0, bytesRead);
            }

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        private static bool IsSourceValid(string? sourcePath)
        {
            if (string.IsNullOrWhiteSpace(sourcePath) || !File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist. Please check the path.");
                return false;
            }
            return true;
        }
    }
}
