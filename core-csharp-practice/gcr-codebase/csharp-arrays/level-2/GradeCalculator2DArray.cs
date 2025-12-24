//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BridgeLabzTraining.csharp_array.level_2
//{
//    internal class GradeCalculator2DArray
//    {
//        static void Main(string[] args)
//        {
//            // taking input for number of students
//            Console.Write("Enter number of students: ");
//            int n = int.Parse(Console.ReadLine());

//            // declaring 2D array to store marks
//            int[][] marks = new int[n][];
//            double[] percentages = new double[n];
//            char[] grades = new char[n];


//            // taking input for marks
//            for (int p = 0; p < n; p++)
//            {
//                marks[p] = new int[3];
//                Console.WriteLine("Enter student marks in Physics: ");
//                marks[p][0] = int.Parse(Console.ReadLine());
//                Console.WriteLine("Enter student marks in Chemistry: ");
//                marks[p][1] = int.Parse(Console.ReadLine());
//                Console.WriteLine("Enter student marks in Mathematics: ");
//                marks[p][2] = int.Parse(Console.ReadLine());
//                if (marks[p][0] < 0 || marks[p][0] > 100 ||
//                    marks[p][1] < 0 || marks[p][1] > 100 ||
//                    marks[p][2] < 0 || marks[p][2] > 100)
//                {
//                    Console.WriteLine("Invalid marks entered. Please enter marks between 0 and 100.");
//                    p--; // decrement p to repeat input for the same student
//                }
//            }
//            // calculating percentage and grade
//            for (int q = 0; q < n; q++)
//            {
//                percentages[q] = (marks[q][0] + marks[q][1] + marks[q][2]) / 3.0;
//                if (percentages[q] >= 80)
//                {
//                    grades[q] = 'A';
//                }
//                else if (percentages[q] >= 70)
//                {
//                    grades[q] = 'B';
//                }
//                else if (percentages[q] >= 60)
//                {
//                    grades[q] = 'C';
//                }
//                else if (percentages[q] >= 50)
//                {
//                    grades[q] = 'D';
//                }
//                else if (percentages[q] >= 40)
//                {
//                    grades[q] = 'E';
//                }
//                else
//                {
//                    grades[q] = 'R';
//                }
//            }
//            // displaying results
//            for (int r = 0; r < n; r++)
//            {
//                Console.WriteLine($"Student {r + 1}: Percentage = {percentages[r]:F2}%, Grade = {grades[r]}");
//            }
//        }
//    }
//}
