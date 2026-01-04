namespace BridgeLabzTraining.csharp_accessmodifiers
{
	// employee class
	// demonstrates access modifiers using properties
	internal class Employee
	{
		// public property
		public long EmployeeID { get; set; }

		// protected property
		protected string Department { get; set; }

		// private set property
		public double Salary { get; private set; }

		// stores all employees
		private static List<Employee> employeeList = new List<Employee>();

		// parameterized constructor
		public Employee(long employeeID, string department, double salary)
		{
			EmployeeID = employeeID;
			Department = department;
			Salary = salary;
			employeeList.Add(this);
		}

		// public method to update salary
		public void UpdateSalary(double newSalary)
		{
			Salary = newSalary;
		}

		// displays employee details
		public virtual void DisplayEmployeeDetails()
		{
			Console.WriteLine("Employee ID : " + EmployeeID);
			Console.WriteLine("Department  : " + Department);
			Console.WriteLine("Salary      : INR " + Salary);
		}

		// displays all employees
		public static void DisplayAllEmployees()
		{
			foreach (Employee e in employeeList)
			{
				e.DisplayEmployeeDetails();
				Console.WriteLine();
			}
		}
	}

	// subclass to demonstrate protected access
	internal class Manager : Employee
	{
		public Manager(long employeeID, string department, double salary)
			: base(employeeID, department, salary)
		{
		}

		// accessing public and protected members
		public override void DisplayEmployeeDetails()
		{
			Console.WriteLine("Employee ID : " + EmployeeID);
			Console.WriteLine("Department  : " + Department);
			Console.WriteLine("Salary      : INR " + Salary);
		}
	}

	internal class EmployeeRecords
	{
		private static void Main()
		{
			string choice;

			do
			{
				Console.Write("Enter Employee ID : ");
				long id = Convert.ToInt64(Console.ReadLine());

				Console.Write("Enter Department : ");
				string dept = Console.ReadLine();

				Console.Write("Enter Salary : ");
				double salary = Convert.ToDouble(Console.ReadLine());

				new Manager(id, dept, salary);

				Console.Write("Would you like to add more employees? (yes/no) : ");
				choice = Console.ReadLine().ToLower();

				Console.WriteLine();
			} while (choice == "yes");

			// list all employees
			Employee.DisplayAllEmployees();

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}