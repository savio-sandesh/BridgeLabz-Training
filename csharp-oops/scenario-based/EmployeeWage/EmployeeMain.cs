namespace EmployeeWage
{
	internal class EmployeeMain
	{
		public void Start()
		{
			Console.Write("Enter number of employees: ");
			int count = Convert.ToInt32(Console.ReadLine());

			// List to store employee objects
			List<Employee> employees = new List<Employee>();

			for (int i = 0; i < count; i++)
			{
				Console.WriteLine($"\nEnter details for Employee {i + 1}:");

				Console.Write("Employee ID: ");
				int id = Convert.ToInt32(Console.ReadLine());

				Console.Write("Employee Name: ");
				string name = Console.ReadLine();

				Console.Write("Employee Role: ");
				string role = Console.ReadLine();

				Console.Write("Employee Department: ");
				string department = Console.ReadLine();

				employees.Add(new Employee
				{
					EmployeeId = id,
					Name = name,
					Role = role,
					Department = department
				});
			}

			bool changeEmployee;

			do
			{
				// Show employee list EVERY time
				Console.WriteLine("\nStored Employee Details:");
				for (int i = 0; i < employees.Count; i++)
				{
					Console.WriteLine($"{i + 1}. {employees[i].Name} (ID: {employees[i].EmployeeId})");
				}

				Console.Write("\nSelect Employee (Enter number): ");
				int selectedIndex = Convert.ToInt32(Console.ReadLine()) - 1;

				Employee selectedEmployee = employees[selectedIndex];
				Console.WriteLine($"\nSelected Employee: {selectedEmployee.Name}");

				// Start menu
				EmployeeMenu menu = new EmployeeMenu();
				menu.ShowChoices();

				// Decide whether to loop again
				changeEmployee = menu.RequestEmployeeChange;
			} while (changeEmployee);
		}
	}
}