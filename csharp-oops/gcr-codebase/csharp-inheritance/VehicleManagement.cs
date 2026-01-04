namespace BridgeLabzTraining.csharp_inheritance
{
	// refuelable interface
	// used to simulate hybrid inheritance
	internal interface Refuelable
	{
		void Refuel();
	}

	// base vehicle class
	// acts as the superclass
	internal class BaseVehicle
	{
		public string Model;
		public int MaxSpeed;
	}

	// electric vehicle class
	// inherits from base vehicle
	internal class ElectricVehicle : BaseVehicle
	{
		public void Charge()
		{
			Console.WriteLine("Electric vehicle is charging");
		}
	}

	// petrol vehicle class
	// inherits from base vehicle and implements refuelable interface
	internal class PetrolVehicle : BaseVehicle, Refuelable
	{
		public void Refuel()
		{
			Console.WriteLine("Petrol vehicle is refueling");
		}
	}

	internal class VehicleManagement
	{
		private static void Main()
		{
			// electric vehicle object
			ElectricVehicle ev = new ElectricVehicle();
			ev.Model = "Tesla";
			ev.MaxSpeed = 180;

			Console.WriteLine("Electric Vehicle Model : " + ev.Model);
			Console.WriteLine("Max Speed              : " + ev.MaxSpeed);
			ev.Charge();

			Console.WriteLine();

			// petrol vehicle object
			PetrolVehicle pv = new PetrolVehicle();
			pv.Model = "Honda";
			pv.MaxSpeed = 160;

			Console.WriteLine("Petrol Vehicle Model   : " + pv.Model);
			Console.WriteLine("Max Speed              : " + pv.MaxSpeed);
			pv.Refuel();

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}