using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_array.level_1
{
    internal class MultiplicationSixtoNine
    {   
        static void Main(string[] args)
        {
            int[] array = new int[4];

            // asking user to enter a number for generating its multiplication table
            Console.WriteLine("Enter a number to generate its multiplication table:");
            int number = int.Parse(Console.ReadLine());

            int index = 0;

            for (int u = 6; u <= 9; u++)
            {
                array[index] = number * u;
                index++;
            }

            // displaying the multiplication table from 6 to 9  
            index = 0;

            for (int g = 6; g <= 9; g++)
            {
                Console.WriteLine($"{number} x {g} = {array[index]}"); ;
                index++;
            }

        }
}
}
