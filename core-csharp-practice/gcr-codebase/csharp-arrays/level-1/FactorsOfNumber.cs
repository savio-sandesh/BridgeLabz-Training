using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_array.level_1
{
    internal class FactorsOfNumber
    {
        static void Main(string[] args)
        {
            // taking input from user
            Console.WriteLine("Enter a natural number: ");
            int num=int.Parse(Console.ReadLine());


            // initializing array to store factors
            int maxFactor = 10;
            int[] factors = new int[maxFactor];
            int count = 0;

            // finding factors 
            for (int p = 1; p <= num; p++)
            {
                if (num % p == 0)
                {
                    if (count == maxFactor)
                    {
                        maxFactor *= 2;
                        int[] temp = new int[maxFactor];

                        // copying old factors to new array
                        for (int i = 0; i < count; i++)
                        {
                            temp[i] = factors[i];
                        }
                        factors = temp;
                    }
                    factors[count] = p;
                    count++;
                }
            }

                    // displaying result 
                    Console.WriteLine("Factors of " + num + " are: ");
                    for (int k = 0; k < count; k++)
                    {
                        Console.WriteLine(factors[k]);
                    }
                }
            }

        }
    

