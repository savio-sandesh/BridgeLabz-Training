using System;

namespace FlashDealz
{
    public class DealUtility : IDealManager
    {
        private Deal[] deals;
        private int count;

        // Constructor
        public DealUtility()
        {
            deals = new Deal[100]; // Fixed size for simplicity
            count = 0;
        }

        // Add a new deal
        public void AddDeal()
        {
            if (count >= deals.Length)
            {
                Console.WriteLine("Deal storage is full.\n");
                return;
            }

            Deal deal = new Deal();

            Console.Write("Enter Product Name: ");
            deal.ProductName = Console.ReadLine();

            Console.Write("Enter Original Price: ");
            deal.OriginalPrice = double.Parse(Console.ReadLine());

            Console.Write("Enter Discount Percentage: ");
            deal.DiscountPercentage = double.Parse(Console.ReadLine());

            deals[count] = deal;
            count++;

            Console.WriteLine("Deal added successfully.\n");
        }

        // Display all deals
        public void DisplayDeals()
        {
            if (count == 0)
            {
                Console.WriteLine("No deals available.\n");
                return;
            }

            Console.WriteLine("Available Deals:");
            for (int i = 0; i < count; i++)
            {
                double discountedPrice =
                    deals[i].OriginalPrice -
                    (deals[i].OriginalPrice * deals[i].DiscountPercentage / 100);

                Console.WriteLine("Product Name: " + deals[i].ProductName);
                Console.WriteLine("Original Price: " + deals[i].OriginalPrice);
                Console.WriteLine("Discount: " + deals[i].DiscountPercentage + "%");
                Console.WriteLine("Discounted Price: " + discountedPrice);
                Console.WriteLine("----------------------------");
            }
        }


        // Sort deals by discount (Quick Sort)
        public void SortDealsByDiscount()
        {
            if (count <= 1)
            {
                Console.WriteLine("Not enough deals to sort.\n");
                return;
            }

            QuickSort(0, count - 1);
            Console.WriteLine("Deals sorted by discount (High to Low).\n");
        }

        // Quick Sort method
        private void QuickSort(int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(low, high);
                QuickSort(low, pivotIndex - 1);
                QuickSort(pivotIndex + 1, high);
            }
        }

        // Partition logic (Descending order)
        private int Partition(int low, int high)
        {
            double pivot = deals[high].DiscountPercentage;
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (deals[j].DiscountPercentage > pivot)
                {
                    i++;
                    Swap(i, j);
                }
            }

            Swap(i + 1, high);
            return i + 1;
        }

        // Swap method
        private void Swap(int i, int j)
        {
            Deal temp = deals[i];
            deals[i] = deals[j];
            deals[j] = temp;
        }
    }
}
