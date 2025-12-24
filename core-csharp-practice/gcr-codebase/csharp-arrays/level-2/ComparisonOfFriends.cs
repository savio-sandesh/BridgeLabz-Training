using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_array.level_2
{
    internal class ComparisonOfFriends
    {
        static void Main(string[] args)
        {
            string[] friends = { "Amar", "Akbar", "Anthony" };
            int[] age = new int[3];
            double[] height = new double[3];

            // taking user input
            for (int i = 0; i < friends.Length; i++)
            {
                Console.WriteLine($"Enter age of {friends[i]}: ");
                age[i] = int.Parse(Console.ReadLine());
                Console.WriteLine($"Enter height of {friends[i]} in cm: ");
                height[i] = double.Parse(Console.ReadLine());
            }

            // finding youngest and tallest among them
            int youngestIndex = 0;
            int tallestIndex = 0;
            for (int j = 1; j < friends.Length; j++)
            {
                if (age[j] < age[youngestIndex])
                {
                    youngestIndex = j;
                }
                if (height[j] > height[tallestIndex])
                {
                    tallestIndex = j;
                }
            }

            // displaying results
            Console.WriteLine($"{friends[youngestIndex]} is the youngest with age {age[youngestIndex]} years.");
            Console.WriteLine($"{friends[tallestIndex]} is the tallest with height {height[tallestIndex]} cm.");
        }
    }
}
