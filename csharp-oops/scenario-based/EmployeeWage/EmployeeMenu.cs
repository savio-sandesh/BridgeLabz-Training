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
				Console.WriteLine("4. UC5 - Calculate Monthly Wage (20 Days)");
				Console.WriteLine("5. UC6 - Wage with Max Hour & Day Limit");
				Console.WriteLine("0. Exit");
				Console.Write("Enter Choice: ");

				choice = Convert.ToInt32(Console.ReadLine());

				switch (choice)
				{
					case 1:
						// UC-1
						employeeService.CheckAttendance();
						break;

					case 2:
						// UC-2
						int dailyWage = employeeService.CalculateDailyWage();
						Console.WriteLine("Daily Wage: " + dailyWage);
						break;

					case 3:
						// UC-3
						int partTimeWage = employeeService.CalculateEmployeeWageByType();
						Console.WriteLine("Employee Wage: " + partTimeWage);
						break;

					case 4:
						// UC-5
						int monthlyWage = employeeService.CalculateMonthlyWage();
						Console.WriteLine("Monthly Wage (20 Days): " + monthlyWage);
						break;

					case 5:
						// UC-6
						int limitedWage = employeeService.CalculateWageWithHourAndDayLimit();
						Console.WriteLine("Wage with Hour & Day Limit: " + limitedWage);
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