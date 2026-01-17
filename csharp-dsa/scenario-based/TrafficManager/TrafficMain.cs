using System;

namespace TrafficManager
{
    // Controls application flow and coordination
    public class TrafficMain
    {
        private ITrafficManager trafficManager;
        private TrafficMenu trafficMenu;

        // Constructor initializes required components
        public TrafficMain()
        {
            trafficManager = new TrafficUtility();
            trafficMenu = new TrafficMenu();
        }

        // Starts the traffic management application
        public void Start()
        {
            int choice;

            do
            {
                choice = trafficMenu.ShowMenu();

                switch (choice)
                {
                    case 1:
                        trafficManager.AddVehicleToQueue();
                        break;

                    case 2:
                        trafficManager.AllowVehicleToEnter();
                        break;

                    case 3:
                        trafficManager.RemoveVehicleFromRoundabout();
                        break;

                    case 4:
                        trafficManager.DisplayRoundabout();
                        break;

                    case 5:
                        Console.WriteLine("Exiting Traffic Manager...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.\n");
                        break;
                }

            } while (choice != 5);
        }
    }
}
