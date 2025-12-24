using System;

namespace BridgeLabzTraining.arrays.level_1
{
    internal class EligibilityForVote
    {
        static void Main(string[] args)
        {
            int[] ages = new int[10];

            // take input for ages with validation
            for (int i = 0; i < ages.Length; i++)
            {
                while (true)
                {
                    Console.Write($"Enter age of person {i + 1}: ");
                    string? input = Console.ReadLine();
                    if (int.TryParse(input, out int age))
                    {
                        ages[i] = age;
                        break;
                    }

                    Console.WriteLine("Invalid input. Please enter a valid integer age.");
                }
            }

            // checking eligibility for voting for each age
            for (int j = 0; j < ages.Length; j++)
            {
                if(ages[j] < 0)
{
                    Console.WriteLine("Person " + (j + 1) + ": Invalid Age.");
                }
                else if (ages[j] >= 18)
                {
                    Console.WriteLine("Person " + (j + 1) + " is eligible to vote.");
                }
                else
                {
                    Console.WriteLine("Person " + (j + 1) + " is not eligible to vote.");
                }

            }
        }
    }
}
