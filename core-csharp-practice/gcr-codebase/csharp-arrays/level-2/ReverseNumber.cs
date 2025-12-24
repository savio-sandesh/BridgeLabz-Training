using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_array.level_2
{
    internal class ReverseNumber
    {
        static void Main(string[] args)
        {
            // asking user to  the number 
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

            // array to  store reversed digit
            int[] reversedDigitArray = new int[count];

            for (int m = 0; m < count; m++)
            {
                reversedDigitArray[m] = digitArray[count - 1 - m];
            }

            //displaying reversed digit number
            Console.WriteLine("Reversed Number:");
            for (int k = 0; k < count; k++)
            {
                Console.Write(reversedDigitArray[k]);
            }
        }
    }
}
