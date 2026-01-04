namespace BridgeLabzTraining.csharp_inheritance
{
	// person class
	// acts as the superclass
	internal class Person
	{
		public string Name;
		public int Age;
	}

	// teacher class
	// inherits from person
	internal class Teacher : Person
	{
		public string Subject;

		public void DisplayRole()
		{
			Console.WriteLine("Role    : Teacher");
			Console.WriteLine("Name    : " + Name);
			Console.WriteLine("Age     : " + Age);
			Console.WriteLine("Subject : " + Subject);
		}
	}

	// student class
	// inherits from person
	internal class Student : Person
	{
		public string Grade;

		public void DisplayRole()
		{
			Console.WriteLine("Role  : Student");
			Console.WriteLine("Name  : " + Name);
			Console.WriteLine("Age   : " + Age);
			Console.WriteLine("Grade : " + Grade);
		}
	}

	// staff class
	// inherits from person
	internal class Staff : Person
	{
		public string Department;

		public void DisplayRole()
		{
			Console.WriteLine("Role       : Staff");
			Console.WriteLine("Name       : " + Name);
			Console.WriteLine("Age        : " + Age);
			Console.WriteLine("Department : " + Department);
		}
	}

	internal class SchoolSystem
	{
		private static void Main()
		{
			// teacher object
			Teacher teacher = new Teacher();
			teacher.Name = "Sandesh";
			teacher.Age = 30;
			teacher.Subject = "C#";

			teacher.DisplayRole();
			Console.WriteLine();

			// student object
			Student student = new Student();
			student.Name = "Amit";
			student.Age = 20;
			student.Grade = "A";

			student.DisplayRole();
			Console.WriteLine();

			// staff object
			Staff staff = new Staff();
			staff.Name = "Ramesh";
			staff.Age = 35;
			staff.Department = "Administration";

			staff.DisplayRole();

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}