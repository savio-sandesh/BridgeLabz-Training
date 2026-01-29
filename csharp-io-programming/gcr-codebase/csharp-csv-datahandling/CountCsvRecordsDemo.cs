using System;
using System.IO;

public class CountCsvRecordsDemo
{
    private static string GenerateStudentCsv()
    {
        string filePath = "students_count_records.csv";

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("ID,Name,Age,Marks");
            writer.WriteLine("301,Arjun,20,84");
            writer.WriteLine("302,Kavya,19,91");
            writer.WriteLine("303,Rohan,21,76");
            writer.WriteLine("304,Ishita,18,88");
            writer.WriteLine("305,Manish,22,67");
            writer.WriteLine("306,Pooja,20,90");
            writer.WriteLine("307,Siddharth,19,73");
            writer.WriteLine("308,Nikita,21,95");
        }

        Console.WriteLine("CSV file created for counting records.");
        return filePath;
    }

    private static void CountRecords(string csvFile)
    {
        if (!File.Exists(csvFile))
        {
            Console.WriteLine("CSV file not found.");
            return;
        }

        int count = 0;

        using (StreamReader reader = new StreamReader(csvFile))
        {
            reader.ReadLine(); // skip header
            while (reader.ReadLine() != null)
            {
                count++;
            }
        }

        Console.WriteLine($"Number of records (excluding header): {count}");
    }

    public static void Main()
    {
        Console.WriteLine("Count Records in CSV File\n");

        string csvPath = GenerateStudentCsv();
        CountRecords(csvPath);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
