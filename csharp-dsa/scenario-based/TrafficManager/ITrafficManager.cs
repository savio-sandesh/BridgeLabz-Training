using System;

namespace TrafficManager
{
    // Defines traffic management operations
    public interface ITrafficManager
    {
        void AddVehicleToQueue();
        void AllowVehicleToEnter();
        void RemoveVehicleFromRoundabout();
        void DisplayRoundabout();
    }
}
