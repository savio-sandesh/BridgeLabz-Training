namespace BridgeLabzTraining.csharp_instance_classmembers
{
	// VehicleRegistration class
	// Demonstrates instance and class (static) variables and methods
	internal class VehicleRegistration
	{
		// Instance variables
		private string ownerName;

		private string vehicleType;

		// Class variable (shared)
		private static int registrationFee = 5000;

		// Stores all vehicles entered
		private static List<VehicleRegistration> vehicleList =
			new List<VehicleRegistration>();

		// Parameterized constructor
		public VehicleRegistration(string ownerName, string vehicleType)
		{
			this.ownerName = ownerName;
			this.vehicleType = vehicleType;
			vehicleList.Add(this);
		}

		// Instance method
		// Displays vehicle details
		public void DisplayVehicleDetails()
		{
			Console.WriteLine("Owner Name       : " + ownerName);
			Console.WriteLine("Vehicle Type     : " + vehicleType);
			Console.WriteLine("Registration Fee : INR " + registrationFee);
		}

		// Class method
		// Updates registration fee for all vehicles
		public static void UpdateRegistrationFee(int newFee)
		{
			registrationFee = newFee;
		}

		// Displays all vehicles entered so far
		public static void DisplayAllVehicles()
		{
			Console.WriteLine("\nVehicles Registered So Far:");
			foreach (VehicleRegistration v in vehicleList)
			{
				v.DisplayVehicleDetails();
				Console.WriteLine();
			}
		}

		private static void Main()
		{
			Console.Write("Enter Registration Fee : ");
			UpdateRegistrationFee(Convert.ToInt32(Console.ReadLine()));

			string choice;

			do
			{
				Console.Write("Enter Owner Name : ");
				string owner = Console.ReadLine();

				Console.Write("Enter Vehicle Type : ");
				string type = Console.ReadLine();

				new VehicleRegistration(owner, type);

				Console.Write("Would you like to register more vehicles? (yes/no) : ");
				choice = Console.ReadLine().ToLower();

				// List all vehicles entered so far
				DisplayAllVehicles();
			} while (choice == "yes");

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}