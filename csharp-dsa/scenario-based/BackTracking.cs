using System;
using System.Diagnostics;

namespace Training.BackTracking
{
    public class PasswordCracker
    {
        private readonly char[] _characters;
        private readonly int _length;

        public PasswordCracker(char[] characters, int length)
        {
            _characters = characters;
            _length = length;
        }

        public void GenerateAll()
        {
            char[] buffer = new char[_length];
            GenerateRecursive(0, buffer);
        }

        private void GenerateRecursive(int index, char[] buffer)
        {
            if (index == _length)
            {
                Console.WriteLine(new string(buffer));
                return;
            }

            for (int i = 0; i < _characters.Length; i++)
            {
                buffer[index] = _characters[i];
                GenerateRecursive(index + 1, buffer);
            }
        }

        public bool Crack(string target, out string result)
        {
            char[] buffer = new char[_length];
            return CrackRecursive(0, buffer, target, out result);
        }

        private bool CrackRecursive(int index, char[] buffer, string target, out string result)
        {
            result = string.Empty;

            if (index == _length)
            {
                string attempt = new string(buffer);
                if (attempt == target)
                {
                    result = attempt;
                    return true;
                }
                return false;
            }

            for (int i = 0; i < _characters.Length; i++)
            {
                buffer[index] = _characters[i];
                if (CrackRecursive(index + 1, buffer, target, out result))
                {
                    return true;
                }
            }

            return false;
        }

        public void ShowComplexity()
        {
            long total = (long)Math.Pow(_characters.Length, _length);
            Console.WriteLine($"Time Complexity : O(k^n)");
            Console.WriteLine($"Total Combinations : {total}");
            Console.WriteLine($"Space Complexity : O(n)");
        }
    }

    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter password length (default 3): ");
            int length = int.TryParse(Console.ReadLine(), out int l) ? l : 3;

            Console.Write("Enter character set (default abc): ");
            string input = Console.ReadLine();
            char[] charset = string.IsNullOrEmpty(input)
                ? new[] { 'a', 'b', 'c' }
                : input.ToCharArray();

            PasswordCracker cracker = new PasswordCracker(charset, length);

            while (true)
            {
                Console.WriteLine("\n--- Password Cracker Menu ---");
                Console.WriteLine("1. Generate all possible passwords");
                Console.WriteLine("2. Crack a target password");
                Console.WriteLine("3. View time and space complexity");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nScenario A: Generating passwords");
                        cracker.GenerateAll();
                        break;

                    case "2":
                        Console.Write("\nEnter target password: ");
                        string target = Console.ReadLine();

                        Stopwatch sw = Stopwatch.StartNew();
                        if (cracker.Crack(target, out string found))
                        {
                            Console.WriteLine($"Password cracked: {found}");
                        }
                        else
                        {
                            Console.WriteLine("Password not found");
                        }
                        sw.Stop();

                        Console.WriteLine($"Time taken: {sw.ElapsedMilliseconds} ms");
                        break;

                    case "3":
                        Console.WriteLine("\nScenario C: Complexity Analysis");
                        cracker.ShowComplexity();
                        break;

                    case "0":
                        Console.WriteLine("Exiting program.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}
