using System;

namespace FitnessApp
{
    // Controls application flow and coordination
    public class FitnessMain
    {
        private IFitnessManager fitnessManager;
        private FitnessMenu fitnessMenu;

        // Constructor initializes required components
        public FitnessMain()
        {
            fitnessManager = new FitnessUtility();
            fitnessMenu = new FitnessMenu();
        }

        // Starts the fitness tracker application
        public void Start()
        {
            int choice;

            do
            {
                choice = fitnessMenu.ShowMenu();

                switch (choice)
                {
                    case 1:
                        fitnessManager.AddUser();
                        break;

                    case 2:
                        fitnessManager.DisplayUsers();
                        break;

                    case 3:
                        fitnessManager.SortUsersBySteps();
                        break;

                    case 4:
                        Console.WriteLine("Exiting Fitness Tracker...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.\n");
                        break;
                }

            } while (choice != 4);
        }
    }
}
