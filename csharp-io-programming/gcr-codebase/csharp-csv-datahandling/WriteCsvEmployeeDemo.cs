using System;
using System.IO;

public class WriteCsvEmployeeDemo
{
    private static void CreateEmployeeCsv(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("ID,Name,Department,Salary");

            writer.WriteLine("901,Arjun Malhotra,IT,68000");
            writer.WriteLine("902,Kavya Iyer,HR,54000");
            writer.WriteLine("903,Rohan Khanna,Sales,49500");
            writer.WriteLine("904,Ishita Banerjee,Finance,71000");
            writer.WriteLine("905,Manish Choudhary,IT,82500");
        }

        Console.WriteLine("Employee CSV file created successfully.");
        Console.WriteLine("Total records written: 5");
    }

    public static void Main()
    {
        Console.WriteLine("Write Employee Data to CSV File\n");

        string outputFile = "employees_written.csv";
        CreateEmployeeCsv(outputFile);

        Console.WriteLine($"\nOutput file: {outputFile}");
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
