using System;

namespace FlashDealz
{
    public class Deal
    {
        // Private fields (Encapsulation)
        private string productName;
        private double originalPrice;
        private double discountPercentage;

        // Public properties (Getters and Setters)
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public double OriginalPrice
        {
            get { return originalPrice; }
            set { originalPrice = value; }
        }

        public double DiscountPercentage
        {
            get { return discountPercentage; }
            set { discountPercentage = value; }
        }
    }
}
