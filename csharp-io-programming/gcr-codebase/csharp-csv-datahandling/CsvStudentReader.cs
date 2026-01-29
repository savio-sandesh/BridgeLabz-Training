using System;
using System.IO;

public class CsvStudentReader
{
    private static string GenerateStudentCsv()
    {
        string path = "students_data.csv";

        using (StreamWriter writer = new StreamWriter(path))
        {
            writer.WriteLine("101,Arjun,20,85");
            writer.WriteLine("102,Kavya,19,92");
            writer.WriteLine("103,Rohan,21,78");
            writer.WriteLine("104,Ishita,18,88");
            writer.WriteLine("105,Manish,22,65");
            writer.WriteLine("106,Pooja,20,90");
            writer.WriteLine("107,Siddharth,19,72");
            writer.WriteLine("108,Nikita,21,95");

        }

        Console.WriteLine("Student CSV file generated.");
        return path;
    }

    private static void DisplayStudentRecords(string csvFile)
    {
        if (!File.Exists(csvFile))
        {
            Console.WriteLine("Unable to locate CSV file.");
            return;
        }

        using (StreamReader reader = new StreamReader(csvFile))
        {
            reader.ReadLine(); // skip header
            string row;

            Console.WriteLine("\nStudent Details:\n");

            while ((row = reader.ReadLine()) != null)
            {
                string[] data = row.Split(',');
                if (data.Length != 4)
                    continue;

                Console.WriteLine(
                    $"Student ID: {data[0]} | Name: {data[1]} | Age: {data[2]} | Marks: {data[3]}"
                );
            }
        }
    }

    public static void Main()
    {
        Console.WriteLine("CSV File Reading Demo\n");

        string csvPath = GenerateStudentCsv();
        DisplayStudentRecords(csvPath);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
