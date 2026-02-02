using System;
using System.Collections.Generic;

// Custom exception for flight validation errors
public class InvalidFlightException : Exception
{
    public InvalidFlightException(string message) : base(message) { }
}

// Utility class containing all validation logic
public class FlightUtil
{
    private static readonly Dictionary<string, int> PassengerCapacity =
        new Dictionary<string, int>
        {
            { "SpiceJet", 396 },
            { "Vistara", 615 },
            { "IndiGo", 230 },
            { "Air Arabia", 130 }
        };

    private static readonly Dictionary<string, double> FuelCapacity =
        new Dictionary<string, double>
        {
            { "SpiceJet", 200000 },
            { "Vistara", 300000 },
            { "IndiGo", 250000 },
            { "Air Arabia", 150000 }
        };

    public bool validateFlightNumber(string flightNumber)
    {
        if (string.IsNullOrEmpty(flightNumber) ||
            !flightNumber.StartsWith("FL-") ||
            flightNumber.Length != 7 ||
            !int.TryParse(flightNumber.Substring(3), out int num) ||
            num < 1000 || num > 9999)
        {
            throw new InvalidFlightException(
                $"The flight number {flightNumber} is invalid");
        }
        return true;
    }

    public bool validateFlightName(string flightName)
    {
        if (!PassengerCapacity.ContainsKey(flightName))
        {
            throw new InvalidFlightException(
                $"The flight name {flightName} is invalid");
        }
        return true;
    }

    public bool validatePassengerCount(int passengerCount, string flightName)
    {
        if (passengerCount <= 0 ||
            passengerCount > PassengerCapacity[flightName])
        {
            throw new InvalidFlightException(
                $"The passenger count {passengerCount} is invalid for {flightName}");
        }
        return true;
    }

    public double calculateFuelToFillTank(string flightName, double currentFuelLevel)
    {
        double maxFuel = FuelCapacity[flightName];

        if (currentFuelLevel < 0 || currentFuelLevel > maxFuel)
        {
            throw new InvalidFlightException(
                $"Invalid fuel level for {flightName}");
        }
        return maxFuel - currentFuelLevel;
    }
}

// Menu-driven user interface
public class UserInterface
{
    static void Main(string[] args)
    {
        FlightUtil util = new FlightUtil();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- AeroVigil Menu ---");
            Console.WriteLine("1. Validate Flight & Calculate Fuel");
            Console.WriteLine("2. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    HandleFlightValidation(util);
                    break;

                case "2":
                    running = false;
                    Console.WriteLine("Exiting AeroVigil. Thank you.");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    private static void HandleFlightValidation(FlightUtil util)
    {
        try
        {
            Console.WriteLine("\nEnter flight details");
            Console.WriteLine("Format: FL-XXXX:FlightName:PassengerCount:CurrentFuel");

            string input = Console.ReadLine();
            string[] data = input.Split(':');

            if (data.Length != 4)
            {
                Console.WriteLine("Invalid input format.");
                return;
            }

            string flightNumber = data[0];
            string flightName = data[1];
            int passengerCount = int.Parse(data[2]);
            double currentFuel = double.Parse(data[3]);

            util.validateFlightNumber(flightNumber);
            util.validateFlightName(flightName);
            util.validatePassengerCount(passengerCount, flightName);

            double fuelNeeded =
                util.calculateFuelToFillTank(flightName, currentFuel);

            Console.WriteLine(
                $"Fuel required to fill the tank: {fuelNeeded} liters");
        }
        catch (InvalidFlightException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}


// git commit -m "Implement AeroVigil flight validation with custom exception handling"
