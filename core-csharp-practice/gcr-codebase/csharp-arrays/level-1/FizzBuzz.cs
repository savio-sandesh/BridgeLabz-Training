using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_array.level_1
{
    internal class FizzBuzz
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive number:");
            int num=int.Parse(Console.ReadLine());

            if(num<=0)
            {
                Console.WriteLine("Please enter a valid positive number.");
                return;
            }

            string[] results = new string[num + 1];

            for (int i = 1; i <= num; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    results[i] = "FizzBuzz";
                }
                else if (i % 3 == 0)
                {
                    results[i] = "Fizz";
                }
                else if (i % 5 == 0)
                {
                    results[i] = "Buzz";
                }
                else
                {
                    results[i] = i.ToString();
                }
            }

            for (int i = 1; i <= num; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}
