namespace BridgeLabzTraining.csharp_objectmodeling
{
	// product class
	internal class Product
	{
		public string Name;
		public int Price;

		public Product(string name, int price)
		{
			Name = name;
			Price = price;
		}
	}

	// order class
	// order aggregates products
	internal class Order
	{
		public List<Product> products;

		public Order()
		{
			products = new List<Product>();
		}

		public void AddProduct(Product product)
		{
			products.Add(product);
			Console.WriteLine("Product added to order : " + product.Name);
		}

		public void ShowOrderDetails()
		{
			Console.WriteLine("Order Products :");
			foreach (Product p in products)
			{
				Console.WriteLine("  " + p.Name + " - INR " + p.Price);
			}
		}
	}

	// customer class
	internal class Customer
	{
		public string Name;

		public Customer(string name)
		{
			Name = name;
		}

		// communication between customer and order
		public void PlaceOrder(Order order)
		{
			Console.WriteLine("Customer " + Name + " placed an order");
			order.ShowOrderDetails();
		}
	}

	internal class ECommercePlatform
	{
		private static void Main()
		{
			Customer customer = new Customer("Sandesh");

			Product p1 = new Product("Laptop", 50000);
			Product p2 = new Product("Mouse", 800);

			Order order = new Order();
			order.AddProduct(p1);
			order.AddProduct(p2);

			Console.WriteLine();

			customer.PlaceOrder(order);

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}