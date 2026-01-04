namespace BridgeLabzTraining.csharp_instance_classmembers
{
	// Product class
	// Demonstrates instance and class (static) variables and methods
	internal class Product
	{
		// Instance variables
		private string productName;

		private int price;

		// Class variables
		private static int totalProducts = 0;

		private static List<Product> productList = new List<Product>();

		// Parameterized constructor
		public Product(string productName, int price)
		{
			this.productName = productName;
			this.price = price;
			totalProducts++;
			productList.Add(this);
		}

		// Instance method
		public void DisplayProductDetails()
		{
			Console.WriteLine("Product Name : " + productName);
			Console.WriteLine("Price        : INR " + price);
		}

		// Class method
		public static void DisplayTotalProducts()
		{
			Console.WriteLine("Total Products Created : " + totalProducts);
		}

		// Displays all products entered so far
		public static void DisplayAllProducts()
		{
			Console.WriteLine("\nProducts Entered So Far:");
			foreach (Product p in productList)
			{
				p.DisplayProductDetails();
				Console.WriteLine();
			}
		}

		private static void Main()
		{
			string choice;

			do
			{
				Console.Write("Enter Product Name : ");
				string name = Console.ReadLine();

				Console.Write("Enter Product Price : ");
				int price = Convert.ToInt32(Console.ReadLine());

				new Product(name, price);

				Console.Write("Would you like to add more products? (yes/no) : ");
				choice = Console.ReadLine().ToLower();

				// List all products after the question
				DisplayAllProducts();
			} while (choice == "yes");

			DisplayTotalProducts();

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}