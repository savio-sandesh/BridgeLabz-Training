using System;

namespace ParcelTracker
{
    // Controls the overall flow of the application.
    // Acts as a mediator between the menu and business logic.
    class ParcelMain
    {
        private ParcelMenu menu;
        private IParcelTracker tracker;

        public ParcelMain()
        {
            menu = new ParcelMenu();
            tracker = new ParcelUtility();
        }

        // Starts the main execution loop of the application.
        public void StartApplication()
        {
            bool exit = false;

            while (!exit)
            {
                int choice = menu.DisplayMenu();

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter delivery stage name: ");
                        tracker.AddStage(Console.ReadLine());
                        break;

                    case 2:
                        Console.Write("Enter existing stage name: ");
                        string existingStage = Console.ReadLine();

                        Console.Write("Enter new checkpoint stage name: ");
                        string newStage = Console.ReadLine();

                        tracker.AddCheckpoint(existingStage, newStage);
                        break;

                    case 3:
                        tracker.TrackParcel();
                        break;

                    case 4:
                        Console.Write("Enter stage after which parcel is lost: ");
                        tracker.MarkParcelLost(Console.ReadLine());
                        break;

                    case 5:
                        exit = true;
                        Console.WriteLine("Exiting Parcel Tracker system.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
