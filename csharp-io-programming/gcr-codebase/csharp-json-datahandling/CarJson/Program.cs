// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


using System;
using Newtonsoft.Json;

// Demonstrates converting a C# Car object into JSON format
public class CarJsonApp
{
    // Model class representing a car
    public class Car
    {
        public string brand;
        public string model;
        public int year;
        public double price;
    }

    public static void Main(string[] args)
    {
        // Convert a C# object (Car class) into JSON format

        Console.WriteLine("C# Object to JSON Conversion (Car)\n");

        Car myCar = new Car
        {
            brand = "Toyota",
            model = "Fortuner",
            year = 2022,
            price = 4500000.50
        };

        string json = JsonConvert.SerializeObject(myCar, Formatting.Indented);

        Console.WriteLine("Car JSON:");
        Console.WriteLine(json);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
