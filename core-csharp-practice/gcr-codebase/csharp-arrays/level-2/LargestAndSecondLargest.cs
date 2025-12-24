using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_array.level_2
{
    internal class LargestAndSecondLargest
    {
        static void Main(string[] args)
        {
            // taking user input
            Console.WriteLine("Enter a natural number: ");
            int num = int.Parse(Console.ReadLine());

            int maxNumOfdigit = 10;
            int[] digit = new int[maxNumOfdigit];
            int count = 0;

            // storing digits in array
            while (num > 0)
            {

                digit[count] = num % 10;
                count++;
                num /= 10;

                if (count == maxNumOfdigit)
                {
                    break;
                }
            }

            int largest = int.MinValue;
            int secondLargest = int.MinValue;

            // finding largest and second largest digit
            for (int i = 0; i < count; i++)
            {
                if (digit[i] > largest)
                {
                    secondLargest = largest;
                    largest = digit[i];
                }
                else if (digit[i] > secondLargest && digit[i] != largest)
                {
                    secondLargest = digit[i];
                }
            }

            // displaying the result
            Console.WriteLine("Largest digit: " + largest);
            Console.WriteLine("Second Largest digit: " + secondLargest);

        }
    }
}
