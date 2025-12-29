using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

// The program analyzes a week’s temperature data where each day contains
// hourly temperature readings stored in a 2D array.
// It calculates the average temperature for each day and determines
// the hottest and coldest day based on these averages.

// Program Workflow:
// 1. Store weekly temperature data in a 2D array (7 days × 24 hours).
// 2. Traverse each day and calculate the sum of hourly temperatures.
// 3. Compute the average temperature for each day.
// 4. Display the average temperature for every day.
// 5. Compare daily averages to identify the hottest day.
// 6. Compare daily averages to identify the coldest day.
// 7. Display the hottest and coldest day along with their average temperatures.



namespace BridgeLabzTraining.scenario_based
{
    internal class TemperatureAnalyzer
    {
        static void TemperatureAnalysis(float[][] temperatures)
        {

            // variables to track hottest and coldest day averages
            float avgOfHottestDays = float.MinValue;
            float avgOfColdestDays = float.MaxValue;

            // variables to track day numbers(hottest and coldest)
            int numberofHottestDays = 0;
            int numberofColdestDays = 0;

            for (int k = 0; k < temperatures.Length; k++)
            {
                float dailySum = 0;

                // calculating sum of temperatures for the day
                for (int j = 0; j < temperatures[k].Length; j++)
                {
                    dailySum += temperatures[k][j];
                }

                // calculating average temperature for the day
                float dailyAvg = dailySum / temperatures[k].Length;

                Console.WriteLine($"Day {k + 1} - Average Temperature: {dailyAvg}°C");

                // check if this day is hottest so far
                if (dailyAvg > avgOfHottestDays)
                {
                    avgOfHottestDays = dailyAvg;
                    numberofHottestDays = k + 1;
                }
                // check if this day is hottest so far
                if (dailyAvg < avgOfColdestDays)
                {
                    avgOfColdestDays = dailyAvg;
                    numberofColdestDays = k + 1;
                }
            }

            Console.WriteLine($"\nHottest Day Average Temperature: {avgOfHottestDays}°C");
            Console.WriteLine($"Coldest Day Average Temperature: {avgOfColdestDays}°C");

        }

        static void Main(string[] args)
        {
            // Sample temperature data for a week (7 days),
            // each day has 24 temperature readings
            float[][] weeklyTemperatures = new float[][]
            {
                new float[24] { 22, 24, 26, 28, 30, 32, 31, 29, 27, 25, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10 },
                new float[24] { 22, 23, 25, 27, 29, 31, 30, 28, 26, 24, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9 },
                new float[24] { 27, 29, 31, 33, 35, 37, 36, 34, 32, 30, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15 },
                new float[24] { 19, 21, 23, 25, 27, 29, 28, 26, 24, 22, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7 },
                new float[24] { 13, 15, 17, 19, 21, 23, 22, 20, 18, 16, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 },
                new float[24] { 14, 16, 18, 20, 22, 24, 23, 21, 19, 17, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 },
                new float[24] { 25, 27, 29, 31, 33, 35, 34, 32, 30, 28, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13 }
        };
            TemperatureAnalysis(weeklyTemperatures);
        }
    }
}


