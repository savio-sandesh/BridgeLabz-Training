using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_array.level_2
{
    internal class LargestAndSecondLargest2
    {
        static void Main(string[] args)
        {
            // taking user input
            Console.WriteLine("Enter a natural number: ");
            int num = int.Parse(Console.ReadLine());

            int maxNumOfdigit = 10;
            int[] digit = new int[maxNumOfdigit];
            int count = 0;

            // storing digits in array(dynamic array resizing)
            while (num > 0)
            {
                if (count == maxNumOfdigit)
                {
                    // Resize the array if needed
                    maxNumOfdigit += 10;
                    int[] temp = new int[maxNumOfdigit];
                    for (int i = 0; i < count; i++)
                    {
                        temp[i] = digit[i];
                    }
                    digit = temp;
                }
                digit[count] = num % 10;
                count++;
                num /= 10;
            }

            int largest = 0;
            int secondLargest = 0;

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
