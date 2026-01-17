using System;

namespace FlashDealz
{
    public class DealMenu
    {
        // Display menu and return user choice
        public int ShowMenu()
        {
            Console.WriteLine("===== FlashDealz Menu =====");
            Console.WriteLine("1. Add Product Deal");
            Console.WriteLine("2. Display All Deals");
            Console.WriteLine("3. Sort Deals by Discount");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            return choice;
        }
    }
}
