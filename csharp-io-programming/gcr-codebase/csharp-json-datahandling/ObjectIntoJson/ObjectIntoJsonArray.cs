// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// Convert a list of C# objects into a JSON array.
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// Converts a list of C# objects into a JSON array
public class ListToJsonArrayApp
{
    // Model class representing a product
    public class Product
    {
        public int Id;
        public string Name;
        public double Price;
    }

    public static void Main(string[] args)
    {
        // 6. Convert a list of C# objects into a JSON array

        Console.WriteLine("List of Objects → JSON Array\n");

        List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop",   Price = 75000 },
            new Product { Id = 2, Name = "Mouse",    Price = 1200 },
            new Product { Id = 3, Name = "Keyboard", Price = 2500 },
            new Product { Id = 4, Name = "Monitor",  Price = 18000 }
        };

        string jsonArray = JsonConvert.SerializeObject(products, Formatting.Indented);

        Console.WriteLine("JSON Array:");
        Console.WriteLine(jsonArray);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
