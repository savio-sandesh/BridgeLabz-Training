namespace EmployeeWage
{
	internal class EmployeeUtilityImplementation : IEmployee
	{
		private static readonly Random random = new Random();

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
			int wagePerHour = 20;
			int fullDayHours = 8;
			int dailyWage = 0;

			// Calculate wage only if employee is present
			if (CheckAttendance())
			{
				dailyWage = wagePerHour * fullDayHours;
			}

			return dailyWage;
		}
	}
}