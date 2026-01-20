using System;

namespace ParcelTracker
{
    // Handles user interaction.
    // Displays menu options and collects user input.
    class ParcelMenu
    {
        // Displays menu options and returns the user's choice.
        public int DisplayMenu()
        {
            Console.WriteLine("\n--- Parcel Tracker Menu ---");
            Console.WriteLine("1. Add delivery stage");
            Console.WriteLine("2. Add intermediate checkpoint");
            Console.WriteLine("3. Track parcel");
            Console.WriteLine("4. Mark parcel as lost");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
