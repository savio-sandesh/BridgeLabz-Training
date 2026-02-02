// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
using System.IO;
using Newtonsoft.Json.Linq;

public class JsonExtract
{
    public static void Main(string[] args)
    {
        // Read a JSON file and extract only specific fields (name, email)

        Console.WriteLine("Read JSON & Extract name + email\n");

        string dummyJson = @"{
            ""name"": ""Priya Sharma"",
            ""age"": 24,
            ""email"": ""priya.sharma@gmail.com"",
            ""city"": ""Mathura""
        }";

        string filePath = "student_extract.json";
        File.WriteAllText(filePath, dummyJson);

        Console.WriteLine("Dummy JSON file created: " + filePath);

        try
        {
            string jsonContent = File.ReadAllText(filePath);
            JObject obj = JObject.Parse(jsonContent);

            string name = obj["name"]?.ToString() ?? "N/A";
            string email = obj["email"]?.ToString() ?? "N/A";

            Console.WriteLine("\nExtracted fields:");
            Console.WriteLine("Name  : " + name);
            Console.WriteLine("Email : " + email);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading or parsing JSON: " + ex.Message);
        }

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
