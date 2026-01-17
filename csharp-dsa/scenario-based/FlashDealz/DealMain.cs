using System;

namespace FlashDealz
{
    public class DealMain
    {
        private IDealManager dealManager;
        private DealMenu dealMenu;

        // Constructor
        public DealMain()
        {
            dealManager = new DealUtility();
            dealMenu = new DealMenu();
        }

        // Start application
        public void Start()
        {
            int choice;

            do
            {
                choice = dealMenu.ShowMenu();

                switch (choice)
                {
                    case 1:
                        dealManager.AddDeal();
                        break;

                    case 2:
                        dealManager.DisplayDeals();
                        break;

                    case 3:
                        dealManager.SortDealsByDiscount();
                        break;

                    case 4:
                        Console.WriteLine("Exiting application...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.\n");
                        break;
                }

            } while (choice != 4);
        }
    }
}
