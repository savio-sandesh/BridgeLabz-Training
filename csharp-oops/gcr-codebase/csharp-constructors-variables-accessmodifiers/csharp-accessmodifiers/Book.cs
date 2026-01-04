namespace BridgeLabzTraining.csharp_accessmodifiers
{
	// book class
	// demonstrates access modifiers using properties
	internal class Book
	{
		// public property
		public long ISBN { get; set; }

		// protected property
		protected string Title { get; set; }

		// private set property
		public string Author { get; private set; }

		// stores all books
		private static List<Book> bookList = new List<Book>();

		// parameterized constructor
		public Book(long isbn, string title, string author)
		{
			ISBN = isbn;
			Title = title;
			Author = author;
			bookList.Add(this);
		}

		// public method to update author
		public void UpdateAuthor(string newAuthor)
		{
			Author = newAuthor;
		}

		// displays book details
		public virtual void DisplayBookDetails()
		{
			Console.WriteLine("ISBN   : " + ISBN);
			Console.WriteLine("Title  : " + Title);
			Console.WriteLine("Author : " + Author);
		}

		// displays all books
		public static void DisplayAllBooks()
		{
			foreach (Book b in bookList)
			{
				b.DisplayBookDetails();
				Console.WriteLine();
			}
		}
	}

	// subclass to demonstrate protected access
	internal class EBook : Book
	{
		public EBook(long isbn, string title, string author)
			: base(isbn, title, author)
		{
		}

		// accessing public and protected properties
		public override void DisplayBookDetails()
		{
			Console.WriteLine("ISBN   : " + ISBN);   // public
			Console.WriteLine("Title  : " + Title);  // protected
			Console.WriteLine("Author : " + Author); // public get
		}
	}

	internal class BookLibrarySystem
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

				new EBook(isbn, title, author);

				Console.Write("Would you like to add more books? (yes/no) : ");
				choice = Console.ReadLine().ToLower();

				Console.WriteLine();
			} while (choice == "yes");

			// list all books
			Book.DisplayAllBooks();

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}