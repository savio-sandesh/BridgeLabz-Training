namespace FitTrack
{
	// interface defining workout tracking behavior
	internal interface ITrackable
	{
		void TrackWorkout();

		int CalculateCaloriesBurned();

		void DisplaySummary();
	}
}