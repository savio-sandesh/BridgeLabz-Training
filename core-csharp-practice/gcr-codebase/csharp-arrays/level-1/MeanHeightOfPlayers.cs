using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_array.level_1
{
    internal class MeanHeightOfPlayers
    {
        static void Main(string[] args)
        {
            double[] heightOfPlayers = new double[11];
            double total=0.0;

            // taking input heights of 11 players
            for(int o=0; o<heightOfPlayers.Length; o++)
            {
                Console.Write("Enter height of player " + (o + 1) + " in centimeters: ");
                heightOfPlayers[o] = double.Parse(Console.ReadLine());
                total += heightOfPlayers[o];
            }

            // calculating mean height
            double meanHeight = total / heightOfPlayers.Length;

            // displaying result
            Console.WriteLine("Mean height of the 11 players is: " + meanHeight + " cm");
        }
    }
}
