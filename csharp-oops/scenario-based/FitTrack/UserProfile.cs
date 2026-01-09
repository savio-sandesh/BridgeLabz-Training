namespace FitTrack
{
	internal class UserProfile
	{
		public int UserId { get; set; }
		public string Name { get; set; }

		private List<Workout> workouts = new List<Workout>();

		public void AddWorkout(Workout workout)
		{
			workouts.Add(workout);
		}

		public void ShowWorkoutHistory()
		{
			foreach (var workout in workouts)
			{
				Console.WriteLine();
				workout.DisplaySummary();
				Console.WriteLine();
			}
		}
	}
}