using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_array.level_2
{
    internal class GradeCalculator
    {
        static void Main(string[] args)
        {
            // taking input for number of students
            Console.Write("Enter number of students: ");
            int n = int.Parse(Console.ReadLine());

            // declaring array to store marks
            int[] physics = new int[n];
            int[] chemistry = new int[n];
            int[] mathematics = new int[n];
            double[] percentages = new double[n];
            char[] grades = new char[n];

            // taking input for marks
            for (int p = 0; p < n; p++)

            {
                // input marks for each subject
                Console.WriteLine("Enter student marks in Physics: ");
                physics[p] = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter student marks in Chemistry: ");
                chemistry[p] = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter student marks in Mathematics: ");
                mathematics[p] = int.Parse(Console.ReadLine());

                if (physics[p] < 0 || physics[p] > 100 ||
                    chemistry[p] < 0 || chemistry[p] > 100 ||
                    mathematics[p] < 0 || mathematics[p] > 100)
                {
                    Console.WriteLine("Invalid marks entered. Please enter marks between 0 and 100.");
                    p--; // decrement p to repeat input for the same student
                }
            }

            // calculating percentage and grade
            for (int q = 0; q < n; q++)
            {
                percentages[q] = (physics[q] + chemistry[q] + mathematics[q]) / 3.0;
                if (percentages[q] >= 80)
                {
                    grades[q] = 'A';
                }
                else if (percentages[q] >= 70)
                {
                    grades[q] = 'B';
                }
                else if (percentages[q] >= 60)
                {
                    grades[q] = 'C';
                }
                else if (percentages[q] >= 50)
                {
                    grades[q] = 'D';
                }
                else if (percentages[q] >= 40)
                {
                    grades[q] = 'E';
                }
                else
                {
                    grades[q] = 'R';
                }
            }

            // displaying results 
            for (int r = 0; r < n; r++)
            {
                Console.WriteLine($"Student {r + 1}: Percentage = {percentages[r]:F2}%, Grade = {grades[r]}");
            }
        }
    }
}
