namespace BookBuddy
{
	internal class BookUtility : IBookManager
	{
		// array to store books
		private Book[] books;

		private int bookCount;

		// initialize array
		public BookUtility()
		{
			books = new Book[50]; // fixed size
			bookCount = 0;
		}

		// Add a book
		public void AddBook(Book book)
		{
			// validation to avoid garbage values
			if (string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Author))
			{
				Console.WriteLine("Book title or author cannot be empty.");
				return;
			}

			if (bookCount >= books.Length)
			{
				Console.WriteLine("Book storage is full.");
				return;
			}

			books[bookCount] = book;
			bookCount++;

			Console.WriteLine("Book added successfully.");
		}

		// Display all books
		public void DisplayBooks()
		{
			if (bookCount == 0)
			{
				Console.WriteLine("No books available.");
				return;
			}

			for (int i = 0; i < bookCount; i++)
			{
				Console.WriteLine(books[i].Title + " - " + books[i].Author);
			}
		}

		// Search books by author
		public void SearchByAuthor(string author)
		{
			if (bookCount == 0)
			{
				Console.WriteLine("No books available to search.");
				return;
			}

			bool found = false;

			for (int i = 0; i < bookCount; i++)
			{
				if (books[i].Author.Equals(author, StringComparison.OrdinalIgnoreCase))
				{
					Console.WriteLine(books[i].Title + " - " + books[i].Author);
					found = true;
				}
			}

			if (!found)
			{
				Console.WriteLine("No books found for the given author.");
			}
		}

		// Sort books alphabetically using Bubble Sort
		public void SortBooksAlphabetically()
		{
			if (bookCount == 0)
			{
				Console.WriteLine("No books available to sort.");
				return;
			}

			for (int i = 0; i < bookCount - 1; i++)
			{
				for (int j = 0; j < bookCount - i - 1; j++)
				{
					if (string.Compare(books[j].Title, books[j + 1].Title) > 0)
					{
						// swap books
						Book temp = books[j];
						books[j] = books[j + 1];
						books[j + 1] = temp;
					}
				}
			}

			Console.WriteLine("Books sorted alphabetically by title.");
		}
	}
}