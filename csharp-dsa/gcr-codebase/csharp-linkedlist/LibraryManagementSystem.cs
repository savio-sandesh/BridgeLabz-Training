namespace BridgeLabzTraining.csharp_linkedlist
{
	// Doubly Linked List – Library Management System
	// This program manages library books using a doubly linked list.
	// Each node stores Book ID, Title, Author, Genre, and Availability Status.
	// The system supports insertion, deletion, searching, updating availability,
	// displaying books in forward and reverse order, and counting total books
	// using a menu-driven approach.

	internal class LibraryManagementSystem
	{
		public static void Main()
		{
			DoublyLinkedList library = new DoublyLinkedList();
			int choice;

			do
			{
				Console.WriteLine("1. Add Book at Beginning");
				Console.WriteLine("2. Add Book at End");
				Console.WriteLine("3. Add Book at Position");
				Console.WriteLine("4. Remove Book by Book ID");
				Console.WriteLine("5. Search Book by Title");
				Console.WriteLine("6. Search Book by Author");
				Console.WriteLine("7. Update Book Availability");
				Console.WriteLine("8. Display Books (Forward)");
				Console.WriteLine("9. Display Books (Reverse)");
				Console.WriteLine("10. Count Total Books");
				Console.WriteLine("0. Exit");
				Console.Write("Enter your choice: ");

				choice = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine();

				switch (choice)
				{
					case 1:
						Console.Write("Book ID: ");
						int id1 = Convert.ToInt32(Console.ReadLine());
						Console.Write("Title: ");
						string title1 = Console.ReadLine();
						Console.Write("Author: ");
						string author1 = Console.ReadLine();
						Console.Write("Genre: ");
						string genre1 = Console.ReadLine();
						Console.Write("Available (true/false): ");
						bool avail1 = Convert.ToBoolean(Console.ReadLine());

						library.AddAtBeginning(id1, title1, author1, genre1, avail1);
						break;

					case 2:
						Console.Write("Book ID: ");
						int id2 = Convert.ToInt32(Console.ReadLine());
						Console.Write("Title: ");
						string title2 = Console.ReadLine();
						Console.Write("Author: ");
						string author2 = Console.ReadLine();
						Console.Write("Genre: ");
						string genre2 = Console.ReadLine();
						Console.Write("Available (true/false): ");
						bool avail2 = Convert.ToBoolean(Console.ReadLine());

						library.AddAtEnd(id2, title2, author2, genre2, avail2);
						break;

					case 3:
						Console.Write("Position: ");
						int pos = Convert.ToInt32(Console.ReadLine());
						Console.Write("Book ID: ");
						int id3 = Convert.ToInt32(Console.ReadLine());
						Console.Write("Title: ");
						string title3 = Console.ReadLine();
						Console.Write("Author: ");
						string author3 = Console.ReadLine();
						Console.Write("Genre: ");
						string genre3 = Console.ReadLine();
						Console.Write("Available (true/false): ");
						bool avail3 = Convert.ToBoolean(Console.ReadLine());

						library.AddAtPosition(pos, id3, title3, author3, genre3, avail3);
						break;

					case 4:
						Console.Write("Enter Book ID to remove: ");
						int rid = Convert.ToInt32(Console.ReadLine());
						library.RemoveByBookId(rid);
						break;

					case 5:
						Console.Write("Enter Book Title: ");
						string stitle = Console.ReadLine();
						library.SearchByTitle(stitle);
						break;

					case 6:
						Console.Write("Enter Author Name: ");
						string sauthor = Console.ReadLine();
						library.SearchByAuthor(sauthor);
						break;

					case 7:
						Console.Write("Enter Book ID: ");
						int uid = Convert.ToInt32(Console.ReadLine());
						Console.Write("Available (true/false): ");
						bool newStatus = Convert.ToBoolean(Console.ReadLine());

						library.UpdateAvailability(uid, newStatus);
						break;

					case 8:
						library.DisplayForward();
						break;

					case 9:
						library.DisplayReverse();
						break;

					case 10:
						Console.WriteLine("Total Books: " + library.CountBooks());
						break;

					case 0:
						Console.WriteLine("Exiting program...");
						break;

					default:
						Console.WriteLine("Invalid choice");
						break;
				}

				Console.WriteLine();
			} while (choice != 0);
		}
	}

	// Doubly linked list node
	internal class BookNode
	{
		public int BookId;
		public string Title;
		public string Author;
		public string Genre;
		public bool IsAvailable;
		public BookNode Next;
		public BookNode Prev;

		public BookNode(int id, string title, string author, string genre, bool available)
		{
			BookId = id;
			Title = title;
			Author = author;
			Genre = genre;
			IsAvailable = available;
			Next = null;
			Prev = null;
		}
	}

	// Doubly linked list implementation
	internal class DoublyLinkedList
	{
		private BookNode head;
		private BookNode tail;

		public void AddAtBeginning(int id, string title, string author, string genre, bool available)
		{
			BookNode newNode = new BookNode(id, title, author, genre, available);

			if (head == null)
			{
				head = tail = newNode;
				return;
			}

			newNode.Next = head;
			head.Prev = newNode;
			head = newNode;
		}

		public void AddAtEnd(int id, string title, string author, string genre, bool available)
		{
			BookNode newNode = new BookNode(id, title, author, genre, available);

			if (tail == null)
			{
				head = tail = newNode;
				return;
			}

			tail.Next = newNode;
			newNode.Prev = tail;
			tail = newNode;
		}

		public void AddAtPosition(int position, int id, string title, string author, string genre, bool available)
		{
			if (position == 1)
			{
				AddAtBeginning(id, title, author, genre, available);
				return;
			}

			BookNode temp = head;
			for (int i = 1; i < position - 1 && temp != null; i++)
				temp = temp.Next;

			if (temp == null || temp.Next == null)
			{
				AddAtEnd(id, title, author, genre, available);
				return;
			}

			BookNode newNode = new BookNode(id, title, author, genre, available);
			newNode.Next = temp.Next;
			newNode.Prev = temp;
			temp.Next.Prev = newNode;
			temp.Next = newNode;
		}

		public void RemoveByBookId(int id)
		{
			BookNode temp = head;

			while (temp != null && temp.BookId != id)
				temp = temp.Next;

			if (temp == null)
			{
				Console.WriteLine("Book not found");
				return;
			}

			if (temp == head)
				head = temp.Next;

			if (temp == tail)
				tail = temp.Prev;

			if (temp.Prev != null)
				temp.Prev.Next = temp.Next;

			if (temp.Next != null)
				temp.Next.Prev = temp.Prev;
		}

		public void SearchByTitle(string title)
		{
			BookNode temp = head;

			while (temp != null)
			{
				if (temp.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
				{
					DisplayBook(temp);
					return;
				}
				temp = temp.Next;
			}

			Console.WriteLine("Book not found");
		}

		public void SearchByAuthor(string author)
		{
			BookNode temp = head;

			while (temp != null)
			{
				if (temp.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
				{
					DisplayBook(temp);
					return;
				}
				temp = temp.Next;
			}

			Console.WriteLine("Book not found");
		}

		public void UpdateAvailability(int id, bool status)
		{
			BookNode temp = head;

			while (temp != null)
			{
				if (temp.BookId == id)
				{
					temp.IsAvailable = status;
					Console.WriteLine("Availability updated");
					return;
				}
				temp = temp.Next;
			}

			Console.WriteLine("Book not found");
		}

		public void DisplayForward()
		{
			BookNode temp = head;

			if (temp == null)
			{
				Console.WriteLine("Library is empty");
				return;
			}

			while (temp != null)
			{
				DisplayBook(temp);
				temp = temp.Next;
			}
		}

		public void DisplayReverse()
		{
			BookNode temp = tail;

			if (temp == null)
			{
				Console.WriteLine("Library is empty");
				return;
			}

			while (temp != null)
			{
				DisplayBook(temp);
				temp = temp.Prev;
			}
		}

		public int CountBooks()
		{
			int count = 0;
			BookNode temp = head;

			while (temp != null)
			{
				count++;
				temp = temp.Next;
			}

			return count;
		}

		private void DisplayBook(BookNode book)
		{
			Console.WriteLine($"{book.BookId} | {book.Title} | {book.Author} | {book.Genre} | Available: {book.IsAvailable}");
		}
	}
}