namespace BridgeLabzTraining.csharp_keywords
{
	// product class
	// demonstrates static, this, readonly and is operator
	internal class Product
	{
		// static member shared by all products
		public static double Discount = 10;

		// readonly member
		public readonly long ProductID;

		// instance members
		public string ProductName;

		public double Price;
		public int Quantity;

		// stores all products
		private static List<Product> productList = new List<Product>();

		// parameterized constructor
		public Product(long productID, string productName, double price, int quantity)
		{
			this.ProductID = productID;
			this.ProductName = productName;
			this.Price = price;
			this.Quantity = quantity;
			productList.Add(this);
		}

		// calculates total price after discount
		public double CalculateTotal()
		{
			double total = Price * Quantity;
			return total - (total * Discount / 100);
		}

		// displays product details
		public void DisplayProductDetails()
		{
			Console.WriteLine("Product ID   : " + ProductID);
			Console.WriteLine("Product Name : " + ProductName);
			Console.WriteLine("Price        : " + Price);
			Console.WriteLine("Quantity     : " + Quantity);
			Console.WriteLine("Discount     : " + Discount + "%");
			Console.WriteLine("Total Price  : " + CalculateTotal());
		}

		// static method to update discount
		public static void UpdateDiscount(double newDiscount)
		{
			Discount = newDiscount;
		}

		// displays all products using is operator
		public static void DisplayAllProducts()
		{
			foreach (object obj in productList)
			{
				if (obj is Product product)
				{
					product.DisplayProductDetails();
					Console.WriteLine();
				}
			}
		}
	}

	internal class ShoppingCartSystem
	{
		private static void Main()
		{
			string choice;

			Console.Write("Enter Discount Percentage : ");
			Product.UpdateDiscount(Convert.ToDouble(Console.ReadLine()));

			do
			{
				Console.Write("Enter Product ID : ");
				long id = Convert.ToInt64(Console.ReadLine());

				Console.Write("Enter Product Name : ");
				string name = Console.ReadLine();

				Console.Write("Enter Price : ");
				double price = Convert.ToDouble(Console.ReadLine());

				Console.Write("Enter Quantity : ");
				int qty = Convert.ToInt32(Console.ReadLine());

				new Product(id, name, price, qty);

				Console.Write("Would you like to add more products? (yes/no) : ");
				choice = Console.ReadLine().ToLower();

				Console.WriteLine();
			} while (choice == "yes");

			Product.DisplayAllProducts();

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}