// Write a C# program that reads the first line of a file named "info.txt" using StreamReader.
// Use using to ensure the file is automatically closed after reading.
// Handle any IOException that may occur.

using System;
using System.IO;

class ExceptionwithUsing
{
    static void Main()
    {
        try
        {
            // Using ensures proper resource cleanup even if an exception occurs
            using (StreamReader reader = new StreamReader("info.txt"))
            {
                string firstLine = reader.ReadLine();
                Console.WriteLine(firstLine);
            }
        }
        catch (IOException)
        {
            // Handles file access issues without exposing system-level details
            Console.WriteLine("Error reading file");
        }
    }
}
