using System;

namespace TrafficManager
{
    // Represents a vehicle in the roundabout
    public class Vehicle
    {
        // Vehicle identifier
        private string vehicleNumber;

        // Reference to next vehicle (Circular Linked List)
        public Vehicle Next { get; set; }

        // Gets or sets vehicle number
        public string VehicleNumber
        {
            get { return vehicleNumber; }
            set { vehicleNumber = value; }
        }
    }
}
