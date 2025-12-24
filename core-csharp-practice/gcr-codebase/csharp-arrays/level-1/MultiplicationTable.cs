using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_array.level_1
{
    internal class MultiplicationTable
    {
        static void Main(string[] args)
        {
            // array to store multiplication results
            int[] table = new int[10];


            // Taking input for multiplication table
            Console.Write("Enter the number to generate its multiplication table: ");
            int number = int.Parse(Console.ReadLine());


            // Generating multiplication table
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = number * (i + 1);
            }
            // Displaying the multiplication table
            Console.WriteLine($"Multiplication Table of {number}:");
            for (int j = 0; j < table.Length; j++)
            {
                Console.WriteLine($"{number} x {j + 1} = {table[j]}");
            }
        }
    }
}
