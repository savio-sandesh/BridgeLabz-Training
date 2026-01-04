namespace BridgeLabzTraining.csharp_keywords
{
	// student class
	// demonstrates static, this, readonly and is operator
	internal class Student
	{
		// static member shared by all students
		public static string UniversityName = "GLA University";

		// static counter
		private static int totalStudents = 0;

		// readonly member
		public readonly long RollNumber;

		// instance members
		public string Name;

		public string Grade;

		// stores all students
		private static List<Student> studentList = new List<Student>();

		// parameterized constructor
		public Student(long rollNumber, string name, string grade)
		{
			this.RollNumber = rollNumber;
			this.Name = name;
			this.Grade = grade;
			totalStudents++;
			studentList.Add(this);
		}

		// displays student details
		public void DisplayStudentDetails()
		{
			Console.WriteLine("University Name : " + UniversityName);
			Console.WriteLine("Roll Number     : " + RollNumber);
			Console.WriteLine("Student Name    : " + Name);
			Console.WriteLine("Grade           : " + Grade);
		}

		// static method to display total students
		public static void DisplayTotalStudents()
		{
			Console.WriteLine("Total Students : " + totalStudents);
		}

		// displays all students using is operator
		public static void DisplayAllStudents()
		{
			foreach (object obj in studentList)
			{
				if (obj is Student student)
				{
					student.DisplayStudentDetails();
					Console.WriteLine();
				}
			}
		}
	}

	internal class UniversityManagementSystem
	{
		private static void Main()
		{
			string choice;

			do
			{
				Console.Write("Enter Roll Number : ");
				long roll = Convert.ToInt64(Console.ReadLine());

				Console.Write("Enter Student Name : ");
				string name = Console.ReadLine();

				Console.Write("Enter Grade : ");
				string grade = Console.ReadLine();

				new Student(roll, name, grade);

				Console.Write("Would you like to add more students? (yes/no) : ");
				choice = Console.ReadLine().ToLower();

				Console.WriteLine();
			} while (choice == "yes");

			Student.DisplayAllStudents();
			Student.DisplayTotalStudents();

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}