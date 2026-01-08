namespace EmployeeWage
{
	internal class EmployeeMenu
	{
		private IEmployee employeeService;
		public bool RequestEmployeeChange { get; private set; }

		public void ShowChoices()
		{
			employeeService = new EmployeeUtilityImplementation();
			RequestEmployeeChange = false;

			bool isPresent = false;
			bool attendanceChecked = false;

			while (true)
			{
				Console.WriteLine("\n--- Employee Wage Computation ---");

				// Show UC1 only once
				if (!attendanceChecked)
				{
					Console.WriteLine("1. UC1 - Check Attendance");
				}
				else if (!isPresent)
				{
					Console.WriteLine("(Employee is absent - wage options disabled)");
				}
				else
				{
					Console.WriteLine("2. UC2 - Calculate Daily Wage");
					Console.WriteLine("3. UC3 - Part Time Employee Wage");
					Console.WriteLine("4. UC5 - Calculate Monthly Wage (20 Days)");
					Console.WriteLine("5. UC6 - Wage with Max Hour & Day Limit");
				}

				Console.WriteLine("9. Change Employee");
				Console.WriteLine("0. Exit");
				Console.Write("Enter Choice: ");

				int choice = Convert.ToInt32(Console.ReadLine());

				switch (choice)
				{
					case 1:
						if (!attendanceChecked)
						{
							isPresent = employeeService.CheckAttendance();
							attendanceChecked = true;
						}
						else
						{
							Console.WriteLine("Attendance already checked.");
						}
						break;

					case 2:
						if (attendanceChecked && isPresent)
							employeeService.CalculateDailyWage();
						else
							Console.WriteLine("Wage option not available.");
						break;

					case 3:
						if (attendanceChecked && isPresent)
							employeeService.CalculateEmployeeWageByType();
						else
							Console.WriteLine("Wage option not available.");
						break;

					case 4:
						if (attendanceChecked && isPresent)
							employeeService.CalculateMonthlyWage();
						else
							Console.WriteLine("Wage option not available.");
						break;

					case 5:
						if (attendanceChecked && isPresent)
							employeeService.CalculateWageWithHourAndDayLimit();
						else
							Console.WriteLine("Wage option not available.");
						break;

					case 9:
						RequestEmployeeChange = true;
						return;

					case 0:
						Environment.Exit(0);
						return;

					default:
						Console.WriteLine("Invalid choice.");
						break;
				}
			}
		}
	}
}