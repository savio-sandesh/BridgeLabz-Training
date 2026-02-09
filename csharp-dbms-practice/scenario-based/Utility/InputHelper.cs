using System;

namespace Utility
{
    public static class InputHelper
    {
        public static int ReadInt(string message)
        {
            int value;
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (input != null && int.TryParse(input, out value))
                {
                    return value;
                }
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        public static string ReadString(string message)
        {
            string value;
            while (true)
            {
                Console.Write(message);
                value = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(value))
                {
                    return value;
                }
                Console.WriteLine("Invalid input. Please enter a non-empty string.");
            }
        }

        public static DateTime ReadDate(string message)
        {
            DateTime value;
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (input != null && DateTime.TryParse(input, out value))
                {
                    return value;
                }
                Console.WriteLine("Invalid input. Please enter a valid date (e.g., YYYY-MM-DD).");
            }
        }

        public static decimal ReadDecimal(string message)
        {
            decimal value;
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (input != null && decimal.TryParse(input, out value))
                {
                    return value;
                }
                Console.WriteLine("Invalid input. Please enter a valid decimal number.");
            }
        }
    }
}
