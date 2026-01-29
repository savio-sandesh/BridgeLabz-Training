using System;
using System.IO;
using System.Collections.Generic;

public class GenerateCsvReportFromDatabase
{
    private class Employee
    {
        public int Id { get; }
        public string Name { get; }
        public string Department { get; }
        public int Salary { get; }

        public Employee(int id, string name, string department, int salary)
        {
            Id = id;
            Name = name;
            Department = department;
            Salary = salary;
        }
    }

    private static List<Employee> FetchEmployeesFromDatabase()
    {
        // Simulated database records
        return new List<Employee>
        {
            new Employee(101, "Rahul Kumar", "IT", 65000),
            new Employee(102, "Priya Sharma", "HR", 52000),
            new Employee(103, "Aman Singh", "Sales", 48000),
            new Employee(104, "Sneha Verma", "Finance", 70000),
            new Employee(105, "Vikram Patel", "IT", 82000)
        };
    }

    private static void GenerateCsvReport(string filePath)
    {
        List<Employee> employees = FetchEmployeesFromDatabase();

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Employee ID,Name,Department,Salary");

            foreach (var emp in employees)
            {
                writer.WriteLine($"{emp.Id},{emp.Name},{emp.Department},{emp.Salary}");
            }
        }

        Console.WriteLine("CSV report generated successfully.");
        Console.WriteLine($"Total records written: {employees.Count}");
    }

    public static void Main()
    {
        Console.WriteLine("Generate CSV Report from Database (Simulation)\n");

        string outputPath = "employees_report.csv";
        GenerateCsvReport(outputPath);

        Console.WriteLine($"\nOutput file: {outputPath}");
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
