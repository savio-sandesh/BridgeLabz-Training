namespace FitTrack
{
	// derived class representing strength-based workouts
	internal class StrengthWorkout : Workout
	{
		public int Sets { get; set; }
		public int Reps { get; set; }

		public override void TrackWorkout()
		{
			CaloriesBurned = CalculateCaloriesBurned();
		}

		public override int CalculateCaloriesBurned()
		{
			return Sets * Reps * 2;
		}

		public override void DisplaySummary()
		{
			base.DisplaySummary();
			Console.WriteLine($"Sets: {Sets}, Reps: {Reps}");
			Console.WriteLine("Workout Type: Strength");
		}
	}
}