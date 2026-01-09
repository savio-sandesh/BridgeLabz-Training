//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
namespace FitTrack
{
	internal class FitTrack
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Welcome to FitTrack – Your Fitness Tracker");

			UserProfile user = new UserProfile();

			Console.Write("Enter User ID: ");
			user.UserId = Convert.ToInt32(Console.ReadLine());

			Console.Write("Enter Name: ");
			user.Name = Console.ReadLine();

			int choice;

			do
			{
				Console.WriteLine("\n FitTrack Menu :");
				Console.WriteLine("1. Add Cardio Workout");
				Console.WriteLine("2. Add Strength Workout");
				Console.WriteLine("3. View Workout History");
				Console.WriteLine("0. Exit");
				Console.Write("Enter choice: ");

				choice = Convert.ToInt32(Console.ReadLine());

				switch (choice)
				{
					case 1:
						AddCardioWorkout(user);
						break;

					case 2:
						AddStrengthWorkout(user);
						break;

					case 3:
						user.ShowWorkoutHistory();
						break;

					case 0:
						Console.WriteLine("Exiting FitTrack. Stay Healthy, Stay Happy");
						break;

					default:
						Console.WriteLine("Invalid choice. Try again.");
						break;
				}
			} while (choice != 0);
		}

		private static void AddCardioWorkout(UserProfile user)
		{
			CardioWorkout cardio = new CardioWorkout();

			Console.Write("Workout Name: ");
			cardio.WorkoutName = Console.ReadLine();

			Console.Write("Duration (minutes): ");
			cardio.DurationInMinutes = Convert.ToInt32(Console.ReadLine());

			Console.Write("Distance (km): ");
			cardio.DistanceInKm = Convert.ToDouble(Console.ReadLine());

			cardio.TrackWorkout();
			user.AddWorkout(cardio);

			Console.WriteLine("Cardio workout added successfully!");
		}

		private static void AddStrengthWorkout(UserProfile user)
		{
			StrengthWorkout strength = new StrengthWorkout();

			Console.Write("Workout Name: ");
			strength.WorkoutName = Console.ReadLine();

			Console.Write("Duration (minutes): ");
			strength.DurationInMinutes = Convert.ToInt32(Console.ReadLine());

			Console.Write("Sets: ");
			strength.Sets = Convert.ToInt32(Console.ReadLine());

			Console.Write("Reps: ");
			strength.Reps = Convert.ToInt32(Console.ReadLine());

			strength.TrackWorkout();
			user.AddWorkout(strength);

			Console.WriteLine("Strength workout added successfully!");
		}
	}
}