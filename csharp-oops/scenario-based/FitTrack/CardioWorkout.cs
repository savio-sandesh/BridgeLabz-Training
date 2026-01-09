namespace FitTrack
{
	// derived class representing cardio-based workouts
	internal class CardioWorkout : Workout
	{
		public double DistanceInKm { get; set; }

		public override void TrackWorkout()
		{
			CaloriesBurned = CalculateCaloriesBurned();
		}

		public override int CalculateCaloriesBurned()
		{
			return (int)(DistanceInKm * 60);
		}

		public override void DisplaySummary()
		{
			base.DisplaySummary();
			Console.WriteLine($"Distance: {DistanceInKm} km");
			Console.WriteLine("Workout Type: Cardio");
		}
	}
}