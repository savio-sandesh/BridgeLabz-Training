namespace BridgeLabzTraining.csharp_keywords
{
	// vehicle class
	// uses static members for shared registration fee,
	// readonly registration number for unique identification,
	// this keyword for constructor initialization,
	// and is operator for safe type validation

	internal class Vehicle
	{
		// static member shared by all vehicles
		public static double RegistrationFee = 5000;

		// readonly member
		public readonly long RegistrationNumber;

		// instance members
		public string OwnerName;

		public string VehicleType;

		// stores all vehicles
		private static List<Vehicle> vehicleList = new List<Vehicle>();

		// parameterized constructor
		public Vehicle(long registrationNumber, string ownerName, string vehicleType)
		{
			this.RegistrationNumber = registrationNumber;
			this.OwnerName = ownerName;
			this.VehicleType = vehicleType;
			vehicleList.Add(this);
		}

		// displays vehicle details
		public void DisplayVehicleDetails()
		{
			Console.WriteLine("Registration Number : " + RegistrationNumber);
			Console.WriteLine("Owner Name          : " + OwnerName);
			Console.WriteLine("Vehicle Type        : " + VehicleType);
			Console.WriteLine("Registration Fee    : INR " + RegistrationFee);
		}

		// static method to update registration fee
		public static void UpdateRegistrationFee(double newFee)
		{
			RegistrationFee = newFee;
		}

		// displays all vehicles using is operator
		public static void DisplayAllVehicles()
		{
			foreach (object obj in vehicleList)
			{
				if (obj is Vehicle vehicle)
				{
					vehicle.DisplayVehicleDetails();
					Console.WriteLine();
				}
			}
		}
	}

	internal class VehicleRegistrationSystem
	{
		private static void Main()
		{
			string choice;

			Console.Write("Enter Registration Fee : ");
			Vehicle.UpdateRegistrationFee(Convert.ToDouble(Console.ReadLine()));

			do
			{
				Console.Write("Enter Registration Number : ");
				long regNo = Convert.ToInt64(Console.ReadLine());

				Console.Write("Enter Owner Name : ");
				string owner = Console.ReadLine();

				Console.Write("Enter Vehicle Type : ");
				string type = Console.ReadLine();

				new Vehicle(regNo, owner, type);

				Console.Write("Would you like to add more vehicles? (yes/no) : ");
				choice = Console.ReadLine().ToLower();

				Console.WriteLine();
			} while (choice == "yes");

			Vehicle.DisplayAllVehicles();

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}