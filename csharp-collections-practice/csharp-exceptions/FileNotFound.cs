// Create a C# program that reads a file named "data.txt". If the file does not exist, handle the IOException properly and display a user-friendly message.

using System;
using System.IO;

class FileNotFound
{
    static void Main()
    {
        try
        {
            // File reading is wrapped in try to safely manage runtime file access issues
            string textFromFile = File.ReadAllText("data.txt");
            Console.WriteLine(textFromFile);
        }
        catch (IOException)
        {
            // IOException is handled to avoid program crash when file is missing
            Console.WriteLine("File not found");
        }
    }
}
