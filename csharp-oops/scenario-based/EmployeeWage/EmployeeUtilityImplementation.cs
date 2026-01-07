namespace EmployeeWage
{
	internal class EmployeeUtilityImplementation : IEmployee
	{
		private static readonly Random random = new Random();

		private int wagePerHour = 20;
		private int fullTimeHours = 8;
		private int partTimeHours = 4;

		// UC-1: Check employee attendance
		public bool CheckAttendance()
		{
			int attendance = random.Next(0, 2);

			if (attendance == 1)
			{
				Console.WriteLine("Attendance Status: Present");
				return true;
			}
			else
			{
				Console.WriteLine("Attendance Status: Absent");
				return false;
			}
		}

		// UC-2: Calculate daily employee wage
		public int CalculateDailyWage()
		{
			int dailyWage = 0;

			// Calculate wage only if employee is present
			if (CheckAttendance())
			{
				dailyWage = wagePerHour * fullTimeHours;
			}

			return dailyWage;
		}

		// UC-3: Calculate wage based on employee type
		public int CalculateEmployeeWageByType()
		{
			// 0 = Absent, 1 = Full-time, 2 = Part-time
			int employeeType = random.Next(0, 3);
			int workingHours = 0;

			if (employeeType == 1)
			{
				workingHours = fullTimeHours;
				Console.WriteLine("Employee Type: Full-Time");
			}
			else if (employeeType == 2)
			{
				workingHours = partTimeHours;
				Console.WriteLine("Employee Type: Part-Time");
			}
			else
			{
				Console.WriteLine("Employee Type: Absent");
			}

			int employeeWage = workingHours * wagePerHour;
			return employeeWage;
		}
	}
}