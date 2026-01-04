namespace BridgeLabzTraining.csharp_instance_classmembers
{
	// Course class
	// Demonstrates instance and class (static) members
	internal class OnlineCourse
	{
		// Instance variables
		private string courseName;

		private int duration;
		private int fee;

		// Class variable (shared)
		private static string instituteName = "BridgeLabz";

		// Stores all courses entered
		private static List<OnlineCourse> courseList = new List<OnlineCourse>();

		// Parameterized constructor
		public OnlineCourse(string courseName, int duration, int fee)
		{
			this.courseName = courseName;
			this.duration = duration;
			this.fee = fee;
			courseList.Add(this);
		}

		// Instance method
		// Displays course details
		public void DisplayCourseDetails()
		{
			Console.WriteLine("Institute Name : " + instituteName);
			Console.WriteLine("Course Name    : " + courseName);
			Console.WriteLine("Duration       : " + duration + " months");
			Console.WriteLine("Fee            : INR " + fee);
		}

		// Class method
		// Updates institute name for all courses
		public static void UpdateInstituteName(string newName)
		{
			instituteName = newName;
		}

		// Displays all courses entered so far
		public static void DisplayAllCourses()
		{
			Console.WriteLine("\nCourses Entered So Far:");
			foreach (OnlineCourse c in courseList)
			{
				c.DisplayCourseDetails();
				Console.WriteLine();
			}
		}

		private static void Main()
		{
			/*
             Problem 2: Online Course Management
             Demonstrates instance vs class variables and methods
            */

			Console.Write("Enter Institute Name : ");
			UpdateInstituteName(Console.ReadLine());

			string choice;

			do
			{
				Console.Write("Enter Course Name : ");
				string name = Console.ReadLine();

				Console.Write("Enter Duration (months) : ");
				int duration = Convert.ToInt32(Console.ReadLine());

				Console.Write("Enter Fee : ");
				int fee = Convert.ToInt32(Console.ReadLine());

				new OnlineCourse(name, duration, fee);

				Console.Write("Would you like to add more courses? (yes/no) : ");
				choice = Console.ReadLine().ToLower();

				// List all courses entered so far
				DisplayAllCourses();
			} while (choice == "yes");

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}