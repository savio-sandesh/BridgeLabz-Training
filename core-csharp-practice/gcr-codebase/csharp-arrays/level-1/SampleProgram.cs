using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.arrays.level_1
{
    internal class SampleProgram
    {
        static void Main(string[] args)
        {
            // Take input for a number
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            // Validate the input
            if (number < 0)
            {
                Console.Error.WriteLine("Invalid Number.");
                Environment.Exit(0);
            }
            // Find the count of digits
            int temp = number, count = 0;
            while (temp > 0)
            {
                count++;
                temp /= 10;
            }

            // Find the digits and store them in an array
            int[] digits = new int[count];
            for (int i = 0; i < count; i++)
            {
                digits[i] = number % 10;
                number /= 10;
            }

            // Calculate the sum of the digits
            int sum = 0;
            foreach (int digit in digits)
            {
                sum += digit;
            }

            // Display the sum
            Console.WriteLine($"Sum of Digits: {sum}");

        }
    }
}