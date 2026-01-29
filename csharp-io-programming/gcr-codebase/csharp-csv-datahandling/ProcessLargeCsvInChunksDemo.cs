using System;
using System.IO;

public class ProcessLargeCsvInChunksDemo
{
    private static string GenerateLargeCsvFile()
    {
        string filePath = "large_students_data.csv";

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("ID,Name,Age,Marks");

            for (int i = 1; i <= 1000; i++)
            {
                writer.WriteLine(
                    $"{i},Student{i},{18 + (i % 10)},{50 + (i % 50)}"
                );
            }
        }

        Console.WriteLine("Large CSV file generated (1000 records).");
        return filePath;
    }

    private static void ReadCsvInChunks(string filePath, int batchSize)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("CSV file not found.");
            return;
        }

        int totalProcessed = 0;
        int batchNumber = 0;

        using (StreamReader reader = new StreamReader(filePath))
        {
            reader.ReadLine(); // skip header
            string line;

            while (!reader.EndOfStream)
            {
                batchNumber++;
                int currentBatchCount = 0;

                while (currentBatchCount < batchSize &&
                       (line = reader.ReadLine()) != null)
                {
                    totalProcessed++;
                    currentBatchCount++;
                    // Process record here if needed
                }

                Console.WriteLine(
                    $"Batch {batchNumber} processed. Total records so far: {totalProcessed}"
                );
            }
        }

        Console.WriteLine($"\nTotal records processed: {totalProcessed}");
    }

    public static void Main()
    {
        Console.WriteLine("Efficient Large CSV Processing (Chunk-Based)\n");

        string csvPath = GenerateLargeCsvFile();
        ReadCsvInChunks(csvPath, batchSize: 100);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
