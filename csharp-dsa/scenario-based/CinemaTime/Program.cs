//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

namespace CinemaTime
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			IMovieManager cinema = new MovieScheduleManager();
			bool exit = false;

			while (!exit)
			{
				Console.WriteLine("\nCinemaTime – Movie Schedule Manager");
				Console.WriteLine("1. Add Movie");
				Console.WriteLine("2. Display All Movies");
				Console.WriteLine("3. Search Movie");
				Console.WriteLine("4. Generate Report");
				Console.WriteLine("5. Exit");
				Console.Write("Enter your choice: ");

				int choice = int.Parse(Console.ReadLine());

				switch (choice)
				{
					case 1:
						Console.Write("Enter movie title: ");
						string title = Console.ReadLine();

						Console.Write("Enter showtime (HH:MM): ");
						string time = Console.ReadLine();

						cinema.AddMovie(title, time);
						break;

					case 2:
						cinema.DisplayMovies();
						break;

					case 3:
						Console.Write("Enter keyword to search: ");
						string keyword = Console.ReadLine();

						cinema.SearchMovie(keyword);
						break;

					case 4:
						cinema.GenerateReport();
						break;

					case 5:
						exit = true;
						Console.WriteLine("Exiting CinemaTime. Thank you!");
						break;

					default:
						Console.WriteLine("Invalid choice. Please try again.");
						break;
				}
			}
		}
	}
}