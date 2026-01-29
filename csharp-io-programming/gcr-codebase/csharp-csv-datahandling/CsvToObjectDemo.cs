using System;
using System.IO;
using System.Collections.Generic;

public class CsvToObjectDemo
{
    public class Student
    {
        public int Id { get; }
        public string Name { get; }
        public int Age { get; }
        public int Marks { get; }

        public Student(int id, string name, int age, int marks)
        {
            Id = id;
            Name = name;
            Age = age;
            Marks = marks;
        }

        public void Print()
        {
            Console.WriteLine($"{Id} | {Name} | Age: {Age} | Marks: {Marks}");
        }
    }

    private static string CreateDummyCsv()
    {
        string fileName = "students.csv";

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine("ID,Name,Age,Marks");
            writer.WriteLine("101,Rahul,20,85");
            writer.WriteLine("102,Priya,19,92");
            writer.WriteLine("103,Aman,21,78");
        }

        Console.WriteLine("CSV file created successfully.");
        return fileName;
    }

    private static void ConvertCsvToStudents(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        List<Student> students = new List<Student>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            bool isHeader = true;
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                if (isHeader)
                {
                    isHeader = false;
                    continue;
                }

                string[] cols = line.Split(',');

                if (cols.Length != 4)
                    continue;

                if (!int.TryParse(cols[0], out int id) ||
                    !int.TryParse(cols[2], out int age) ||
                    !int.TryParse(cols[3], out int marks))
                    continue;

                students.Add(new Student(id, cols[1], age, marks));
            }
        }

        Console.WriteLine("\nStudents converted from CSV:\n");
        foreach (var student in students)
        {
            student.Print();
        }
    }

    public static void Main()
    {
        Console.WriteLine("CSV to C# Object Conversion\n");

        string csvPath = CreateDummyCsv();
        ConvertCsvToStudents(csvPath);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
