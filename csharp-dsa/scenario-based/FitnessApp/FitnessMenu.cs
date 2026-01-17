using System;

namespace FitnessApp
{
    // Handles menu display and user input
    public class FitnessMenu
    {
        // Displays menu options and returns user choice
        public int ShowMenu()
        {
            Console.WriteLine("Fitness Tracker Menu:");
            Console.WriteLine("1. Add User Step Count");
            Console.WriteLine("2. Display Daily Rankings");
            Console.WriteLine("3. Sort Users by Steps");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            return choice;
        }
    }
}
