namespace BridgeLabzTraining.csharp_inheritance
{
	// order class
	// acts as the base class
	internal class Order
	{
		public int OrderId;
		public string OrderDate;
	}

	// shipped order class
	// inherits from order (multilevel inheritance)
	internal class ShippedOrder : Order
	{
		public string TrackingNumber;
	}

	// delivered order class
	// inherits from shipped order
	internal class DeliveredOrder : ShippedOrder
	{
		public string DeliveryDate;

		// displays current order status
		public void GetOrderStatus()
		{
			Console.WriteLine("Order Id        : " + OrderId);
			Console.WriteLine("Order Date      : " + OrderDate);
			Console.WriteLine("Tracking Number : " + TrackingNumber);
			Console.WriteLine("Delivery Date   : " + DeliveryDate);
			Console.WriteLine("Order Status    : Delivered");
		}
	}

	internal class OnlineRetailManagement
	{
		private static void Main()
		{
			// creating delivered order object
			DeliveredOrder order = new DeliveredOrder();

			order.OrderId = 101;
			order.OrderDate = "12-09-2025";
			order.TrackingNumber = "TRK987654";
			order.DeliveryDate = "15-09-2025";

			order.GetOrderStatus();

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}