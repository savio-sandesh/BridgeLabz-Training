using System;
using Newtonsoft.Json;

// Entry point class for creating and displaying Student JSON
public class StudentJsonApp
{
    // Model class representing a Student entity
    // Stores basic student details required for JSON serialization
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string[] Subjects { get; set; }
    }

    public static void Main(string[] args)
    {
        // Q1: Create a JSON object for a Student with name, age, and subjects

        Console.WriteLine("Create Student JSON\n");

        // Creating and initializing Student object
        Student student = new Student
        {
            Name = "Rahul",
            Age = 21,
            Subjects = new string[]
            {
                "Maths",
                "Physics",
                "Chemistry",
                "Computer Science"
            }
        };

        // Converting Student object to formatted JSON string
        string jsonOutput = JsonConvert.SerializeObject(student, Formatting.Indented);

        // Displaying JSON output
        Console.WriteLine("Student JSON:");
        Console.WriteLine(jsonOutput);

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}
