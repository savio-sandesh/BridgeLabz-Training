using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_array.level_2
{
    internal class Bmi2DArray
    {
        static void Main(string[] args)
        {
            //taking input for number of people
            Console.Write("Enter number of people: ");
            int n = int.Parse(Console.ReadLine());

            //declaring 2D array to store weight and height
            double[][] personData = new double[n][];
            string[] weightStatus = new string[n];

            //taking input for weight and height
            for (int k = 0; k < n; k++)
            {

                personData[k] = new double[3];

                double weight;
                do
                {
                    weight = double.Parse(Console.ReadLine());
                } while (weight <= 0);

                double height;
                do
                {
                    height = double.Parse(Console.ReadLine());
                } while (height <= 0);


                personData[k][0] = weight;
                personData[k][1] = height;
            }

            //calculating BMI and determining weight status
            for (int q = 0; q < n; q++)
            {
                double heightInMeters = personData[q][1] / 100; // converting height from cm to m
                double bmi = personData[q][0] / (heightInMeters * heightInMeters);
                personData[q][2] = bmi;
                if (bmi < 18.5)
                {
                    weightStatus[q] = "Underweight";
                }
                else if (bmi >= 18.5 && bmi <= 24.9)
                {
                    weightStatus[q] = "Normal weight";
                }
                else if (bmi >= 25 && bmi <= 39.9)
                {
                    weightStatus[q] = "Overweight";
                }
                else
                {
                    weightStatus[q] = "Obesity";
                }

               
            }
            //displaying results
            for (int r = 0; r < n; r++)
            {
                Console.WriteLine($"Person {r + 1}: Weight = {personData[r][0]} kg, Height = {personData[r][1]} cm, BMI = {personData[r][2]:F2}, Status = {weightStatus[r]}");
            }
        }
    }
}