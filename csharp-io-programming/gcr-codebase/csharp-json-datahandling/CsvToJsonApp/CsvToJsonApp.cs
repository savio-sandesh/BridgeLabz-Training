// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class CsvToJson
{
    // Represents a single CSV row as a C# object
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Marks { get; set; }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Convert CSV Data to JSON\n");

        // Sample CSV data (simulating file input)
        string[] csvLines =
        {
            "ID,Name,Age,Marks",
            "101,Rahul Kumar,20,85",
            "102,Priya Sharma,19,92",
            "103,Aman Singh,21,78",
            "104,Sneha Verma,18,88",
            "105,Vikram Patel,22,65"
        };

        // Display CSV content
        foreach (string line in csvLines)
        {
            Console.WriteLine(line);
        }

        // Convert CSV rows into C# objects
        List<Student> students = new List<Student>();

        for (int i = 1; i < csvLines.Length; i++) // Skip header
        {
            string[] columns = csvLines[i].Split(',');

            if (columns.Length == 4)
            {
                try
                {
                    students.Add(new Student
                    {
                        Id = int.Parse(columns[0]),
                        Name = columns[1],
                        Age = int.Parse(columns[2]),
                        Marks = int.Parse(columns[3])
                    });
                }
                catch
                {
                    Console.WriteLine("Invalid row skipped: " + csvLines[i]);
                }
            }
        }

        // Serialize list into JSON
        string json = JsonConvert.SerializeObject(students, Formatting.Indented);
        Console.WriteLine("\nConverted JSON:");
        Console.WriteLine(json);

        // Save JSON output to file
        string outputFile = "students_from_csv.json";
        System.IO.File.WriteAllText(outputFile, json);
        Console.WriteLine($"\nSaved to file: {outputFile}");

        Console.ReadKey();
    }
}
