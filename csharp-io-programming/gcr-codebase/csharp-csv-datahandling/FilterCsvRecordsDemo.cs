using System;
using System.IO;

public class FilterCsvRecordsDemo
{
    private static string CreateDummyStudentsCsv()
    {
        string fileName = "students_filter.csv";

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine("ID,Name,Age,Marks");
            writer.WriteLine("101,Rahul,20,85");
            writer.WriteLine("102,Priya,19,92");
            writer.WriteLine("103,Aman,21,78");
            writer.WriteLine("104,Sneha,18,88");
            writer.WriteLine("105,Vikram,22,65");
            writer.WriteLine("106,Anjali,20,79");
            writer.WriteLine("107,Rohit,19,82");
        }

        Console.WriteLine("Student CSV file created.");
        return fileName;
    }

    private static void FilterHighScorers(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        Console.WriteLine("\nStudents scoring more than 80 marks:\n");

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

                if (!int.TryParse(cols[3], out int marks))
                    continue;

                if (marks > 80)
                {
                    Console.WriteLine(
                        $"{cols[0]} | {cols[1]} | Age: {cols[2]} | Marks: {marks}"
                    );
                }
            }
        }
    }

    public static void Main()
    {
        Console.WriteLine("Filter CSV Records (Marks > 80)\n");

        string csvPath = CreateDummyStudentsCsv();
        FilterHighScorers(csvPath);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
