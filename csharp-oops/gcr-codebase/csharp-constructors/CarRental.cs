namespace BridgeLabzTraining.csharp_constructor
{
	// CarRental class
	// Stores basic car rental information and calculates rent
	internal class CarRental
	{
		// Rental details (kept private)
		private string customerName;

		private string carModel;
		private int rentalDays;
		private int totalAmount;

		// Parameterized constructor
		// Initializes rental details
		public CarRental(string customerName, string carModel, int rentalDays)
		{
			this.customerName = customerName;
			this.carModel = carModel;
			this.rentalDays = rentalDays;
			CalculateAmount();
		}

		// Calculates total rental amount
		private void CalculateAmount()
		{
			int rate = carModel == "SUV" ? 3000 : 2000;
			totalAmount = rate * rentalDays;
		}

		// Displays rental information
		public void ShowDetails()
		{
			Console.WriteLine("Customer Name : " + customerName);
			Console.WriteLine("Car Model     : " + carModel);
			Console.WriteLine("Rental Days   : " + rentalDays);
			Console.WriteLine("Total Amount  : INR " + totalAmount);
		}

		// Entry point
		private static void Main()
		{
			/*
             Car Rent-A-System
             Demonstrates parameterized constructor and cost calculation
            */

			// Taking user input
			Console.Write("Enter Customer Name : ");
			string name = Console.ReadLine();

			Console.Write("Enter Car Model (SUV / Standard) : ");
			string model = Console.ReadLine();

			Console.Write("Enter Rental Days : ");
			int days = Convert.ToInt32(Console.ReadLine());

			// Creating object using user input
			CarRental rental = new CarRental(name, model, days);

			Console.WriteLine();
			rental.ShowDetails();

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}