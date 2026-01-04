namespace BridgeLabzTraining.csharp_objectmodeling
{
	// course class
	internal class Course
	{
		public string Name;
		public List<Student> students;
		public Professor professor;

		public Course(string name)
		{
			Name = name;
			students = new List<Student>();
		}

		public void ShowCourseDetails()
		{
			Console.WriteLine("Course : " + Name);

			if (professor != null)
				Console.WriteLine("Professor : " + professor.Name);

			Console.WriteLine("Students :");
			foreach (Student s in students)
			{
				Console.WriteLine("  " + s.Name);
			}
		}
	}

	// student class
	internal class Student
	{
		public string Name;
		public List<Course> courses;

		public Student(string name)
		{
			Name = name;
			courses = new List<Course>();
		}

		// communication: student enrolls in course
		public void EnrollCourse(Course course)
		{
			courses.Add(course);
			course.students.Add(this);
			Console.WriteLine(Name + " enrolled in " + course.Name);
		}
	}

	// professor class
	internal class Professor
	{
		public string Name;

		public Professor(string name)
		{
			Name = name;
		}

		// communication: professor assigned to course
		public void AssignCourse(Course course)
		{
			course.professor = this;
			Console.WriteLine(Name + " assigned to " + course.Name);
		}
	}

	internal class UniversityManagementSystem
	{
		private static void Main()
		{
			Student s1 = new Student("Sandesh");
			Student s2 = new Student("Riya");

			Professor p1 = new Professor("Dr. Sharma");

			Course c1 = new Course("Math");
			Course c2 = new Course("Science");

			p1.AssignCourse(c1);

			s1.EnrollCourse(c1);
			s1.EnrollCourse(c2);
			s2.EnrollCourse(c1);

			Console.WriteLine();

			c1.ShowCourseDetails();

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}