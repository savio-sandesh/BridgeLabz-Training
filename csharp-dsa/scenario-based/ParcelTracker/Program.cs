// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;

namespace ParcelTracker
{
    // Entry point of the application.
    // Responsible for starting the Parcel Tracker system.
    class Program
    {
        static void Main(string[] args)
        {
            ParcelMain mainApp = new ParcelMain();
            mainApp.StartApplication();
        }
    }
}
