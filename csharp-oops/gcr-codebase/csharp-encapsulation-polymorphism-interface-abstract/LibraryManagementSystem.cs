namespace BridgeLabzTraining.csharp_encapsulation_polymorphism_interface_abstract
{
	// Library Management System using OOP concepts in C#
	// Demonstrates abstraction, encapsulation, inheritance, and polymorphism
	// Manages different library items such as Book, Magazine, and DVD

	internal class LibraryManagementSystem
	{
		public static void Main()
		{
			// Polymorphism: base class reference managing different item types
			List<LibraryItem> items = new List<LibraryItem>();

			items.Add(new Book(101, "White-Washed Lie", "Savio"));
			items.Add(new Magazine(202, "Behind Your Brain", "Aman Yadav"));
			items.Add(new DVD(303, "Code With Me", "Sandesh Yadav"));

			foreach (LibraryItem item in items)
			{
				Console.WriteLine(item.GetItemDetails());
				Console.WriteLine("Loan Duration (days): " + item.GetLoanDuration());

				// Interface-based polymorphism for reservation functionality
				if (item is IReservable reservable)
				{
					Console.WriteLine("Available: " + reservable.CheckAvailability());
					reservable.ReserveItem();
				}
				Console.WriteLine();
			}
		}
	}

	// Abstract base class defining common library item structure (Abstraction)
	internal abstract class LibraryItem
	{
		// Encapsulation: private setters protect item details
		public int ItemId { get; private set; }

		public string Title { get; private set; }
		public string Author { get; private set; }

		// Encapsulation: sensitive borrower data is kept private
		private string borrowerName;

		public LibraryItem(int itemId, string title, string author)
		{
			ItemId = itemId;
			Title = title;
			Author = author;
		}

		// Concrete method shared by all library items
		public string GetItemDetails()
		{
			return $"Item ID: {ItemId}, Title: {Title}, Author: {Author}";
		}

		// Abstract method forcing subclasses to define loan duration
		public abstract int GetLoanDuration();
	}

	// Interface defining reservation behavior (Abstraction)
	internal interface IReservable
	{
		void ReserveItem();

		bool CheckAvailability();
	}

	// Book class inheriting LibraryItem and implementing reservation functionality
	internal class Book : LibraryItem, IReservable
	{
		private bool isAvailable = true;

		public Book(int itemId, string title, string author)
			: base(itemId, title, author)
		{
		}

		// Book-specific loan duration
		public override int GetLoanDuration()
		{
			return 14;
		}

		public void ReserveItem()
		{
			if (isAvailable)
			{
				isAvailable = false;
				Console.WriteLine("Book reserved successfully.");
			}
			else
			{
				Console.WriteLine("Book is already reserved.");
			}
		}

		public bool CheckAvailability()
		{
			return isAvailable;
		}
	}

	// Magazine class inheriting LibraryItem
	internal class Magazine : LibraryItem, IReservable
	{
		private bool isAvailable = true;

		public Magazine(int itemId, string title, string author)
			: base(itemId, title, author)
		{
		}

		// Magazine-specific loan duration
		public override int GetLoanDuration()
		{
			return 7;
		}

		public void ReserveItem()
		{
			if (isAvailable)
			{
				isAvailable = false;
				Console.WriteLine("Magazine reserved successfully.");
			}
			else
			{
				Console.WriteLine("Magazine is already reserved.");
			}
		}

		public bool CheckAvailability()
		{
			return isAvailable;
		}
	}

	// DVD class inheriting LibraryItem
	internal class DVD : LibraryItem, IReservable
	{
		private bool isAvailable = true;

		public DVD(int itemId, string title, string author)
			: base(itemId, title, author)
		{
		}

		// DVD-specific loan duration
		public override int GetLoanDuration()
		{
			return 3;
		}

		public void ReserveItem()
		{
			if (isAvailable)
			{
				isAvailable = false;
				Console.WriteLine("DVD reserved successfully.");
			}
			else
			{
				Console.WriteLine("DVD is already reserved.");
			}
		}

		public bool CheckAvailability()
		{
			return isAvailable;
		}
	}
}