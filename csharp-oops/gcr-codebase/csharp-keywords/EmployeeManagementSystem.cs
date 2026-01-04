namespace BridgeLabzTraining.csharp_keywords
{
	// employee class
	// demonstrates static, this, readonly and is operator
	internal class Employee
	{
		// static member shared by all employees
		public static string CompanyName = "Mera Office Pvt Ltd";

		// static counter
		private static int totalEmployees = 0;

		// readonly member
		public readonly long Id;

		// instance members
		public string Name;

		public string Designation;

		// stores all employees
		private static List<Employee> employeeList = new List<Employee>();

		// parameterized constructor
		public Employee(long id, string name, string designation)
		{
			this.Id = id;
			this.Name = name;
			this.Designation = designation;
			totalEmployees++;
			employeeList.Add(this);
		}

		// displays employee details
		public void DisplayEmployeeDetails()
		{
			Console.WriteLine("Company Name : " + CompanyName);
			Console.WriteLine("Employee ID  : " + Id);
			Console.WriteLine("Name         : " + Name);
			Console.WriteLine("Designation  : " + Designation);
		}

		// static method to display total employees
		public static void DisplayTotalEmployees()
		{
			Console.WriteLine("Total Employees : " + totalEmployees);
		}

		// displays all employees using is operator
		public static void DisplayAllEmployees()
		{
			foreach (object obj in employeeList)
			{
				if (obj is Employee emp)
				{
					emp.DisplayEmployeeDetails();
					Console.WriteLine();
				}
			}
		}
	}

	internal class EmployeeManagementSystem
	{
		private static void Main()
		{
			string choice;

			do
			{
				Console.Write("Enter Employee ID : ");
				long id = Convert.ToInt64(Console.ReadLine());

				Console.Write("Enter Employee Name : ");
				string name = Console.ReadLine();

				Console.Write("Enter Designation : ");
				string designation = Console.ReadLine();

				new Employee(id, name, designation);

				Console.Write("Would you like to add more employees? (yes/no) : ");
				choice = Console.ReadLine().ToLower();

				Console.WriteLine();
			} while (choice == "yes");

			Employee.DisplayAllEmployees();
			Employee.DisplayTotalEmployees();

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}