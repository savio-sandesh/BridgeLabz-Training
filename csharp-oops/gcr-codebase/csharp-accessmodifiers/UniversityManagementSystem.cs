namespace BridgeLabzTraining.csharp_instance_classmembers
{
	// student class
	// demonstrates use of public, protected and private members
	internal class Student
	{
		// public member
		public long rollNumber;

		// protected member
		protected string name;

		// private member
		private double cgpa;

		// stores all students
		private static List<Student> studentList = new List<Student>();

		// parameterized constructor
		public Student(long rollNumber, string name, double cgpa)
		{
			this.rollNumber = rollNumber;
			this.name = name;
			this.cgpa = cgpa;
			studentList.Add(this);
		}

		// public method to access cgpa
		public double GetCGPA()
		{
			return cgpa;
		}

		// displays student details
		public void DisplayStudentDetails()
		{
			Console.WriteLine("Student Name : " + name);
			Console.WriteLine("Roll Number  : " + rollNumber);
			Console.WriteLine("CGPA       : " + cgpa);
		}

		// displays all students
		public static void DisplayAllStudents()
		{
			foreach (Student s in studentList)
			{
				s.DisplayStudentDetails();
				Console.WriteLine();
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

				Console.Write("Enter CGPA: ");
				double cgpa = Convert.ToDouble(Console.ReadLine());

				new Student(roll, name, cgpa);

				Console.Write("Would you like to add more? (yes/no) : ");
				choice = Console.ReadLine().ToLower();

				Console.WriteLine();
			} while (choice == "yes");

			// list all students
			Student.DisplayAllStudents();

			Console.WriteLine("Press enter to exit...");
			Console.ReadLine();
		}
	}
}