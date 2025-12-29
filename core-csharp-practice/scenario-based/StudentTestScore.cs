using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// The program manages student test scores by storing them in an array,
// calculating the average score, identifying the highest and lowest scores,
// displaying scores above the average, and handling invalid input safely.


// Main Workflow:
// 1. Read and validate the number of students.
// 2. Read and validate each student's score and store it in an array.
// 3. Calculate the average score.
// 4. Find the highest score.
// 5. Find the lowest score.
// 6. Display the average, highest, and lowest scores.
// 7. Display all scores that are above the average.

// Method Responsibilities:
// - ReadStudentCount(): Validates and returns the number of students.
// - ReadStudentScores(): Reads and validates scores for each student.
// - CalculateAverage(): Computes the average of all scores.
// - FindHighestScore(): Identifies the highest score.
// - FindLowestScore(): Identifies the lowest score.
// - DisplayResults(): Prints the average, highest, and lowest scores.
// - DisplayScoresAboveAverage(): Prints scores greater than the average.

namespace BridgeLabzTraining.scenario_based
{

    internal class StudentScoreManager
    {
        static void Main(string[] args)
        {
            int studentCount = ReadStudentCount();
            if (studentCount == 0) return;

            double[] scores = ReadStudentScores(studentCount);

            double averageScore = CalculateAverage(scores);
            double highestScore = FindHighestScore(scores);
            double lowestScore = FindLowestScore(scores);

            DisplayResults(averageScore, highestScore, lowestScore);
            DisplayScoresAboveAverage(scores, averageScore);
        }

        // Reads and validates the number of students
        static int ReadStudentCount()
        {
            Console.Write("Enter the number of students: ");

            if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
            {
                Console.WriteLine("Invalid number of students.");
                return 0;
            }

            return count;
        }

        // Reads and validates scores for all students
        static double[] ReadStudentScores(int count)
        {
            double[] scores = new double[count];

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter score for student {i + 1}: ");

                if (!double.TryParse(Console.ReadLine(), out scores[i]) || scores[i] < 0)
                {
                    Console.WriteLine("Invalid score. Please enter a non-negative number.");
                    i--; // retry same student
                }
            }
            return scores;
        }

        // Calculates the average score
        static double CalculateAverage(double[] scores)
        {
            double total = 0;

            for (int i = 0; i < scores.Length; i++)
            {
                total += scores[i];
            }

            return total / scores.Length;
        }

        // Finds the highest score
        static double FindHighestScore(double[] scores)
        {
            double highest = scores[0];

            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] > highest)
                {
                    highest = scores[i];
                }
            }

            return highest;
        }

        // Finds the lowest score
        static double FindLowestScore(double[] scores)
        {
            double lowest = scores[0];

            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] < lowest)
                {
                    lowest = scores[i];
                }
            }

            return lowest;
        }

        // Displays average, highest, and lowest scores
        static void DisplayResults(double average, double highest, double lowest)
        {
            Console.WriteLine("\n--- Score Summary ---");
            Console.WriteLine("Average Score: " + average);
            Console.WriteLine("Highest Score: " + highest);
            Console.WriteLine("Lowest Score: " + lowest);
        }

        // Displays scores that are above the average
        static void DisplayScoresAboveAverage(double[] scores, double average)
        {
            Console.WriteLine("\nScores above average:");

            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] > average)
                {
                    Console.WriteLine(scores[i]);
                }
            }
        }
    }
}
