using System;
using System.IO;
using System.Collections.Generic;

public class MergeCsvFilesByIdDemo
{
    private class StudentBasic
    {
        public int Id { get; }
        public string Name { get; }
        public int Age { get; }

        public StudentBasic(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
    }

    private static void CreateDummyFiles()
    {
        using (StreamWriter w1 = new StreamWriter("students1.csv"))
        {
            w1.WriteLine("ID,Name,Age");
            w1.WriteLine("101,Rahul,20");
            w1.WriteLine("102,Priya,19");
            w1.WriteLine("103,Aman,21");
        }

        using (StreamWriter w2 = new StreamWriter("students2.csv"))
        {
            w2.WriteLine("ID,Marks,Grade");
            w2.WriteLine("101,85,A");
            w2.WriteLine("102,92,A+");
            w2.WriteLine("103,78,B");
        }

        Console.WriteLine("Dummy CSV files created.");
    }

    private static void MergeCsvFiles(string file1, string file2, string outputFile)
    {
        Dictionary<int, StudentBasic> studentMap = new Dictionary<int, StudentBasic>();

        using (StreamReader reader1 = new StreamReader(file1))
        {
            reader1.ReadLine(); // skip header
            string line;

            while ((line = reader1.ReadLine()) != null)
            {
                string[] cols = line.Split(',');
                if (cols.Length != 3)
                    continue;

                if (!int.TryParse(cols[0], out int id) ||
                    !int.TryParse(cols[2], out int age))
                    continue;

                studentMap[id] = new StudentBasic(id, cols[1], age);
            }
        }

        using (StreamReader reader2 = new StreamReader(file2))
        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            writer.WriteLine("ID,Name,Age,Marks,Grade");

            reader2.ReadLine(); // skip header
            string line;

            while ((line = reader2.ReadLine()) != null)
            {
                string[] cols = line.Split(',');
                if (cols.Length != 3)
                    continue;

                if (!int.TryParse(cols[0], out int id))
                    continue;

                if (studentMap.ContainsKey(id))
                {
                    StudentBasic s = studentMap[id];
                    writer.WriteLine(
                        $"{s.Id},{s.Name},{s.Age},{cols[1]},{cols[2]}"
                    );
                }
            }
        }

        Console.WriteLine($"Merged CSV created: {outputFile}");
    }

    public static void Main()
    {
        Console.WriteLine("Merge Two CSV Files by ID\n");

        CreateDummyFiles();

        string outputFile = "merged_students.csv";
        MergeCsvFiles("students1.csv", "students2.csv", outputFile);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
