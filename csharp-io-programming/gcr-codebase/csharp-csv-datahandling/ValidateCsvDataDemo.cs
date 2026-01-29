using System;
using System.IO;
using System.Text.RegularExpressions;

public class ValidateCsvDataDemo
{
    private static string GenerateStudentValidationCsv()
    {
        string filePath = "students_validation.csv";

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("ID,Name,Email,Phone,Marks");
            writer.WriteLine("801,Arjun,arjun@gmail.com,9876543210,85");
            writer.WriteLine("802,Kavya,kavya@invalid,9123456789,92");
            writer.WriteLine("803,Rohan,rohan@test.com,98765,78");
            writer.WriteLine("804,Ishita,ishita@yahoo.com,9876543210,88");
            writer.WriteLine("805,Manish,manish@company.com,987654321,65");
        }

        Console.WriteLine("CSV file created for validation.");
        return filePath;
    }

    private static void ValidateCsvFile(string csvFile)
    {
        if (!File.Exists(csvFile))
        {
            Console.WriteLine("CSV file not found.");
            return;
        }

        Regex emailPattern =
            new Regex(@"^[\w\.-]+@([\w-]+\.)+[A-Za-z]{2,}$");

        Regex phonePattern =
            new Regex(@"^\d{10}$");

        bool invalidFound = false;
        int dataRowNumber = 0;

        using (StreamReader reader = new StreamReader(csvFile))
        {
            reader.ReadLine(); // skip header
            string line;

            Console.WriteLine("\nInvalid Records:\n");

            while ((line = reader.ReadLine()) != null)
            {
                dataRowNumber++;

                string[] cols = line.Split(',');
                if (cols.Length != 5)
                    continue;

                bool emailValid = emailPattern.IsMatch(cols[2]);
                bool phoneValid = phonePattern.IsMatch(cols[3]);

                if (!emailValid || !phoneValid)
                {
                    invalidFound = true;

                    Console.WriteLine($"Row {dataRowNumber}:");
                    Console.WriteLine($"  ID: {cols[0]}, Name: {cols[1]}");
                    Console.WriteLine($"  Email: {cols[2]} → {(emailValid ? "Valid" : "Invalid")}");
                    Console.WriteLine($"  Phone: {cols[3]} → {(phoneValid ? "Valid" : "Invalid")}");
                    Console.WriteLine();
                }
            }
        }

        if (!invalidFound)
        {
            Console.WriteLine("All records are valid.");
        }
    }

    public static void Main()
    {
        Console.WriteLine("CSV Data Validation (Email & Phone)\n");

        string csvPath = GenerateStudentValidationCsv();
        ValidateCsvFile(csvPath);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
