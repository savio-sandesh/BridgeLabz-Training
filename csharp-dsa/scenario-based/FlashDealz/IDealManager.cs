using System;

namespace FlashDealz
{
    public interface IDealManager
    {
        // Add a new product deal
        void AddDeal();

        // Display all available deals
        void DisplayDeals();

        // Sort products based on discount using Quick Sort
        void SortDealsByDiscount();
    }
}
