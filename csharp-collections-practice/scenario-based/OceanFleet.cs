using System;
using System.Collections.Generic;
using System.Linq;

// Model class representing a vessel
public class Vessel
{
    public string VesselId { get; set; }
    public string VesselName { get; set; }
    public double AverageSpeed { get; set; }   // Speed in knots
    public string VesselType { get; set; }

    // No-argument constructor
    public Vessel() { }

    // Parameterized constructor
    public Vessel(string vesselId, string vesselName, double averageSpeed, string vesselType)
    {
        VesselId = vesselId;
        VesselName = vesselName;
        AverageSpeed = averageSpeed;
        VesselType = vesselType;
    }
}

// Utility class to manage vessel records
public class VesselUtil
{
    // Stores all vessel objects
    private List<Vessel> vesselList = new List<Vessel>();

    // Adds a vessel to the list
    public void addVesselPerformance(Vessel vessel)
    {
        vesselList.Add(vessel);
    }

    // Retrieves vessel by vesselId (case-sensitive)
    public Vessel getVesselById(string vesselId)
    {
        return vesselList.FirstOrDefault(v => v.VesselId == vesselId);
    }

    // Returns vessels with the highest average speed
    public List<Vessel> getHighPerformanceVessels()
    {
        if (vesselList.Count == 0)
            return new List<Vessel>();

        double maxSpeed = vesselList.Max(v => v.AverageSpeed);

        return vesselList
            .Where(v => v.AverageSpeed == maxSpeed)
            .ToList();
    }
}

// Handles user interaction
public class UserInterface
{
    public static void Main(string[] args)
    {
        VesselUtil util = new VesselUtil();

        while (true)
        {
            Console.WriteLine("\n1. Add Vessel");
            Console.WriteLine("2. Retrieve Vessel by Id");
            Console.WriteLine("3. Show High Performance Vessels");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice:");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 4)
            {
                Console.WriteLine("Exiting OceanFleet Analytics...");
                break;
            }

            if (choice == 1)
            {
                // Add vessel details
                Console.WriteLine("Enter vessel details (vesselId:vesselName:averageSpeed:vesselType)");
                string[] data = Console.ReadLine().Split(':');

                Vessel vessel = new Vessel(
                    data[0],
                    data[1],
                    double.Parse(data[2]),
                    data[3]
                );

                util.addVesselPerformance(vessel);
                Console.WriteLine("Vessel added successfully");
            }
            else if (choice == 2)
            {
                // Retrieve vessel by ID
                Console.WriteLine("Enter Vessel Id to search:");
                string searchId = Console.ReadLine();

                Vessel vessel = util.getVesselById(searchId);

                if (vessel != null)
                {
                    Console.WriteLine($"{vessel.VesselId} | {vessel.VesselName} | {vessel.VesselType} | {vessel.AverageSpeed} knots");
                }
                else
                {
                    Console.WriteLine($"Vessel Id {searchId} not found");
                }
            }
            else if (choice == 3)
            {
                // Show high performance vessels
                List<Vessel> topVessels = util.getHighPerformanceVessels();

                Console.WriteLine("High performance vessels are");
                foreach (Vessel v in topVessels)
                {
                    Console.WriteLine($"{v.VesselId} | {v.VesselName} | {v.VesselType} | {v.AverageSpeed} knots");
                }
            }
        }
    }
}
