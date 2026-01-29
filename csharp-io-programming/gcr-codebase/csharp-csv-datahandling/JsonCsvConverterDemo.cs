using System;
using System.IO;
using System.Text;

public class JsonCsvConverterDemo
{
    private static void ConvertJsonToCsv(string jsonFile, string csvFile)
    {
        if (!File.Exists(jsonFile))
        {
            Console.WriteLine("JSON file not found.");
            return;
        }

        string json = File.ReadAllText(jsonFile).Trim();

        json = json.TrimStart('[').TrimEnd(']');
        string[] records = json.Split(new string[] { "},{" }, StringSplitOptions.RemoveEmptyEntries);

        using (StreamWriter writer = new StreamWriter(csvFile))
        {
            writer.WriteLine("ID,Name,Age");

            foreach (string record in records)
            {
                string clean = record.Replace("{", "").Replace("}", "");
                string[] fields = clean.Split(',');

                string id = "", name = "", age = "";

                foreach (string field in fields)
                {
                    string[] kv = field.Split(':');
                    if (kv.Length != 2) continue;

                    string key = kv[0].Trim().Replace("\"", "");
                    string value = kv[1].Trim().Replace("\"", "");

                    if (key == "id") id = value;
                    if (key == "name") name = value;
                    if (key == "age") age = value;
                }

                writer.WriteLine($"{id},{name},{age}");
            }
        }

        Console.WriteLine("JSON to CSV conversion completed.");
    }

    private static void ConvertCsvToJson(string csvFile, string jsonFile)
    {
        if (!File.Exists(csvFile))
        {
            Console.WriteLine("CSV file not found.");
            return;
        }

        StringBuilder jsonBuilder = new StringBuilder();
        jsonBuilder.AppendLine("[");

        using (StreamReader reader = new StreamReader(csvFile))
        {
            reader.ReadLine(); // skip header
            string line;
            bool first = true;

            while ((line = reader.ReadLine()) != null)
            {
                string[] cols = line.Split(',');
                if (cols.Length != 3) continue;

                if (!first)
                    jsonBuilder.AppendLine(",");

                jsonBuilder.AppendLine("  {");
                jsonBuilder.AppendLine($"    \"id\": {cols[0]},");
                jsonBuilder.AppendLine($"    \"name\": \"{cols[1]}\",");
                jsonBuilder.AppendLine($"    \"age\": {cols[2]}");
                jsonBuilder.Append("  }");

                first = false;
            }
        }

        jsonBuilder.AppendLine();
        jsonBuilder.AppendLine("]");

        File.WriteAllText(jsonFile, jsonBuilder.ToString());
        Console.WriteLine("CSV to JSON conversion completed.");
    }

    public static void Main()
    {
        Console.WriteLine("JSON ↔ CSV Conversion Demo\n");

        string jsonInput = "students.json";
        string csvOutput = "students.csv";
        string jsonOutput = "students_converted.json";

        ConvertJsonToCsv(jsonInput, csvOutput);
        ConvertCsvToJson(csvOutput, jsonOutput);

        Console.WriteLine("\nFiles generated:");
        Console.WriteLine(csvOutput);
        Console.WriteLine(jsonOutput);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
