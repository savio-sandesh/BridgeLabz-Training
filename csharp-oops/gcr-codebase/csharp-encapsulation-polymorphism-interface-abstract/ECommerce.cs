namespace BridgeLabzTraining.csharp_encapsulation_polymorphism_interface_abstract
{
	// Driver class (Main will be added later)
	internal class ECommerce
	{
		/*
		Problem Description:
		This program demonstrates a simple e-commerce platform using abstraction,
		inheritance, interfaces, encapsulation, and polymorphism to calculate the final
		price of different product categories.
		*/

		private static void Main(string[] args)
		{
			Product[] products =
			{
			new Electronics(101, "Laptop", 60000),
			new Clothing(102, "Jacket", 3000),
			new Grocery(103, "Rice Bag", 1200)
		};

			Console.WriteLine("E-Commerce Product Details \n");

			foreach (Product product in products)
			{
				double discount = product.CalculateDiscount();
				double tax = 0;
				string taxDetails = "No Tax";

				if (product is ITaxable taxable)
				{
					tax = taxable.CalculateTax();
					taxDetails = taxable.GetTaxDetails();
				}

				double finalPrice = product.Price + tax - discount;

				Console.WriteLine($"Product ID   : {product.ProductId}");
				Console.WriteLine($"Product Name : {product.ProductName}");
				Console.WriteLine($"Base Price   : {product.Price}");
				Console.WriteLine($"Discount     : {discount}");
				Console.WriteLine($"Tax          : {tax}");
				Console.WriteLine($"Tax Details  : {taxDetails}");
				Console.WriteLine($"Final Price  : {finalPrice}");
				Console.WriteLine("--------------------------------------\n");
			}

			Console.ReadLine();
		}
	}
}

// Abstract base class
internal abstract class Product
{
	private int productId;
	private string productName;
	private double price;

	public int ProductId
	{
		get { return productId; }
		set { productId = value; }
	}

	public string ProductName
	{
		get { return productName; }
		set { productName = value; }
	}

	public double Price
	{
		get { return price; }
		set
		{
			if (value >= 0)
				price = value;
			else
				throw new ArgumentException("Price cannot be negative.");
		}
	}

	protected Product(int productId, string productName, double price)
	{
		ProductId = productId;
		ProductName = productName;
		Price = price;
	}

	// Abstract discount method
	public abstract double CalculateDiscount();
}

// Tax interface
internal interface ITaxable
{
	double CalculateTax();

	string GetTaxDetails();
}

// Electronics product
internal class Electronics : Product, ITaxable
{
	public Electronics(int productId, string productName, double price)
		: base(productId, productName, price)
	{
	}

	public override double CalculateDiscount()
	{
		return Price * 0.10; // 10% discount
	}

	public double CalculateTax()
	{
		return Price * 0.18; // 18% tax
	}

	public string GetTaxDetails()
	{
		return "Electronics Tax: 18%";
	}
}

// Clothing product
internal class Clothing : Product, ITaxable
{
	public Clothing(int productId, string productName, double price)
		: base(productId, productName, price)
	{
	}

	public override double CalculateDiscount()
	{
		return Price * 0.20; // 20% discount
	}

	public double CalculateTax()
	{
		return Price * 0.12; // 12% tax
	}

	public string GetTaxDetails()
	{
		return "Clothing Tax: 12%";
	}
}

// Grocery product
internal class Grocery : Product, ITaxable
{
	public Grocery(int productId, string productName, double price)
		: base(productId, productName, price)
	{
	}

	public override double CalculateDiscount()
	{
		return Price * 0.05; // 5% discount
	}

	public double CalculateTax()
	{
		return Price * 0.05; // 5% tax
	}

	public string GetTaxDetails()
	{
		return "Grocery Tax: 5%";
	}
}