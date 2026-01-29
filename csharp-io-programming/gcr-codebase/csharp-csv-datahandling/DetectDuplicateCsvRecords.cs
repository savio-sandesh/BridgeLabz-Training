using System;
using System.IO;
using System.Collections.Generic;

public class DetectDuplicateCsvRecords
{
    private static string CreateDummyCsvWithDuplicates()
    {
        string fileName = "students_duplicates.csv";

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine("ID,Name,Age,Marks");
            writer.WriteLine("101,Rahul,20,85");
            writer.WriteLine("102,Priya,19,92");
            writer.WriteLine("101,Rahul,20,85");
            writer.WriteLine("103,Aman,21,78");
            writer.WriteLine("102,Priya,19,92");
        }

        Console.WriteLine("CSV file with duplicates created.");
        return fileName;
    }

    private static void DetectDuplicates(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        Dictionary<int, List<string>> recordMap = new Dictionary<int, List<string>>();

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
                if (cols.Length < 4)
                    continue;

                if (!int.TryParse(cols[0], out int id))
                    continue;

                if (!recordMap.ContainsKey(id))
                {
                    recordMap[id] = new List<string>();
                }

                recordMap[id].Add(line);
            }
        }

        Console.WriteLine("\nDuplicate Records:\n");

        bool found = false;

        foreach (var entry in recordMap)
        {
            if (entry.Value.Count > 1)
            {
                found = true;
                Console.WriteLine($"ID {entry.Key} appears {entry.Value.Count} times:");
                foreach (string record in entry.Value)
                {
                    Console.WriteLine(record);
                }
                Console.WriteLine();
            }
        }

        if (!found)
        {
            Console.WriteLine("No duplicate records found.");
        }
    }

    public static void Main()
    {
        Console.WriteLine("Detect Duplicate Records in CSV\n");

        string csvPath = CreateDummyCsvWithDuplicates();
        DetectDuplicates(csvPath);

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
