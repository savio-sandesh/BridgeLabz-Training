using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace EmployeeSerialization
{
    internal class Program
    {
        private const string FilePath = "employees.json";
        private static List<Employee> employees = new List<Employee>();

        private static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n--- Employee Serialization Menu ---");
                Console.WriteLine("1. Add employee");
                Console.WriteLine("2. Save employees to file");
                Console.WriteLine("3. Load employees from file");
                Console.WriteLine("4. Display employees");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEmployee();
                        break;

                    case "2":
                        SaveEmployees();
                        break;

                    case "3":
                        LoadEmployees();
                        break;

                    case "4":
                        DisplayEmployees();
                        break;

                    case "5":
                        Console.WriteLine("Program exited successfully.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        private static void AddEmployee()
        {
            try
            {
                Console.Write("Enter Employee ID: ");
                int id = int.Parse(Console.ReadLine()!);

                Console.Write("Enter Employee Name: ");
                string? name = Console.ReadLine();

                Console.Write("Enter Department: ");
                string? department = Console.ReadLine();

                Console.Write("Enter Salary: ");
                decimal salary = decimal.Parse(Console.ReadLine()!);

                employees.Add(new Employee
                {
                    Id = id,
                    Name = name,
                    Department = department,
                    Salary = salary
                });

                Console.WriteLine("Employee added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid input: {ex.Message}");
            }
        }

        private static void SaveEmployees()
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(employees, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(FilePath, jsonData);
                Console.WriteLine("Employees saved to file successfully.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"File error: {ex.Message}");
            }
        }

        private static void LoadEmployees()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    Console.WriteLine("No employee file found.");
                    return;
                }

                string jsonData = File.ReadAllText(FilePath);
                employees = JsonSerializer.Deserialize<List<Employee>>(jsonData) ?? new List<Employee>();

                Console.WriteLine("Employees loaded from file successfully.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"File error: {ex.Message}");
            }
        }

        private static void DisplayEmployees()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employee records available.");
                return;
            }

            Console.WriteLine("\n--- Employee List ---");
            foreach (Employee emp in employees)
            {
                Console.WriteLine($"ID: {emp.Id}");
                Console.WriteLine($"Name: {emp.Name}");
                Console.WriteLine($"Department: {emp.Department}");
                Console.WriteLine($"Salary: {emp.Salary}");
                Console.WriteLine("-------------------------");
            }
        }
    }

    // Employee data model used for serialization
    internal class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public decimal Salary { get; set; }
    }
}
