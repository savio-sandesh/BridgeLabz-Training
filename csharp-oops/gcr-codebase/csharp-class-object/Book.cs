namespace BridgeLabzTraining.csharp_class_object
{
	// This program demonstrates basic object-oriented programming in C#
	// by modeling a Book entity. The Book class stores essential details
	// such as title, author, and price, initializes them using a constructor,
	// and provides a method to display the book information.
	// User input is taken in the Main method, and the object is created and used accordingly.
	internal class Book
	{
		// Fields to store book details
		string bookTitle;
		string authorName;
		double bookPrice;

		// Constructor to initialize book object
		public Book(string bookTitle, string authorName, double bookPrice)
		{
			this.bookTitle = bookTitle;
			this.authorName = authorName;
			this.bookPrice = bookPrice;
		}

		// Displays the book details
		void DisplayBookDetails()
		{
			Console.WriteLine("Book Title: " + bookTitle);
			Console.WriteLine("Author Name: " + authorName);
			Console.WriteLine("Book Price: " + bookPrice);
		}

		// Entry point of the program
		static void Main(string[] args)
		{
			Console.WriteLine("Enter Book Title:");
			string title = Console.ReadLine()!;

			Console.WriteLine("Enter Author Name:");
			string author = Console.ReadLine()!;

			Console.WriteLine("Enter Book Price:");
			double price = double.Parse(Console.ReadLine()!);

			Book book = new Book(title, author, price);
			book.DisplayBookDetails();
		}
	}
}
