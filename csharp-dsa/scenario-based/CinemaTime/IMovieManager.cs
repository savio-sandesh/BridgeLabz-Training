namespace CinemaTime
{
	internal interface IMovieManager
	{
		void AddMovie(string movieTitle, string showTime);

		void SearchMovie(string keyword);

		void DisplayMovies();

		void GenerateReport();
	}
}