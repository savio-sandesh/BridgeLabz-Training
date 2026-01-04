namespace BridgeLabzTraining.csharp_inheritance
{
	// book class
	// acts as the superclass
	internal class Book
	{
		public string Title;
		public int PublicationYear;

		// displays basic book details
		public void DisplayInfo()
		{
			Console.WriteLine("Book Title        : " + Title);
			Console.WriteLine("Publication Year  : " + PublicationYear);
		}
	}

	// author class
	// inherits from book (single inheritance)
	internal class Author : Book
	{
		public string Name;
		public string Bio;

		// displays book and author details
		public void DisplayAuthorInfo()
		{
			DisplayInfo();
			Console.WriteLine("Author Name       : " + Name);
			Console.WriteLine("Author Bio        : " + Bio);
		}
	}

	internal class LibraryManagement
	{
		private static void Main()
		{
			// creating author object (which is also a book)
			Author author = new Author();

			author.Title = "Think Like a Programmer";
			author.PublicationYear = 2022;
			author.Name = "Sandesh Yadav";
			author.Bio = "Software trainee and learner";

			author.DisplayAuthorInfo();

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}