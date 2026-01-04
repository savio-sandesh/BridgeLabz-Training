namespace BridgeLabzTraining.csharp_inheritance
{
	// course class
	// acts as the base class
	internal class Course
	{
		public string CourseName;
		public int Duration;
	}

	// online course class
	// inherits from course
	internal class OnlineCourse : Course
	{
		public string Platform;
		public bool IsRecorded;
	}

	// paid online course class
	// inherits from online course (multilevel inheritance)
	internal class PaidOnlineCourse : OnlineCourse
	{
		public double Fee;
		public double Discount;

		// displays complete course details
		public void DisplayCourseDetails()
		{
			Console.WriteLine("Course Name   : " + CourseName);
			Console.WriteLine("Duration      : " + Duration + " months");
			Console.WriteLine("Platform      : " + Platform);
			Console.WriteLine("Recorded      : " + (IsRecorded ? "Yes" : "No"));
			Console.WriteLine("Fee           : INR " + Fee);
			Console.WriteLine("Discount      : INR " + Discount);
		}
	}

	internal class EducationalCourseHierarchy
	{
		private static void Main()
		{
			// creating paid online course object
			PaidOnlineCourse course = new PaidOnlineCourse();

			course.CourseName = "C# Programming";
			course.Duration = 6;
			course.Platform = "Online";
			course.IsRecorded = true;
			course.Fee = 40000;
			course.Discount = 5000;

			course.DisplayCourseDetails();

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}