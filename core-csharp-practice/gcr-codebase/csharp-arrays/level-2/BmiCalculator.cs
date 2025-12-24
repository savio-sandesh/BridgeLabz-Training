using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_array.level_2
{
    internal class BmiCalculator
    {
        static void Main(string[] args)
        {
            // taking input for number of individuals
            Console.WriteLine("Enter number of persons: ");
            int n = int.Parse(Console.ReadLine());

            double[] height = new double[n];
            double[] weight = new double[n];
            double[] bmi = new double[n];
            string[] status = new string[n];

            // taking user input for height and weight
            for (int s= 0; s < n; s++)
            {   
                Console.WriteLine("Enter weight (in kg) of person: ");
                weight[s] = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter height (in cm) of person: ");
                height[s] = double.Parse(Console.ReadLine());
            }

            // bcmi calculation and determining status
            for (int b = 0; b < n; b++)
            {
                double heightInMeter = height[b] / 100;

                bmi[b] = weight[b] / (heightInMeter * heightInMeter);


                if (bmi[b] <= 18.4)
                {
                    status[b] = "Underweight";
                }
                else if (bmi[b] >= 18.5 && bmi[b] <= 24.9)
                {
                    status[b] = "Normal weight";
                }
                else if (bmi[b] >= 25 && bmi[b] <= 39.9)
                {
                    status[b] = "Overweight";
                }
                else
                {
                    status[b] = "Obesity";
                }
            }

            // displaying results
            for (int d = 0; d < n; d++)
            {
                Console.WriteLine("Person " + (d + 1) + ": BMI = " + bmi[d] + ", Status = " + status[d]);
            }

        }
    }
}
