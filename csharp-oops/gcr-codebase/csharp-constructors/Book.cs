namespace BridgeLabzTraining.csharp_constructor
{
	internal class Book
	{
		// Fields to store book details
		private string bookTitle;

		private string authorName;
		private double bookPrice;

		// default Constructor
		public Book()
		{
			bookTitle = "Unknown Title";
			authorName = "Unknown Author";
			bookPrice = 0.0;
		}

		// Constructor Chaining
		//	public Book() : this("Unknown", 0.0)
		//	{
		//	}

		// parameterized Constructor to initialize book object
		public Book(string bookTitle, string authorName, double bookPrice)
		{
			this.bookTitle = bookTitle;
			this.authorName = authorName;
			this.bookPrice = bookPrice;
		}

		private static void Main(string[] args)
		{
			Console.WriteLine("Enter Book Title:");
			string title = Console.ReadLine()!;

			Console.WriteLine("Enter Author Name:");
			string author = Console.ReadLine()!;

			Console.WriteLine("Enter Book Price:");
			double price = double.Parse(Console.ReadLine()!);

			Book book = new Book(title, author, price);

			Console.WriteLine("Book Title: " + book.bookTitle);
			Console.WriteLine("Author Name: " + book.authorName);
			Console.WriteLine("Book Price: " + book.bookPrice);
		}
	}
}