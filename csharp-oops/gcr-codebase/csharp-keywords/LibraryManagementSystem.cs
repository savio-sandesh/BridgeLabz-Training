namespace BridgeLabzTraining.csharp_keywords
{
	// book class
	// demonstrates static, this, readonly and is operator
	internal class Book
	{
		// static member shared by all books
		public static string LibraryName = "Central Library";

		// readonly member
		public readonly long ISBN;

		// instance members
		public string Title;

		public string Author;

		// stores all books
		private static List<Book> bookList = new List<Book>();

		// parameterized constructor
		public Book(long isbn, string title, string author)
		{
			this.ISBN = isbn;
			this.Title = title;
			this.Author = author;
			bookList.Add(this);
		}

		// displays book details
		public void DisplayBookDetails()
		{
			Console.WriteLine("Library Name : " + LibraryName);
			Console.WriteLine("ISBN         : " + ISBN);
			Console.WriteLine("Title        : " + Title);
			Console.WriteLine("Author       : " + Author);
		}

		// static method to display library name
		public static void DisplayLibraryName()
		{
			Console.WriteLine("Library Name : " + LibraryName);
		}

		// displays all books using is operator
		public static void DisplayAllBooks()
		{
			foreach (object obj in bookList)
			{
				if (obj is Book book)
				{
					book.DisplayBookDetails();
					Console.WriteLine();
				}
			}
		}
	}

	internal class LibraryManagementSystem
	{
		private static void Main()
		{
			string choice;

			do
			{
				Console.Write("Enter ISBN : ");
				long isbn = Convert.ToInt64(Console.ReadLine());

				Console.Write("Enter Book Title : ");
				string title = Console.ReadLine();

				Console.Write("Enter Author Name : ");
				string author = Console.ReadLine();

				new Book(isbn, title, author);

				Console.Write("Would you like to add more books? (yes/no) : ");
				choice = Console.ReadLine().ToLower();

				Console.WriteLine();
			} while (choice == "yes");

			Book.DisplayAllBooks();

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}