namespace BridgeLabzTraining.csharp_encapsulation_polymorphism_interface_abstract
{
	// Ride-Hailing Application using OOP concepts in C#
	// Demonstrates abstraction, encapsulation, inheritance, interface, and polymorphism
	// Supports different vehicle types with dynamic fare calculation

	internal class RideHailingApplication
	{
		public static void Main()
		{
			// Polymorphism: base class reference handling different vehicle types
			List<Vehicle> vehicles = new List<Vehicle>();

			vehicles.Add(new Car(1, "Ramesh", 15));
			vehicles.Add(new Bike(2, "Suresh", 8));
			vehicles.Add(new Auto(3, "Mahesh", 12));

			double distance = 10;

			foreach (Vehicle vehicle in vehicles)
			{
				Console.WriteLine(vehicle.GetVehicleDetails());
				Console.WriteLine("Fare for " + distance + " km: " + vehicle.CalculateFare(distance));

				// Interface-based polymorphism for GPS functionality
				if (vehicle is IGPS gps)
				{
					gps.UpdateLocation("City Center");
					Console.WriteLine("Current Location: " + gps.GetCurrentLocation());
				}

				Console.WriteLine();
			}
		}
	}

	// Abstract base class defining common vehicle structure (Abstraction)
	internal abstract class Vehicle
	{
		// Encapsulation: private setters protect vehicle and driver details
		public int VehicleId { get; private set; }

		public string DriverName { get; private set; }
		protected double RatePerKm;

		public Vehicle(int vehicleId, string driverName, double ratePerKm)
		{
			VehicleId = vehicleId;
			DriverName = driverName;
			RatePerKm = ratePerKm;
		}

		// Concrete method shared by all vehicle types
		public string GetVehicleDetails()
		{
			return $"Vehicle ID: {VehicleId}, Driver: {DriverName}";
		}

		// Abstract method forcing subclasses to calculate fare
		public abstract double CalculateFare(double distance);
	}

	// Interface defining GPS functionality (Abstraction)
	internal interface IGPS
	{
		string GetCurrentLocation();

		void UpdateLocation(string location);
	}

	// Car class inheriting Vehicle and implementing GPS
	internal class Car : Vehicle, IGPS
	{
		private string currentLocation;

		public Car(int vehicleId, string driverName, double ratePerKm)
			: base(vehicleId, driverName, ratePerKm)
		{
		}

		// Car-specific fare calculation
		public override double CalculateFare(double distance)
		{
			return distance * RatePerKm;
		}

		public void UpdateLocation(string location)
		{
			currentLocation = location;
		}

		public string GetCurrentLocation()
		{
			return currentLocation;
		}
	}

	// Bike class inheriting Vehicle and implementing GPS
	internal class Bike : Vehicle, IGPS
	{
		private string currentLocation;

		public Bike(int vehicleId, string driverName, double ratePerKm)
			: base(vehicleId, driverName, ratePerKm)
		{
		}

		// Bike-specific fare calculation
		public override double CalculateFare(double distance)
		{
			return distance * RatePerKm;
		}

		public void UpdateLocation(string location)
		{
			currentLocation = location;
		}

		public string GetCurrentLocation()
		{
			return currentLocation;
		}
	}

	// Auto class inheriting Vehicle and implementing GPS
	internal class Auto : Vehicle, IGPS
	{
		private string currentLocation;

		public Auto(int vehicleId, string driverName, double ratePerKm)
			: base(vehicleId, driverName, ratePerKm)
		{
		}

		// Auto-specific fare calculation
		public override double CalculateFare(double distance)
		{
			return (distance * RatePerKm) + 20; // base charge
		}

		public void UpdateLocation(string location)
		{
			currentLocation = location;
		}

		public string GetCurrentLocation()
		{
			return currentLocation;
		}
	}
}