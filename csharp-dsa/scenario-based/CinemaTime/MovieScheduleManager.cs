namespace CinemaTime
{
	internal class MovieScheduleManager : IMovieManager
	{
		// Encapsulated data members (arrays)
		private string[] movieTitles;

		private string[] showTimes;
		private int movieCount;

		// Constructor
		public MovieScheduleManager()
		{
			movieTitles = new string[50];   // fixed size
			showTimes = new string[50];
			movieCount = 0;
		}

		// Add movie with time validation
		public void AddMovie(string movieTitle, string showTime)
		{
			if (movieCount >= movieTitles.Length)
			{
				Console.WriteLine("Movie storage is full.");
				return;
			}

			// Time format validation (HH:MM)
			if (showTime.Length != 5 || showTime[2] != ':')
			{
				Console.WriteLine("Invalid Time Format");
				return;
			}

			int hour = int.Parse(showTime.Substring(0, 2));
			int minute = int.Parse(showTime.Substring(3, 2));

			if (hour < 0 || hour > 23 || minute < 0 || minute > 59)
			{
				Console.WriteLine("Invalid Time Value");
				return;
			}

			movieTitles[movieCount] = movieTitle;
			showTimes[movieCount] = showTime;
			movieCount++;

			Console.WriteLine("Movie Added Successfully");
		}

		// Search movie by keyword
		public void SearchMovie(string keyword)
		{
			bool found = false;

			for (int i = 0; i < movieCount; i++)
			{
				if (movieTitles[i].Contains(keyword))
				{
					Console.WriteLine(movieTitles[i] + " - " + showTimes[i]);
					found = true;
				}
			}

			if (!found)
			{
				Console.WriteLine("No movie found");
			}
		}

		// Display all movies
		public void DisplayMovies()
		{
			if (movieCount == 0)
			{
				Console.WriteLine("No movies available");
				return;
			}

			for (int i = 0; i < movieCount; i++)
			{
				Console.WriteLine(movieTitles[i] + " - " + showTimes[i]);
			}
		}

		// Generate printable report (array-based)
		public void GenerateReport()
		{
			Console.WriteLine("\nPrintable Movie Report:");

			for (int i = 0; i < movieCount; i++)
			{
				Console.WriteLine(movieTitles[i] + " - " + showTimes[i]);
			}
		}
	}
}