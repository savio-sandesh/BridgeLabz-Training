namespace BridgeLabzTraining.csharp_constructor
{
	// LibraryBook class
	// Responsible for storing book information and managing borrowing status
	internal class LibraryBook
	{
		// Private attributes to enforce encapsulation
		private string bookTitle;

		private string bookAuthor;
		private int bookPrice;
		private bool isAvailable;

		// Default constructor
		// Creates a book with safe default values
		public LibraryBook()
		{
			bookTitle = "Unknown Title";
			bookAuthor = "Unknown Author";
			bookPrice = 0;
			isAvailable = true;
		}

		// Parameterized constructor
		// Initializes book details when a new book is added to the library
		public LibraryBook(string bookTitle, string bookAuthor, int bookPrice)
		{
			// Using 'this' keyword to avoid ambiguity
			this.bookTitle = bookTitle;
			this.bookAuthor = bookAuthor;
			this.bookPrice = bookPrice;
			this.isAvailable = true;
		}

		// Method to borrow a book
		// Changes availability status only if the book is not already borrowed
		public void BorrowBook()
		{
			if (!isAvailable)
			{
				Console.WriteLine("Book is currently not available for borrowing.");
				return;
			}

			isAvailable = false;
			Console.WriteLine("Book has been borrowed successfully.");
		}

		// Displays complete book information
		// Includes current availability status
		public void ShowBookDetails()
		{
			Console.WriteLine("Book Title  : " + bookTitle);
			Console.WriteLine("Author Name : " + bookAuthor);
			Console.WriteLine("Book Price  : " + bookPrice);
			Console.WriteLine("Status      : " + (isAvailable ? "Available" : "Borrowed"));
		}

		// Entry point of the program
		// Demonstrates object creation and borrowing functionality
		private static void Main(string[] args)
		{
			// Creating a book object using parameterized constructor
			LibraryBook book = new LibraryBook(
				"Thinker Dies Doer Did",
				"Sandesh Yadav",
				499
			);

			Console.WriteLine("Initial Book Details:");
			book.ShowBookDetails();

			Console.WriteLine();

			Console.WriteLine("Borrowing the book...");
			book.BorrowBook();

			Console.WriteLine();

			Console.WriteLine("Updated Book Details:");
			book.ShowBookDetails();

			Console.ReadLine();
		}
	}
}