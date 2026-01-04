namespace BridgeLabzTraining.BookingDemo
{
	// Represents a simple hotel booking record
	internal class BookingRecord
	{
		// Properties to store booking information
		public string CustomerName { get; private set; }

		public string RoomType { get; private set; }
		public int StayDays { get; private set; }
		public int TotalAmount { get; private set; }

		// Default constructor
		public BookingRecord()
		{
			CustomerName = "Guest";
			RoomType = "Standard";
			StayDays = 1;

			CalculateAmount();
		}

		// Parameterized constructor
		public BookingRecord(string customerName, string roomType, int stayDays)
		{
			CustomerName = customerName;
			RoomType = roomType;
			StayDays = stayDays > 0 ? stayDays : 1;

			CalculateAmount();
		}

		// Copy constructor
		public BookingRecord(BookingRecord oldBooking)
		{
			CustomerName = oldBooking.CustomerName;
			RoomType = oldBooking.RoomType;
			StayDays = oldBooking.StayDays;
			TotalAmount = oldBooking.TotalAmount;
		}

		// Calculates total booking amount
		private void CalculateAmount()
		{
			int dailyRate = RoomType == "Deluxe" ? 2000 : 1200;
			TotalAmount = dailyRate * StayDays;
		}

		// Displays booking summary
		public void ShowSummary()
		{
			Console.WriteLine("Customer Name : " + CustomerName);
			Console.WriteLine("Room Type     : " + RoomType);
			Console.WriteLine("Days Stayed   : " + StayDays);
			Console.WriteLine("Total Amount  : " + TotalAmount);
		}

		private static void Main(string[] args)
		{
			Console.WriteLine("Default Booking:");
			BookingRecord booking1 = new BookingRecord();
			booking1.ShowSummary();

			Console.WriteLine();

			Console.WriteLine("Custom Booking:");
			BookingRecord booking2 = new BookingRecord("Sandesh", "Deluxe", 3);
			booking2.ShowSummary();

			Console.WriteLine();

			Console.WriteLine("Copied Booking:");
			BookingRecord booking3 = new BookingRecord(booking2);
			booking3.ShowSummary();

			Console.ReadLine();
		}
	}
}