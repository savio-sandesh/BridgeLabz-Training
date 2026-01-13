namespace BookBuddy
{
	internal class BookMenu
	{
		// Displays menu and returns user choice
		public static int ShowMenu()
		{
			Console.WriteLine("\nBookBuddy – Digital Bookshelf ");
			Console.WriteLine("1. Add Book");
			Console.WriteLine("2. Display All Books");
			Console.WriteLine("3. Search Book by Author");
			Console.WriteLine("4. Sort Books Alphabetically");
			Console.WriteLine("5. Exit");
			Console.Write("Enter your choice: ");

			int choice = int.Parse(Console.ReadLine());
			return choice;
		}
	}
}