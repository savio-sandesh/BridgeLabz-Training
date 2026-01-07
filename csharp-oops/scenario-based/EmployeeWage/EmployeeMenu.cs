namespace EmployeeWage
{
	internal class EmployeeMenu
	{
		private readonly IEmployee employeeService;

		public EmployeeMenu()
		{
			employeeService = new EmployeeUtilityImplementation();
		}

		public void ShowChoices()
		{
			int choice;

			do
			{
				Console.WriteLine("\n--- Employee Wage Computation ---");
				Console.WriteLine("1. UC1 - Check Attendance");
				Console.WriteLine("2. UC2 - Calculate Daily Wage");
				Console.WriteLine("3. UC3 - Part Time Employee Wage");
				Console.WriteLine("0. Exit");
				Console.Write("Enter Choice: ");

				choice = Convert.ToInt32(Console.ReadLine());

				switch (choice)
				{
					case 1:
						employeeService.CheckAttendance();
						break;

					case 2:
						int dailyWage = employeeService.CalculateDailyWage();
						Console.WriteLine("Daily Wage: " + dailyWage);
						break;

					case 3:
						int partTimeWage = employeeService.CalculateEmployeeWageByType();
						Console.WriteLine("Employee Wage: " + partTimeWage);
						break;

					case 0:
						Console.WriteLine("Exiting program...");
						break;

					default:
						Console.WriteLine("Invalid choice. Please try again.");
						break;
				}
			} while (choice != 0);
		}
	}
}