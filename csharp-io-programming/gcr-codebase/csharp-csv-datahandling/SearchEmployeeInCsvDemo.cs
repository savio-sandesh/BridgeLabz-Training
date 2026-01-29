using System;
using System.IO;

public class SearchEmployeeInCsvDemo
{
    private static string GenerateEmployeeCsv()
    {
        string filePath = "employees_lookup.csv";

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("ID,Name,Department,Salary");
            writer.WriteLine("501,Arjun Mehta,IT,68000");
            writer.WriteLine("502,Kavya Nair,HR,54000");
            writer.WriteLine("503,Rohan Das,Sales,49000");
            writer.WriteLine("504,Ishita Gupta,Finance,72000");
            writer.WriteLine("505,Manish Rao,IT,83000");
        }

        Console.WriteLine("Employee CSV file generated.");
        return filePath;
    }

    private static void SearchEmployeeByName(string csvFile, string keyword)
    {
        if (!File.Exists(csvFile))
        {
            Console.WriteLine("CSV file not found.");
            return;
        }

        bool matchFound = false;

        using (StreamReader reader = new StreamReader(csvFile))
        {
            reader.ReadLine(); // skip header
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] cols = line.Split(',');
                if (cols.Length != 4)
                    continue;

                if (cols[1].IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    matchFound = true;
                    Console.WriteLine(
                        $"Department: {cols[2]}, Salary: {cols[3]}"
                    );
                }
            }
        }

        if (!matchFound)
        {
            Console.WriteLine($"No employee found matching name: {keyword}");
        }
    }

    public static void Main()
    {
        Console.WriteLine("Search Employee Record in CSV\n");

        string csvPath = GenerateEmployeeCsv();

        string searchKeyword = "Arjun"; // fixed keyword for demo
        SearchEmployeeByName(csvPath, searchKeyword);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
