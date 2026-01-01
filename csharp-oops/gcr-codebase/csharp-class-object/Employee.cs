namespace BridgeLabzTraining.csharp_class_object
{
	internal class Employee
	{

		// fields to store employee details
		string employeeName;
		int employeeID;
		double employeeSalary;

		// Constructor to initialize employee object at creation time
		public Employee(string name, int id, double salary)
		{
			employeeName = name;
			employeeID = id;
			employeeSalary = salary;
		}

		// Method to display employee details
		void DisplayDetails()
		{
			Console.WriteLine("Employee name is " + employeeName);
			Console.WriteLine("Employee ID is " + employeeID);
			Console.WriteLine("Employee salary is " + employeeSalary);
		}

		// Entry point of the program
		static void Main(string[] args)
		{
			// read employee name from the user
			Console.WriteLine("Enter the employee name:");
			string nameOfEmployee = Console.ReadLine()!;

			// read employee ID from the user
			Console.WriteLine("Enter the employee ID:");
			int idOfEmployee = int.Parse(Console.ReadLine()!);

			// read employee salary from the user
			Console.WriteLine("Enter the employee salary:");
			double salaryOfEmployee = double.Parse(Console.ReadLine()!);

			// creating employee object using user provided data 
			Employee employee = new Employee(nameOfEmployee, idOfEmployee, salaryOfEmployee);
			employee.DisplayDetails();
		}
	}
}