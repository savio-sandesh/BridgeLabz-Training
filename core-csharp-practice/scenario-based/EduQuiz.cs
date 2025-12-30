using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// EduQuiz – Student Quiz Grader
// This program evaluates a 10-question quiz by comparing
// student answers with correct answers in a case-insensitive manner.
// It provides question-wise feedback, calculates total score,
// computes percentage, and displays pass/fail result.


namespace BridgeLabzTraining.scenario_based
{
    internal class EduQuiz
    {
        static  void Main(string[] args)

        {   
            // initialized array with the sample data for testing quiz evaluation 
            // sample correct answers for the quiz
            string[] correctAnswers = {"A", "C", "B", "D", "A", "B", "C", "D", "A", "B" };

            // sample student answers 
            string[] studentAnswers = { "a", "d", "a", "d", "a", "b", "c", "d", "a", "b" };

            // creating an object of Eduquiz to call the non static method
            EduQuiz quiz = new EduQuiz();

            // calculating the total score based on answer comparison
            int score = quiz.CalculateScore(correctAnswers, studentAnswers);

            // total number of questions
            int questionCount = correctAnswers.Length;

            // calculating percentage score
            double percentage = (score / (double)questionCount) * 100;

            Console.WriteLine("Percentage: " + percentage.ToString("0.00") + "%");

            // minimum percentage required to pass
            double passingThreshold = 33.0;

            if (percentage<passingThreshold)
            {
                Console.WriteLine("Sorry to say, You got failed.");
            }
            else
            {
                Console.WriteLine("Hurrah! You got passed.");
            }
        }

        // This method compares correct answers with student answers
        // in a case-insensitive manner, prints question-wise feedback,
        // and returns the total score
        int CalculateScore(string[] correct, string[] student)
        {
            // variable to store count of correct answers
            int score = 0;

            for(int k = 0; k < correct.Length; k++)
            {
                // case insensitive comaparison of answers
                if (correct[k].Equals(student[k], StringComparison.OrdinalIgnoreCase))
                {
                    score += 1;
                    Console.WriteLine("Question " + (k+1) + " is correct");
                }
                else
                {
                    Console.WriteLine("Question " + (k+1) + " is incorrect");
                }
            }
            return score;
        }
    }
}
