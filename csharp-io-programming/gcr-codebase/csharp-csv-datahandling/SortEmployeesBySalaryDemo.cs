using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class SortEmployeesBySalaryDemo
{
    private class Employee
    {
        public int Id { get; }
        public string Name { get; }
        public string Department { get; }
        public decimal Salary { get; }

        public Employee(int id, string name, string department, decimal salary)
        {
            Id = id;
            Name = name;
            Department = department;
            Salary = salary;
        }
    }

    private static string CreateEmployeeCsv()
    {
        string filePath = "employees_salary_sort.csv";

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("ID,Name,Department,Salary");
            writer.WriteLine("701,Arjun,IT,65000");
            writer.WriteLine("702,Kavya,HR,52000");
            writer.WriteLine("703,Rohan,Sales,48000");
            writer.WriteLine("704,Ishita,Finance,70000");
            writer.WriteLine("705,Manish,IT,82000");
            writer.WriteLine("706,Pooja,IT,68000");
            writer.WriteLine("707,Siddharth,Sales,95000");
            writer.WriteLine("708,Nikita,Finance,55000");
        }

        Console.WriteLine("Employee CSV file created for sorting.");
        return filePath;
    }

    private static void DisplayTopEarners(string csvFile, int topCount)
    {
        if (!File.Exists(csvFile))
        {
            Console.WriteLine("CSV file not found.");
            return;
        }

        List<Employee> employees = new List<Employee>();

        using (StreamReader reader = new StreamReader(csvFile))
        {
            reader.ReadLine(); // skip header
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] cols = line.Split(',');
                if (cols.Length != 4)
                    continue;

                if (!int.TryParse(cols[0], out int id) ||
                    !decimal.TryParse(cols[3], out decimal salary))
                    continue;

                employees.Add(
                    new Employee(id, cols[1], cols[2], salary)
                );
            }
        }

        var topEmployees = employees
            .OrderByDescending(e => e.Salary)
            .Take(topCount);

        Console.WriteLine($"\nTop {topCount} Highest-Paid Employees:\n");
        Console.WriteLine("ID   Name         Dept        Salary");

        foreach (var emp in topEmployees)
        {
            Console.WriteLine(
                $"{emp.Id,-4} {emp.Name,-12} {emp.Department,-10} {emp.Salary}"
            );
        }
    }

    public static void Main()
    {
        Console.WriteLine("Sort CSV Records by Salary (Descending)\n");

        string csvPath = CreateEmployeeCsv();
        DisplayTopEarners(csvPath, topCount: 5);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
