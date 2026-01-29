using System;
using System.IO;
using System.Text;

public class EncryptDecryptCsvDemo
{
    private const int Shift = 3;

    private static string Encrypt(string input)
    {
        StringBuilder result = new StringBuilder();

        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                char baseChar = char.IsUpper(c) ? 'A' : 'a';
                result.Append((char)(((c - baseChar + Shift) % 26) + baseChar));
            }
            else if (char.IsDigit(c))
            {
                result.Append((char)(((c - '0' + Shift) % 10) + '0'));
            }
            else
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }

    private static string Decrypt(string input)
    {
        StringBuilder result = new StringBuilder();

        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                char baseChar = char.IsUpper(c) ? 'A' : 'a';
                result.Append((char)(((c - baseChar - Shift + 26) % 26) + baseChar));
            }
            else if (char.IsDigit(c))
            {
                result.Append((char)(((c - '0' - Shift + 10) % 10) + '0'));
            }
            else
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }

    private static string CreateEncryptedCsv()
    {
        string fileName = "employees_secure.csv";

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine("ID,Name,Department,EncryptedSalary");
            writer.WriteLine($"101,Rahul,IT,{Encrypt("65000")}");
            writer.WriteLine($"102,Priya,HR,{Encrypt("52000")}");
            writer.WriteLine($"103,Aman,Sales,{Encrypt("48000")}");
        }

        Console.WriteLine("Encrypted CSV file created.");
        return fileName;
    }

    private static void ReadAndDecryptCsv(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        using (StreamReader reader = new StreamReader(filePath))
        {
            reader.ReadLine(); // skip header

            Console.WriteLine("\nDecrypted Employee Data:");
            Console.WriteLine("ID   Name     Dept     Salary");

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] cols = line.Split(',');
                if (cols.Length != 4)
                    continue;

                string decryptedSalary = Decrypt(cols[3]);

                Console.WriteLine(
                    $"{cols[0],-4} {cols[1],-8} {cols[2],-8} {decryptedSalary}"
                );
            }
        }
    }

    public static void Main()
    {
        Console.WriteLine("CSV Encryption & Decryption Demo\n");

        string csvPath = CreateEncryptedCsv();
        ReadAndDecryptCsv(csvPath);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
