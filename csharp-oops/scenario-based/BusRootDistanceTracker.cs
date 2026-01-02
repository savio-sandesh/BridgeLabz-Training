namespace BridgeLabzTraining.scenario_based
{
	// Bus Route Distance Tracker 🚌
	// Each stop adds distance.
	// Ask if the passenger wants to get off at a stop.
	// Use a while-loop with a total distance tracker.
	// Exit on user confirmation.

	internal class BusRootDistanceTracker
	{
		//manages the complete workflow of tracking the bus route distance
		private void TrackBusRoute()
		{
			double totalDistanceTravelled = 0.0;
			bool passengerExit = false;

			while (!passengerExit)
			{
				double distanceAtStop = GetDistanceAtStop();
				totalDistanceTravelled += distanceAtStop;
				passengerExit = IsPassengerExiting();
			}
			DisplayDistance(totalDistanceTravelled);
		}

		// asking user to enter the distance travelled till the current stop and validates the input
		private double GetDistanceAtStop()
		{
			Console.WriteLine("Enter the distance travelled till this stop (in km): ");
			string input = Console.ReadLine()!;

			if (!double.TryParse(input, out double distance) && distance <= 0)
			{
				Console.WriteLine("Invalid input. Please enter a valid number for distance.");
				return GetDistanceAtStop();
			}
			else
			{
				return distance;
			}
		}

		// asking user if they are exiting at the current stop and validates the input
		private bool IsPassengerExiting()
		{
			Console.WriteLine("Are you exiting at this stop? (yes/no): ");
			string response = Console.ReadLine()!.Trim().ToLower();

			if (response == "yes")
			{
				return true;
			}
			else if (response == "no")
			{
				return false;
			}
			else
			{
				Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
				return IsPassengerExiting();
			}
		}

		// display the total distance travelled
		private void DisplayDistance(double totalDistanceTravelled)
		{
			Console.WriteLine("Total distance travelled: " + totalDistanceTravelled + " km");
		}

		private static void Main(string[] args)
		{
			// creating an object of BusRootDistanceTracker class and calling TrackBusRoute method
			BusRootDistanceTracker tracker = new BusRootDistanceTracker();
			tracker.TrackBusRoute();
		}
	}
}