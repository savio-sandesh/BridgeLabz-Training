using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_extras.practice_problem_2
{
    internal class NumberGuessingGame
    {
        static void Main(string[] args)
        {
            int minimum = 1;
            int maximum = 100;
            bool correctGuess = false;

            Console.WriteLine("Think a number between 1 and 100: ");
            Console.WriteLine("Enter Low(M), High(X), Correct(C).");

            while (!correctGuess)
            {
                if (minimum > maximum)
                {
                    Console.WriteLine("Inconsistent answers detected.");
                    break;
                }

                int currentGuess = GenerateGuess(minimum, maximum);
                Console.WriteLine($"Is your number {currentGuess}?");

                char userReply = ReadUserReply();
                correctGuess = AdjustLimits(userReply, ref minimum, ref maximum, currentGuess);

            }

        }
        static int GenerateGuess(int min, int max)
        {
            return (min + max) / 2;

        }

        static char ReadUserReply()
        {
            char input = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();
            return input;
        }

        static bool AdjustLimits(char reply, ref int min, ref int max, int guess)
        {
            switch (reply)
            {
                case 'M':
                    min = guess + 1;
                    return false;
                case 'X':
                    max = guess - 1;
                    return false;
                case 'C':
                    Console.WriteLine("\nYay! I guessed your number!");
                    return true;
                default:
                    Console.WriteLine("\nInvalid input. Please enter M, X, or C.");
                    return false;
            }
        }
    }
}