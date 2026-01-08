namespace BridgeLabzTraining.csharp_linkedlist
{
	// Doubly Linked List – Movie Management System
	// This program manages movie records using a doubly linked list.
	// Each node stores movie details such as title, director, year of release, and rating.
	// The system supports insertion, deletion, searching, updating, and displaying records
	// in both forward and reverse order. Movie ratings are maintained on a 0–5 scale.

	internal class MovieManagementSystem
	{
		public static void Main()
		{
			MovieDoublyLinkedList list = new MovieDoublyLinkedList();
			int choice;

			do
			{
				Console.WriteLine();
				Console.WriteLine("1. Add Movie at Beginning");
				Console.WriteLine("2. Add Movie at End");
				Console.WriteLine("3. Add Movie at Position");
				Console.WriteLine("4. Remove Movie by Title");
				Console.WriteLine("5. Search Movie by Director");
				Console.WriteLine("6. Search Movie by Rating");
				Console.WriteLine("7. Display Movies (Forward)");
				Console.WriteLine("8. Display Movies (Reverse)");
				Console.WriteLine("9. Update Movie Rating");
				Console.WriteLine("0. Exit");
				Console.Write("Enter your choice: ");

				choice = Convert.ToInt32(Console.ReadLine());

				switch (choice)
				{
					case 1:
						list.AddAtBeginning(ReadMovie());
						break;

					case 2:
						list.AddAtEnd(ReadMovie());
						break;

					case 3:
						Console.Write("Enter Position: ");
						int pos = Convert.ToInt32(Console.ReadLine());
						list.AddAtPosition(pos, ReadMovie());
						break;

					case 4:
						Console.Write("Enter Movie Title to Remove: ");
						string removeTitle = Console.ReadLine();
						list.RemoveByTitle(removeTitle);
						break;

					case 5:
						Console.Write("Enter Director Name: ");
						string director = Console.ReadLine();
						list.SearchByDirector(director);
						break;

					case 6:
						double searchRating;
						do
						{
							Console.Write("Enter Rating to Search (0–5): ");
							searchRating = Convert.ToDouble(Console.ReadLine());
						} while (searchRating < 0 || searchRating > 5);

						list.SearchByRating(searchRating);
						break;

					case 7:
						list.DisplayForward();
						break;

					case 8:
						list.DisplayReverse();
						break;

					case 9:
						Console.Write("Enter Movie Title: ");
						string updateTitle = Console.ReadLine();

						double newRating;
						do
						{
							Console.Write("Enter New Rating (0–5): ");
							newRating = Convert.ToDouble(Console.ReadLine());
						} while (newRating < 0 || newRating > 5);

						list.UpdateRating(updateTitle, newRating);
						break;

					case 0:
						Console.WriteLine("Exiting program...");
						break;

					default:
						Console.WriteLine("Invalid choice");
						break;
				}
			} while (choice != 0);
		}

		// Method to read movie details with rating validation
		private static MovieNode ReadMovie()
		{
			Console.Write("Movie Title: ");
			string title = Console.ReadLine();

			Console.Write("Director: ");
			string director = Console.ReadLine();

			Console.Write("Year of Release: ");
			int year = Convert.ToInt32(Console.ReadLine());

			double rating;
			do
			{
				Console.Write("Rating (0–5): ");
				rating = Convert.ToDouble(Console.ReadLine());
				if (rating < 0 || rating > 5)
					Console.WriteLine("Invalid rating. Please enter between 0 and 5.");
			} while (rating < 0 || rating > 5);

			return new MovieNode(title, director, year, rating);
		}
	}

	// Node class representing a movie
	internal class MovieNode
	{
		public string Title;
		public string Director;
		public int Year;
		public double Rating;
		public MovieNode Next;
		public MovieNode Prev;

		public MovieNode(string title, string director, int year, double rating)
		{
			Title = title;
			Director = director;
			Year = year;
			Rating = rating;
			Next = null;
			Prev = null;
		}
	}

	// Doubly Linked List implementation
	internal class MovieDoublyLinkedList
	{
		private MovieNode head;
		private MovieNode tail;

		public void AddAtBeginning(MovieNode newNode)
		{
			if (head == null)
			{
				head = tail = newNode;
				return;
			}

			newNode.Next = head;
			head.Prev = newNode;
			head = newNode;
		}

		public void AddAtEnd(MovieNode newNode)
		{
			if (tail == null)
			{
				head = tail = newNode;
				return;
			}

			tail.Next = newNode;
			newNode.Prev = tail;
			tail = newNode;
		}

		public void AddAtPosition(int position, MovieNode newNode)
		{
			if (position <= 1)
			{
				AddAtBeginning(newNode);
				return;
			}

			MovieNode temp = head;
			for (int i = 1; i < position - 1 && temp != null; i++)
				temp = temp.Next;

			if (temp == null || temp.Next == null)
			{
				AddAtEnd(newNode);
				return;
			}

			newNode.Next = temp.Next;
			newNode.Prev = temp;
			temp.Next.Prev = newNode;
			temp.Next = newNode;
		}

		public void RemoveByTitle(string title)
		{
			MovieNode temp = head;

			while (temp != null)
			{
				if (temp.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
				{
					if (temp == head) head = temp.Next;
					if (temp == tail) tail = temp.Prev;
					if (temp.Prev != null) temp.Prev.Next = temp.Next;
					if (temp.Next != null) temp.Next.Prev = temp.Prev;

					Console.WriteLine("Movie removed successfully");
					return;
				}
				temp = temp.Next;
			}

			Console.WriteLine("Movie not found");
		}

		public void UpdateRating(string title, double newRating)
		{
			MovieNode temp = head;

			while (temp != null)
			{
				if (temp.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
				{
					temp.Rating = newRating;
					Console.WriteLine("Rating updated successfully");
					return;
				}
				temp = temp.Next;
			}

			Console.WriteLine("Movie not found");
		}

		public void SearchByDirector(string director)
		{
			MovieNode temp = head;
			bool found = false;

			while (temp != null)
			{
				if (temp.Director.Equals(director, StringComparison.OrdinalIgnoreCase))
				{
					PrintMovie(temp);
					found = true;
				}
				temp = temp.Next;
			}

			if (!found)
				Console.WriteLine("No movies found for the given director");
		}

		public void SearchByRating(double rating)
		{
			MovieNode temp = head;
			bool found = false;

			while (temp != null)
			{
				if (temp.Rating == rating)
				{
					PrintMovie(temp);
					found = true;
				}
				temp = temp.Next;
			}

			if (!found)
				Console.WriteLine("No movies found with the given rating");
		}

		public void DisplayForward()
		{
			MovieNode temp = head;

			if (temp == null)
			{
				Console.WriteLine("No movie records available");
				return;
			}

			while (temp != null)
			{
				PrintMovie(temp);
				temp = temp.Next;
			}
		}

		public void DisplayReverse()
		{
			MovieNode temp = tail;

			if (temp == null)
			{
				Console.WriteLine("No movie records available");
				return;
			}

			while (temp != null)
			{
				PrintMovie(temp);
				temp = temp.Prev;
			}
		}

		private void PrintMovie(MovieNode node)
		{
			Console.WriteLine($"{node.Title} | {node.Director} | {node.Year} | Rating: {node.Rating}/5");
		}
	}
}