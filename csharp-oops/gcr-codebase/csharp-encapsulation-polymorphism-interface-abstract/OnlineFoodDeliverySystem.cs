namespace BridgeLabzTraining.csharp_encapsulation_polymorphism_interface_abstract
{
	// Online Food Delivery System using OOP concepts in C#
	// Demonstrates abstraction, encapsulation, inheritance, and polymorphism
	// Handles veg and non-veg food items with pricing and discount logic

	internal class OnlineFoodDeliverySystem
	{
		public static void Main()
		{
			// Polymorphism: base class reference handling different food items
			List<FoodItem> foodItems = new List<FoodItem>();

			foodItems.Add(new VegItem("Paneer Butter Masala", 250, 2));
			foodItems.Add(new NonVegItem("Chicken Biryani", 300, 1));

			foreach (FoodItem item in foodItems)
			{
				Console.WriteLine(item.GetItemDetails());
				Console.WriteLine("Total Price: " + item.CalculateTotalPrice());

				// Interface-based polymorphism for discount handling
				if (item is IDiscountable discountable)
				{
					discountable.ApplyDiscount();
					Console.WriteLine(discountable.GetDiscountDetails());
				}

				Console.WriteLine();
			}
		}
	}

	// Abstract base class defining common food item structure (Abstraction)
	internal abstract class FoodItem
	{
		// Encapsulation: private setters protect item details
		public string ItemName { get; private set; }

		public double Price { get; private set; }
		public int Quantity { get; private set; }

		public FoodItem(string itemName, double price, int quantity)
		{
			ItemName = itemName;
			Price = price;
			Quantity = quantity;
		}

		// Concrete method shared by all food items
		public string GetItemDetails()
		{
			return $"Item: {ItemName}, Price: {Price}, Quantity: {Quantity}";
		}

		// Abstract method forcing subclasses to calculate total price
		public abstract double CalculateTotalPrice();
	}

	// Interface defining discount-related behavior (Abstraction)
	internal interface IDiscountable
	{
		void ApplyDiscount();

		string GetDiscountDetails();
	}

	// VegItem class inheriting FoodItem
	internal class VegItem : FoodItem, IDiscountable
	{
		private const double DiscountRate = 0.10;
		private double discountAmount;

		public VegItem(string itemName, double price, int quantity)
			: base(itemName, price, quantity)
		{
		}

		// Veg item pricing logic
		public override double CalculateTotalPrice()
		{
			return Price * Quantity;
		}

		public void ApplyDiscount()
		{
			discountAmount = CalculateTotalPrice() * DiscountRate;
		}

		public string GetDiscountDetails()
		{
			return "Veg Item Discount Applied: " + discountAmount;
		}
	}

	// NonVegItem class inheriting FoodItem
	internal class NonVegItem : FoodItem, IDiscountable
	{
		private const double ExtraCharge = 50;
		private const double DiscountRate = 0.05;
		private double discountAmount;

		public NonVegItem(string itemName, double price, int quantity)
			: base(itemName, price, quantity)
		{
		}

		// Non-veg item pricing logic with additional charge
		public override double CalculateTotalPrice()
		{
			return (Price * Quantity) + ExtraCharge;
		}

		public void ApplyDiscount()
		{
			discountAmount = CalculateTotalPrice() * DiscountRate;
		}

		public string GetDiscountDetails()
		{
			return "Non-Veg Item Discount Applied: " + discountAmount;
		}
	}
}