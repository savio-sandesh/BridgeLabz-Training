using System;

namespace TrafficManager
{
    // Handles menu display and user input
    public class TrafficMenu
    {
        // Displays menu and returns user choice
        public int ShowMenu()
        {
            Console.WriteLine(" Traffic Manager Menu:");
            Console.WriteLine("1. Add Vehicle to Waiting Queue");
            Console.WriteLine("2. Allow Vehicle to Enter Roundabout");
            Console.WriteLine("3. Remove Vehicle from Roundabout");
            Console.WriteLine("4. Display Roundabout State");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            return choice;
        }
    }
}
