using System;
using System.IO;

public class UpdateDepartmentSalaryDemo
{
    private static string CreateSampleEmployeeCsv()
    {
        string fileName = "employees_original.csv";

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine("ID,Name,Department,Salary");
            writer.WriteLine("1001,Rahul Kumar,IT,65000");
            writer.WriteLine("1002,Priya Sharma,HR,52000");
            writer.WriteLine("1003,Aman Singh,Sales,48000");
            writer.WriteLine("1004,Sneha Verma,Finance,70000");
            writer.WriteLine("1005,Vikram Patel,IT,82000");
            writer.WriteLine("1006,Neha Gupta,IT,68000");
        }

        Console.WriteLine("Original employee CSV created.");
        return fileName;
    }

    private static void IncreaseSalaryForDepartment(
        string sourceFile,
        string outputFile,
        string targetDepartment,
        decimal incrementRate)
    {
        if (!File.Exists(sourceFile))
        {
            Console.WriteLine("Source file not found.");
            return;
        }

        using (StreamReader reader = new StreamReader(sourceFile))
        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            string header = reader.ReadLine();
            writer.WriteLine(header);

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] cols = line.Split(',');
                if (cols.Length != 4)
                {
                    writer.WriteLine(line);
                    continue;
                }

                if (!decimal.TryParse(cols[3], out decimal salary))
                {
                    writer.WriteLine(line);
                    continue;
                }

                if (cols[2].Equals(targetDepartment, StringComparison.OrdinalIgnoreCase))
                {
                    salary += salary * incrementRate;
                }

                writer.WriteLine(
                    $"{cols[0]},{cols[1]},{cols[2]},{salary:F2}"
                );
            }
        }

        Console.WriteLine(
            $"Salaries for {targetDepartment} department updated by {incrementRate:P0}."
        );
        Console.WriteLine($"Updated file created: {outputFile}");
    }

    public static void Main()
    {
        Console.WriteLine("Update Salary for IT Department\n");

        string source = CreateSampleEmployeeCsv();
        string updated = "employees_updated.csv";

        IncreaseSalaryForDepartment(
            source,
            updated,
            targetDepartment: "IT",
            incrementRate: 0.10m
        );

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
