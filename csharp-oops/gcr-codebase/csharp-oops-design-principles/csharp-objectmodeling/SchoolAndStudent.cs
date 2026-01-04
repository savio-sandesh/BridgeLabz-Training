//namespace BridgeLabzTraining.csharp_objectmodeling
//{
//	// school class
//	// demonstrates aggregation with students
//	internal class School
//	{
//		public string Name;
//		private List<Student> students;

//		public School(string name)
//		{
//			Name = name;
//			students = new List<Student>();
//		}

//		// aggregation: school has students
//		public void AddStudent(Student student)
//		{
//			students.Add(student);
//			Console.WriteLine("Student added to school : " + student.Name);
//		}
//	}

//	// student class
//	// demonstrates association with courses
//	internal class Student
//	{
//		public string Name;
//		private List<Course> courses;

//		public Student(string name)
//		{
//			Name = name;
//			courses = new List<Course>();
//		}

//		// association: student enrolls in course
//		public void EnrollCourse(Course course)
//		{
//			courses.Add(course);
//			course.AddStudent(this);
//			Console.WriteLine(Name + " enrolled in " + course.Title);
//		}

//		// shows courses of student
//		public void ShowCourses()
//		{
//			Console.WriteLine("Courses of " + Name + " :");
//			foreach (Course c in courses)
//			{
//				Console.WriteLine("  " + c.Title);
//			}
//		}
//	}

//	// course class
//	// demonstrates association with students
//	internal class Course
//	{
//		public string Title;
//		private List<Student> students;

//		public Course(string title)
//		{
//			Title = title;
//			students = new List<Student>();
//		}

//		public void AddStudent(Student student)
//		{
//			students.Add(student);
//		}

//		// shows students in course
//		public void ShowStudents()
//		{
//			Console.WriteLine("Students in " + Title + " :");
//			foreach (Student s in students)
//			{
//				Console.WriteLine("  " + s.Name);
//			}
//		}
//	}

//	internal class SchoolAndStudent
//	{
//		private static void Main()
//		{
//			School school = new School("City School");

//			Student s1 = new Student("Sandesh");
//			Student s2 = new Student("Riya");

//			school.AddStudent(s1);
//			school.AddStudent(s2);

//			Course c1 = new Course("Math");
//			Course c2 = new Course("Science");
//			Course c3 = new Course("English");

//			s1.EnrollCourse(c1);
//			s1.EnrollCourse(c2);
//			s2.EnrollCourse(c2);
//			s2.EnrollCourse(c3);

//			Console.WriteLine();

//			s1.ShowCourses();
//			Console.WriteLine();

//			c2.ShowStudents();

//			Console.WriteLine("Press Enter to exit...");
//			Console.ReadLine();
//		}
//	}
//}