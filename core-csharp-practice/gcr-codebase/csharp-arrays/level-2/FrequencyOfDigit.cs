using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_array.level_2
{
    internal class FrequencyOfDigit
    {
        static void Main(string[] args)
        {
            // asking user to enter a number
            Console.WriteLine("Enter a number: ");
            int num = int.Parse(Console.ReadLine());
            int n = num;

            // counting number of digits
            int count = 0;
            while (n > 0)
            {
                count++;
                n /= 10;
            }

            // creating array to store digits
            int[] digitArray = new int[count];

            // storing digits in array
            for (int l = 0; l < count; l++)
            {
                digitArray[l] = num % 10;
                num /= 10;
            }

            // freuency array for digits 0-9
            int[] frequency = new int[10];

            // calculating frequency of each digit
            for (int i = 0; i < count; i++)
            {
                frequency[digitArray[i]]++;

            }

            // displaying frequency of each digit
            for (int d = 0; d < 10; d++)
            {
                if (frequency[d] > 0)
                {
                    Console.WriteLine("Digit " + d + " occurs " + frequency[d] + " times.");
                }
            }
        }
    }
}