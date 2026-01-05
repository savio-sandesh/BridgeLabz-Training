namespace BridgeLabzTraining.csharp_encapsulation_polymorphism_interface_abstract
{
	internal class EmployeeManagementSystem
	{
		private static void Main(string[] args)
		{
			// polymorphism: base class reference holding derived objects
			Employee emp1 = new FullTimeEmployee(101, "Sandesh", 0, 50000);
			Employee emp2 = new PartTimeEmployee(102, "Prakhar", 500, 20);

			// interface method usage
			emp1.AssignDepartment("HR");
			emp2.AssignDepartment("IT");

			// calling overridden methods using employee reference
			Console.WriteLine($"employee name: {emp1.EmployeeName}");
			Console.WriteLine($"salary: {emp1.CalculateSalary()}");
			Console.WriteLine($"department: {emp1.GetDepartmentDetails()}");

			Console.WriteLine();

			Console.WriteLine($"employee name: {emp2.EmployeeName}");
			Console.WriteLine($"salary: {emp2.CalculateSalary()}");
			Console.WriteLine($"department: {emp2.GetDepartmentDetails()}");
		}
	}

	// interface defining department-related behavior
	internal interface IDepartment
	{
		void AssignDepartment(string departmentName);

		string GetDepartmentDetails();
	}

	internal abstract class Employee : IDepartment
	{
		// fields → keep private
		// properties → public or protected
		// Children should access data via properties, not fields.
		// private fields
		private int employeeId;

		private string employeeName;
		private double baseSalary;

		// public property for employee id (read-only)
		public int EmployeeId
		{
			get { return employeeId; }
			private set { employeeId = value; }
		}

		// public property for employee name
		public string EmployeeName
		{
			get { return employeeName; }
			set
			{
				if (!string.IsNullOrWhiteSpace(value))
				{
					employeeName = value;
				}
			}
		}

		// public property for base salary with validation
		public double BaseSalary
		{
			get { return baseSalary; }
			set
			{
				if (value >= 0)
				{
					baseSalary = value;
				}
			}
		}

		public Employee(int employeeId, string employeeName, double baseSalary)
		{
			EmployeeId = employeeId;
			EmployeeName = employeeName;
			BaseSalary = baseSalary;
		}

		// abstract method to enforce salary calculation
		public abstract double CalculateSalary();

		// department field
		private string departmentName;

		// assigns department to employee
		public void AssignDepartment(string departmentName)
		{
			this.departmentName = departmentName;
		}

		// returns department details
		public string GetDepartmentDetails()
		{
			return departmentName;
		}
	}

	// inheritance in employee management system
	// employee acts as the base class containing common data such as
	// employee id, employee name, and base salary.
	// full-time employee and part-time employee will inherit from employee,
	// establishing an is-a relationship (full-time employee is an employee).

	// inheritance helps avoid duplication of common fields and properties
	// and allows child classes to extend employee behavior with their own logic.

	// access modifiers are important in inheritance:
	// private members are not accessible in derived classes,
	// while public and protected members can be accessed.

	// child classes will reuse employee properties and add their own
	// specific data such as fixed salary or hourly work details.

	// is-a relationship means:
	// One class is a specialized type of another class,represents inheritance.
	// An is-a relationship represents inheritance,
	// where a derived class is a specialized form of its base class

	// Class B is a Class A
	// then Class B should inherit from Class A.

	//Simple Real-World Examples
	//A Dog is an Animal
	//A Car is a Vehicle

	// derived class for full-time employee
	internal class FullTimeEmployee : Employee
	{
		// additional property for full-time employee
		public double FixedSalary { get; set; }

		public FullTimeEmployee(int employeeId, string employeeName, double baseSalary, double fixedSalary)
			: base(employeeId, employeeName, baseSalary)
		{
			FixedSalary = fixedSalary;
		}

		public override double CalculateSalary()
		{
			return FixedSalary;
		}
	}

	// The derived class reuses base class properties through
	// inheritance and extends it by adding its own specialized data.

	// derived class for part-time employee
	internal class PartTimeEmployee : Employee
	{
		// additional properties for part-time employee
		public double HourlyRate { get; set; }

		public int HoursWorked { get; set; }

		public PartTimeEmployee(int employeeId, string employeeName, double hourlyRate, int hoursWorked)
			: base(employeeId, employeeName, 0)
		{
			HourlyRate = hourlyRate;
			HoursWorked = hoursWorked;
		}

		public override double CalculateSalary()
		{
			return HourlyRate * HoursWorked;
		}
	}

	// Abstraction means:
	// defining what an object must do, without defining how it does it.

	// Should every employee calculate salary? → Yes
	// Should the logic be the same? → No
	// This is where abstraction comes in.

	// abstraction in employee management system
	// employee is defined as an abstract class to represent common employee behavior
	// without allowing direct object creation.
	// it enforces essential rules such as salary calculation while
	// allowing derived classes to provide their own implementation.

	// abstract methods define what must be done,
	// while concrete methods define shared behavior.
	// this ensures consistency and flexibility across different employee types.
}