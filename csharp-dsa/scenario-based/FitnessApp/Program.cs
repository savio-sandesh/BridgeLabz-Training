// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using System;

namespace FitnessApp
{
    // Entry point of the Fitness Tracker application
    class Program
    {
        static void Main(string[] args)
        {
            FitnessMain fitnessMain = new FitnessMain();
            fitnessMain.Start();
        }
    }
}
