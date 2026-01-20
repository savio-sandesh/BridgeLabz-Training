namespace BookBuddy
{
	internal class BookMain
	{
		public void StartApplication()
		{
			IBookManager bookManager = new BookUtility();
			bool exit = false;

			while (!exit)
			{
				int choice = BookMenu.ShowMenu();

				switch (choice)
				{
					case 1:
						// Add Book
						Book book = new Book();

						Console.Write("Enter book title: ");
						string title = Console.ReadLine()!;

						Console.Write("Enter author name: ");
						string author = Console.ReadLine()!;

						// validation to avoid garbage input
						if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author))
						{
							Console.WriteLine("Title and Author cannot be empty.");
						}
						else
						{
							book.Title = title;
							book.Author = author;
							bookManager.AddBook(book);
						}
						break;

					case 2:
						// Display all books
						bookManager.DisplayBooks();
						break;

					case 3:
						// Search book by author
						Console.Write("Enter author name to search: ");
						string searchAuthor = Console.ReadLine()!;

						if (string.IsNullOrEmpty(searchAuthor))
						{
							Console.WriteLine("Author name cannot be empty.");
						}
						else
						{
							bookManager.SearchByAuthor(searchAuthor);
						}
						break;

					case 4:
						// Sort books alphabetically
						bookManager.SortBooksAlphabetically();
						break;

					case 5:
						exit = true;
						Console.WriteLine("Exiting BookBuddy. Thank you!");
						break;

					default:
						Console.WriteLine("Invalid choice. Please try again.");
						break;
				}
			}
		}
	}
}