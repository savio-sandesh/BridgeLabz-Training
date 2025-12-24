using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_array.level_1
{
    internal class StoreAndSum
    {
        static void Main(string[] args)
        {
            double [] numbers = new double[10];
            double sum = 0.0;
            int i = 0;

            while (true)
            {
                Console.WriteLine("Enter a number(0 or negative to stop): ");
                double input = double.Parse(Console.ReadLine());

                if (input <= 0)
                {
                    break;
                }

                if (i == 10)
                {
                    break;
                }

                numbers[i] = input;
                i++;
            }

            for(int k = 0; k < i; k++)
            {
                Console.WriteLine(numbers[k]);
                sum += numbers[k];
            }
            Console.WriteLine("Total Sum = " + sum);
        }
    }
}
