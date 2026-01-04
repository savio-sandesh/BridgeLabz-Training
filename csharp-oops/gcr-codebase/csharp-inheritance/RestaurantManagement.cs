namespace BridgeLabzTraining.csharp_inheritance
{
	// worker interface
	// used to simulate hybrid inheritance
	internal interface Worker
	{
		void PerformDuties();
	}

	// person class
	// acts as the superclass
	internal class Person
	{
		public string Name;
		public int Id;
	}

	// chef class
	// inherits from person and implements worker interface
	internal class Chef : Person, Worker
	{
		public void PerformDuties()
		{
			Console.WriteLine("Chef is preparing food");
		}
	}

	// waiter class
	// inherits from person and implements worker interface
	internal class Waiter : Person, Worker
	{
		public void PerformDuties()
		{
			Console.WriteLine("Waiter is serving customers");
		}
	}

	internal class RestaurantManagement
	{
		private static void Main()
		{
			// chef object
			Chef chef = new Chef();
			chef.Name = "Sandesh";
			chef.Id = 101;

			Console.WriteLine("Chef Name : " + chef.Name);
			chef.PerformDuties();

			Console.WriteLine();

			// waiter object
			Waiter waiter = new Waiter();
			waiter.Name = "Amit";
			waiter.Id = 102;

			Console.WriteLine("Waiter Name : " + waiter.Name);
			waiter.PerformDuties();

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}