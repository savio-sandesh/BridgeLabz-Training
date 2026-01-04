namespace BridgeLabzTraining.csharp_objectmodeling
{
	// department class
	// departments exist only inside university (composition)
	internal class Department
	{
		public string Name;

		public Department(string name)
		{
			Name = name;
		}
	}

	// faculty class
	// faculty can exist independently (aggregation)
	internal class Faculty
	{
		public string Name;

		public Faculty(string name)
		{
			Name = name;
		}
	}

	internal class University
	{
		public string Name;

		// composition
		public List<Department> departments;

		// aggregation
		public List<Faculty> faculties;

		public University(string name)
		{
			Name = name;
			departments = new List<Department>();
			faculties = new List<Faculty>();
		}

		public void AddDepartment(Department d)
		{
			departments.Add(d);
			Console.WriteLine("Department added : " + d.Name);
		}

		public void AddFaculty(Faculty f)
		{
			faculties.Add(f);
			Console.WriteLine("Faculty added : " + f.Name);
		}

		public void ShowUniversityDetails()
		{
			Console.WriteLine("University Name : " + Name);

			Console.WriteLine("Departments :");
			foreach (Department d in departments)
			{
				Console.WriteLine("  " + d.Name);
			}

			Console.WriteLine("Faculties :");
			foreach (Faculty f in faculties)
			{
				Console.WriteLine("  " + f.Name);
			}
		}

		private static void Main()
		{
			University uni = new University("City University");

			Department d1 = new Department("Computer Science");
			Department d2 = new Department("Mechanical");

			Faculty f1 = new Faculty("Dr. Sharma");
			Faculty f2 = new Faculty("Dr. Mehta");

			uni.AddDepartment(d1);
			uni.AddDepartment(d2);

			uni.AddFaculty(f1);
			uni.AddFaculty(f2);

			Console.WriteLine();
			uni.ShowUniversityDetails();

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}