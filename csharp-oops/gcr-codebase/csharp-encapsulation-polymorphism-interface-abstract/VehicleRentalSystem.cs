namespace BridgeLabzTraining.csharp_encapsulation_polymorphism_interface_abstract
{
	// Vehicle Rental System using Object-Oriented Programming
	// Demonstrates encapsulation, inheritance, polymorphism, and abstraction
	// Supports multiple vehicle types (Car, Bike, Truck)
	// Calculates rental cost based on number of days
	// Calculates insurance cost using a common insurance interface

	internal class VehicleRentalSystem
	{
		public static void Main()
		{
			List<Vehicle> vehicles = new List<Vehicle>();

			vehicles.Add(new Car("C101", 1500, "CAR123"));
			vehicles.Add(new Bike("B202", 500, "BIKE456"));
			vehicles.Add(new Truck("T303", 3000, "TRUCK789"));

			int days = 3;

			foreach (Vehicle v in vehicles)
			{
				Console.WriteLine("Vehicle Type: " + v.Type);
				Console.WriteLine("Rental Cost: " + v.CalculateRentalCost(days));

				if (v is IInsurable insurable)
				{
					Console.WriteLine("Insurance Cost: " + insurable.CalculateInsurance());
					Console.WriteLine(insurable.GetInsuranceDetails());
				}

				Console.WriteLine("--------------------------");
			}
		}
	}

	// Abstract Class (Abstraction)
	internal abstract class Vehicle
	{
		// Fields via Properties (Encapsulation)
		public string VehicleNumber { get; private set; }

		public string Type { get; private set; }

		protected double rentalRate;

		//  Constructor
		public Vehicle(string vehicleNumber, string type, double rentalRate)
		{
			VehicleNumber = vehicleNumber;
			Type = type;
			this.rentalRate = rentalRate;
		}

		// Abstract Method
		public abstract double CalculateRentalCost(int days);
	}

	// Interface (Abstraction)
	internal interface IInsurable
	{
		double CalculateInsurance();

		string GetInsuranceDetails();
	}

	// Car Class
	internal class Car : Vehicle, IInsurable
	{
		private string insurancePolicyNumber;

		public Car(string vehicleNumber, double rentalRate, string policyNumber)
			: base(vehicleNumber, "Car", rentalRate)
		{
			insurancePolicyNumber = policyNumber;
		}

		public override double CalculateRentalCost(int days)
		{
			return rentalRate * days;
		}

		public double CalculateInsurance()
		{
			return 500;
		}

		public string GetInsuranceDetails()
		{
			return "Car Insurance Policy Number: " + insurancePolicyNumber;
		}
	}

	//  Bike Class
	internal class Bike : Vehicle, IInsurable
	{
		private string insurancePolicyNumber;

		public Bike(string vehicleNumber, double rentalRate, string policyNumber)
			: base(vehicleNumber, "Bike", rentalRate)
		{
			insurancePolicyNumber = policyNumber;
		}

		public override double CalculateRentalCost(int days)
		{
			return rentalRate * days;
		}

		public double CalculateInsurance()
		{
			return 200;
		}

		public string GetInsuranceDetails()
		{
			return "Bike Insurance Policy Number: " + insurancePolicyNumber;
		}
	}

	// Truck Class
	internal class Truck : Vehicle, IInsurable
	{
		private string insurancePolicyNumber;

		public Truck(string vehicleNumber, double rentalRate, string policyNumber)
			: base(vehicleNumber, "Truck", rentalRate)
		{
			insurancePolicyNumber = policyNumber;
		}

		public override double CalculateRentalCost(int days)
		{
			return (rentalRate * days) + 1000;
		}

		public double CalculateInsurance()
		{
			return 1000;
		}

		public string GetInsuranceDetails()
		{
			return "Truck Insurance Policy Number: " + insurancePolicyNumber;
		}
	}
}