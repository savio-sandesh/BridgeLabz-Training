using System;
using System.Collections.Generic;

namespace DynamicOnlineMarketplace
{
    // Category Interface
    interface ICategory
    {
        string GetCategoryDetails();
    }

    // Book Category
    class BookCategory : ICategory
    {
        public string Genre { get; set; }

        public BookCategory(string genre)
        {
            Genre = genre;
        }

        public string GetCategoryDetails()
        {
            return "Book Genre: " + Genre;
        }
    }

    // Clothing Category
    class ClothingCategory : ICategory
    {
        public string Size { get; set; }

        public ClothingCategory(string size)
        {
            Size = size;
        }

        public string GetCategoryDetails()
        {
            return "Clothing Size: " + Size;
        }
    }

    // Non-generic Product Base (VERY IMPORTANT)
    interface IProduct
    {
        double Price { get; set; }
        void DisplayProductDetails();
    }

    // Generic Product Class with Constraint
    class Product<TCategory> : IProduct where TCategory : ICategory
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public TCategory Category { get; set; }

        public Product(string productName, double price, TCategory category)
        {
            ProductName = productName;
            Price = price;
            Category = category;
        }

        public void DisplayProductDetails()
        {
            Console.WriteLine("Product Name: " + ProductName);
            Console.WriteLine("Price: " + Price);
            Console.WriteLine(Category.GetCategoryDetails());
            Console.WriteLine("-----------------------------------");
        }
    }

    // Utility Class with Generic Method
    class MarketplaceUtility
    {
        public static void ApplyDiscount<T>(T product, double percentage)
            where T : IProduct
        {
            double discountAmount = product.Price * (percentage / 100);
            product.Price -= discountAmount;
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            List<Product<BookCategory>> bookProducts = new List<Product<BookCategory>>();
            List<Product<ClothingCategory>> clothingProducts = new List<Product<ClothingCategory>>();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Dynamic Online Marketplace :");
                Console.WriteLine("1. Add Book Product");
                Console.WriteLine("2. Add Clothing Product");
                Console.WriteLine("3. View Book Products");
                Console.WriteLine("4. View Clothing Products");
                Console.WriteLine("5. Apply Discount to All Products");
                Console.WriteLine("6. Exit");
                Console.Write("Please enter your menu choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a numeric value.\n");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Book Product Name: ");
                        string bookName = Console.ReadLine() ?? "";

                        Console.Write("Enter Book Price: ");
                        double bookPrice = double.Parse(Console.ReadLine() ?? "0");

                        Console.Write("Enter Book Genre: ");
                        string genre = Console.ReadLine() ?? "";

                        bookProducts.Add(
                            new Product<BookCategory>(bookName, bookPrice, new BookCategory(genre))
                        );

                        Console.WriteLine("Book product added successfully.\n");
                        break;

                    case 2:
                        Console.Write("Enter Clothing Product Name: ");
                        string clothingName = Console.ReadLine() ?? "";

                        Console.Write("Enter Clothing Price: ");
                        double clothingPrice = double.Parse(Console.ReadLine() ?? "0");

                        Console.Write("Enter Clothing Size: ");
                        string size = Console.ReadLine() ?? "";

                        clothingProducts.Add(
                            new Product<ClothingCategory>(clothingName, clothingPrice, new ClothingCategory(size))
                        );

                        Console.WriteLine("Clothing product added successfully.\n");
                        break;

                    case 3:
                        Console.WriteLine("\n--- Book Product Catalog ---");
                        if (bookProducts.Count == 0)
                            Console.WriteLine("No book products available.\n");
                        else
                            foreach (var product in bookProducts)
                                product.DisplayProductDetails();
                        break;

                    case 4:
                        Console.WriteLine("\n--- Clothing Product Catalog ---");
                        if (clothingProducts.Count == 0)
                            Console.WriteLine("No clothing products available.\n");
                        else
                            foreach (var product in clothingProducts)
                                product.DisplayProductDetails();
                        break;

                    case 5:
                        Console.Write("Enter discount percentage to apply: ");
                        double discount = double.Parse(Console.ReadLine() ?? "0");

                        foreach (var product in bookProducts)
                            MarketplaceUtility.ApplyDiscount(product, discount);

                        foreach (var product in clothingProducts)
                            MarketplaceUtility.ApplyDiscount(product, discount);

                        Console.WriteLine("Discount applied successfully.\n");
                        break;

                    case 6:
                        exit = true;
                        Console.WriteLine("Exiting Dynamic Online Marketplace...");
                        break;

                    default:
                        Console.WriteLine("Invalid menu selection.\n");
                        break;
                }
            }
        }
    }
}
