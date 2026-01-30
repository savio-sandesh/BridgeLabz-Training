using System;

public class AadharSorter
{
    private readonly string[] _aadharNumbers;

    public AadharSorter(string[] aadharNumbers)
    {
        _aadharNumbers = aadharNumbers;
    }

    public void SortAscending()
    {
        for (int digit = 0; digit < 12; digit++)
        {
            CountingSortByDigit(digit);
        }
    }

    private void CountingSortByDigit(int position)
    {
        int n = _aadharNumbers.Length;
        string[] output = new string[n];
        int[] count = new int[10];

        for (int i = 0; i < n; i++)
        {
            int digit = _aadharNumbers[i][11 - position] - '0';
            count[digit]++;
        }

        for (int i = 1; i < 10; i++)
        {
            count[i] += count[i - 1];
        }

        for (int i = n - 1; i >= 0; i--)
        {
            int digit = _aadharNumbers[i][11 - position] - '0';
            output[count[digit] - 1] = _aadharNumbers[i];
            count[digit]--;
        }

        Array.Copy(output, _aadharNumbers, n);
    }

    public int BinarySearch(string target)
    {
        int left = 0;
        int right = _aadharNumbers.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int cmp = string.Compare(_aadharNumbers[mid], target);

            if (cmp == 0) return mid;
            if (cmp < 0) left = mid + 1;
            else right = mid - 1;
        }

        return -1;
    }

    public void Display()
    {
        foreach (string num in _aadharNumbers)
        {
            Console.WriteLine(num);
        }
    }
}

public class Program
{
    public static void Main()
    {
        Console.Write("Enter number of Aadhar numbers (default 5): ");
        int count = int.TryParse(Console.ReadLine(), out int c) ? c : 5;

        string[] aadharNumbers = new string[count];

        for (int i = 0; i < count; i++)
        {
            while (true)
            {
                Console.Write($"Enter Aadhar {i + 1} (12 digits): ");
                string input = Console.ReadLine();

                if (IsValidAadhar(input))
                {
                    aadharNumbers[i] = input;
                    break;
                }

                Console.WriteLine("❌ Invalid Aadhar number. Must be exactly 12 digits.");
            }
        }

        AadharSorter sorter = new AadharSorter(aadharNumbers);

        Console.WriteLine("\nScenario A: Sorting Aadhar numbers");
        sorter.SortAscending();
        sorter.Display();

        Console.Write("\nScenario B: Enter Aadhar number to search: ");
        string target = Console.ReadLine();

        int index = sorter.BinarySearch(target);
        Console.WriteLine(index != -1
            ? $"Aadhar found at position {index + 1}"
            : "Aadhar not found");

        Console.WriteLine("\nScenario C: Stability maintained by Radix Sort");
    }

    private static bool IsValidAadhar(string input)
    {
        if (string.IsNullOrEmpty(input) || input.Length != 12)
            return false;

        foreach (char c in input)
        {
            if (c < '0' || c > '9')
                return false;
        }

        return true;
    }
}
