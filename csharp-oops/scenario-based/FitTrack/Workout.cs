namespace FitTrack
{
	// abstract base class for all workout types
	internal abstract class Workout : ITrackable
	{
		public string WorkoutName { get; set; }
		public int DurationInMinutes { get; set; }
		public int CaloriesBurned { get; protected set; }

		public abstract void TrackWorkout();

		public abstract int CalculateCaloriesBurned();

		public virtual void DisplaySummary()
		{
			Console.WriteLine($"Workout: {WorkoutName}");
			Console.WriteLine($"Duration: {DurationInMinutes} minutes");
			Console.WriteLine($"Calories Burned: {CaloriesBurned}");
		}
	}
}