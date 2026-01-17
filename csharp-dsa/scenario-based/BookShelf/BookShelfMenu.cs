using System;

namespace BookShelf
{
    // Handles menu display and user input
    public class BookShelfMenu
    {
        // Displays menu options and returns user choice
        public int ShowMenu()
        {
            Console.WriteLine("===== BookShelf Menu =====");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. Display Books by Genre");
            Console.WriteLine("4. Display All Books");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            return choice;
        }
    }
}
