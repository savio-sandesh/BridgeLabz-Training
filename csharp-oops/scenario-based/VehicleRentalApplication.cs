namespace BridgeLabzTraining.scenario_based
{
	// vehicle rental application
	// demonstrates inheritance, interfaces, access modifiers, and polymorphism
	// calculates rental charges for different vehicle types

	internal class VehicleRentalApplication
	{
		// main method to execute the application
		private static void Main(string[] args)
		{
			// creating customer
			Customer customer = new Customer("arjun");

			// renting a bike
			Vehicle bike = new Bike("BIKE-101");
			customer.RentVehicle(bike, 3);

			// renting a car
			Vehicle car = new Car("CAR-202");
			customer.RentVehicle(car, 5);

			// renting a truck
			Vehicle truck = new Truck("TRUCK-303");
			customer.RentVehicle(truck, 2);
		}
	}

	// interface defining rental behavior
	internal interface IRentable
	{
		// calculates rent based on number of days
		double CalculateRent(int days);
	}

	// base class representing a vehicle
	internal class Vehicle : IRentable
	{
		// protected fields for inheritance
		protected string vehicleNumber;

		protected double rentPerDay;

		// constructor to initialize vehicle details
		public Vehicle(string vehicleNumber, double rentPerDay)
		{
			this.vehicleNumber = vehicleNumber;
			this.rentPerDay = rentPerDay;
		}

		// virtual method to calculate rent
		public virtual double CalculateRent(int days)
		{
			return rentPerDay * days;
		}

		// displays vehicle information
		public virtual void DisplayInfo()
		{
			Console.WriteLine($"vehicle number: {vehicleNumber}");
			Console.WriteLine($"rent per day: {rentPerDay}");
		}
	}

	// derived class representing a bike
	internal class Bike : Vehicle
	{
		public Bike(string vehicleNumber)
			: base(vehicleNumber, 300)
		{
		}

		public override void DisplayInfo()
		{
			Console.WriteLine("vehicle type: bike");
			base.DisplayInfo();
		}
	}

	// derived class representing a car
	internal class Car : Vehicle
	{
		public Car(string vehicleNumber)
			: base(vehicleNumber, 700)
		{
		}

		public override void DisplayInfo()
		{
			Console.WriteLine("vehicle type: car");
			base.DisplayInfo();
		}
	}

	// derived class representing a truck
	internal class Truck : Vehicle
	{
		public Truck(string vehicleNumber)
			: base(vehicleNumber, 1200)
		{
		}

		public override void DisplayInfo()
		{
			Console.WriteLine("vehicle type: truck");
			base.DisplayInfo();
		}
	}

	// class representing a customer
	internal class Customer
	{
		public string CustomerName { get; set; }

		// constructor to initialize customer name
		public Customer(string customerName)
		{
			CustomerName = customerName;
		}

		// rents a vehicle and displays total rent
		public void RentVehicle(Vehicle vehicle, int days)
		{
			Console.WriteLine($"customer name: {CustomerName}");
			vehicle.DisplayInfo();
			Console.WriteLine($"rental days: {days}");
			Console.WriteLine($"total rent: {vehicle.CalculateRent(days)}");
			Console.WriteLine();
		}
	}
}