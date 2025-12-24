using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_array.level_1
{
    internal class NumberAnalysis
    {
        static void Main(string[] args)
        {
            int[] num = new int[5];

            // Method to take input for the array
            for (int j = 0; j < num.Length; j++)
            {
                Console.Write("Enter number " + (j + 1) + ": ");
                num[j] = int.Parse(Console.ReadLine());
            }

            // Method to analyze each number in the array
            for (int i = 0; i < num.Length; i++)
            {
                int n = num[i];
                if (n > 0)
                {
                    if (n % 2 == 0)
                    {
                        Console.WriteLine(n + " is a positive even number.");
                    }
                    else
                    {
                        Console.WriteLine(n + " is a positive odd number.");
                    }
                }
                else if (n < 0)
                {
                    Console.WriteLine(n + " is a negative number.");
                }
                else
                {
                    Console.WriteLine("The number is zero.");
                }
            }

            // comparing first and last elements
            int first = num[0]; ;
            int last = num[num.Length - 1];

            if (first == last)
            {
                Console.WriteLine("First and last elemenst are equal");
            }
            else if (first > last)
            {
                Console.WriteLine("First element is greater than last element");
            }
            else
            {
                Console.WriteLine("Last element is greater than first element");
            }
        }
    }

}
