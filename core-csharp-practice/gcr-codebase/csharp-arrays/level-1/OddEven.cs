using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_array.level_1
{
    internal class OddEven
    {
        static void Main(string[] args)
        {
            // asking user to enter the number
            Console.WriteLine("Enter a naturtal number: ");
            int num = int.Parse(Console.ReadLine());

            // checking the number entered is natural or not
            if (num <= 0)
            {
                Console.WriteLine("Please enter a natural number.");
                return;
            }

            // creating arrays
            int[] evenNumber = new int[num / 2 + 1];
            int[] oddNumbers = new int[num / 2 + 1];

            int eIndex = 0;
            int oIndex = 0;

            for (int l = 1; l <= num; l++)
            {
                if (l % 2 == 0)
                {
                    evenNumber[eIndex] = l;
                    eIndex++;
                }
                else
                {
                    oddNumbers[oIndex] = l;
                    oIndex++;
                }
            }

            // displaying even numbers
            Console.WriteLine("Even Numbers:");
            for (int m = 0; m < eIndex; m++)
            {
                Console.WriteLine(evenNumber[m]);
            }

            // displaying odd numbers
            Console.WriteLine("Odd Numbers:");
            for (int n = 0; n < oIndex; n++)
            {
                Console.WriteLine(oddNumbers[n]);
            }
        }
    }
}