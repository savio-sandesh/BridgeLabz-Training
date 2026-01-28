using System;
using System.Collections.Generic;

namespace SmartWarehouse
{
    // Interface
    interface IDisplayable
    {
        void DisplayInfo();
    }

    // Abstract Base Class
    abstract class WarehouseItem : IDisplayable
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        protected WarehouseItem(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public abstract void DisplayInfo();
    }

    // Electronics Class
    class Electronics : WarehouseItem
    {
        public int WarrantyPeriod { get; set; }

        public Electronics(string name, int quantity, int warranty)
            : base(name, quantity)
        {
            WarrantyPeriod = warranty;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Electronics] Name: {Name}, Quantity: {Quantity}, Warranty: {WarrantyPeriod} year(s)");
        }
    }

    // Groceries Class
    class Groceries : WarehouseItem
    {
        public string ExpiryDate { get; set; }

        public Groceries(string name, int quantity, string expiryDate)
            : base(name, quantity)
        {
            ExpiryDate = expiryDate;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Grocery] Name: {Name}, Quantity: {Quantity}, Expiry Date: {ExpiryDate}");
        }
    }

    // Furniture Class
    class Furniture : WarehouseItem
    {
        public string Material { get; set; }

        public Furniture(string name, int quantity, string material)
            : base(name, quantity)
        {
            Material = material;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Furniture] Name: {Name}, Quantity: {Quantity}, Material: {Material}");
        }
    }

    // Generic Storage Class
    class Storage<T> where T : WarehouseItem
    {
        private List<T> items = new List<T>();

        public void AddItem(T item)
        {
            items.Add(item);
            Console.WriteLine("Item added successfully.\n");
        }

        public void DisplayItems()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("No items available.\n");
                return;
            }

            foreach (T item in items)
            {
                item.DisplayInfo();
            }
            Console.WriteLine();
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            Storage<Electronics> electronicsStorage = new Storage<Electronics>();
            Storage<Groceries> groceriesStorage = new Storage<Groceries>();
            Storage<Furniture> furnitureStorage = new Storage<Furniture>();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Smart Warehouse Management System :");
                Console.WriteLine("1. Add Electronics");
                Console.WriteLine("2. Add Grocery Item");
                Console.WriteLine("3. Add Furniture");
                Console.WriteLine("4. View Electronics");
                Console.WriteLine("5. View Groceries");
                Console.WriteLine("6. View Furniture");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                bool isValidChoice = int.TryParse(Console.ReadLine(), out choice);

                if (!isValidChoice)
                {
                    Console.WriteLine("Invalid input. Please enter a number.\n");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Electronic Device Name: ");
                        string eName = Console.ReadLine();

                        Console.Write("Enter quantity: ");
                        int eQty = int.Parse(Console.ReadLine());

                        Console.Write("Enter warranty period (years): ");
                        int warranty = int.Parse(Console.ReadLine());

                        electronicsStorage.AddItem(new Electronics(eName, eQty, warranty));
                        break;

                    case 2:
                        Console.Write("Enter Grocery Item Name: ");
                        string gName = Console.ReadLine();

                        Console.Write("Enter quantity: ");
                        int gQty = int.Parse(Console.ReadLine());

                        Console.Write("Enter expiry date: ");
                        string expiry = Console.ReadLine();

                        groceriesStorage.AddItem(new Groceries(gName, gQty, expiry));
                        break;

                    case 3:
                        Console.Write("Enter Furniture Item Name: ");
                        string fName = Console.ReadLine();

                        Console.Write("Enter quantity: ");
                        int fQty = int.Parse(Console.ReadLine());

                        Console.Write("Enter material: ");
                        string material = Console.ReadLine();

                        furnitureStorage.AddItem(new Furniture(fName, fQty, material));
                        break;


                    case 4:
                        Console.WriteLine("\n--- Electronics Items ---");
                        electronicsStorage.DisplayItems();
                        break;

                    case 5:
                        Console.WriteLine("\n--- Grocery Items ---");
                        groceriesStorage.DisplayItems();
                        break;

                    case 6:
                        Console.WriteLine("\n--- Furniture Items ---");
                        furnitureStorage.DisplayItems();
                        break;

                    case 7:
                        exit = true;
                        Console.WriteLine("Exiting application...");
                        break;

                    default:
                        Console.WriteLine("Invalid menu option.\n");
                        break;
                }
            }
        }
    }
}
