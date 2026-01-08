namespace EmployeeWage
{
	internal class EmployeeUtilityImplementation : IEmployee
	{
		private static readonly Random random = new Random();

		private int wagePerHour = 20;

		// 🔹 Store attendance state
		private bool isPresent = false;

		// UC-1: Check attendance ONCE and store result
		public bool CheckAttendance()
		{
			isPresent = random.Next(0, 2) == 1;

			if (isPresent)
			{
				Console.WriteLine("Attendance Status: Present");
			}
			else
			{
				Console.WriteLine("Attendance Status: Absent");
			}

			return isPresent;
		}

		// UC-2: Calculate daily wage (uses stored attendance)
		public int CalculateDailyWage()
		{
			if (!isPresent)
			{
				Console.WriteLine("Employee is absent. Daily Wage = 0");
				return 0;
			}

			Console.Write("Enter working hours for the day: ");
			int workingHours = Convert.ToInt32(Console.ReadLine());

			int dailyWage = workingHours * wagePerHour;

			Console.WriteLine($"Daily Wage: {dailyWage}");
			return dailyWage;
		}

		// UC-3: Decide full-time / part-time based on working hours
		public int CalculateEmployeeWageByType()
		{
			if (!isPresent)
			{
				Console.WriteLine("Employee is absent. Wage = 0");
				return 0;
			}

			Console.Write("Enter working hours for the day: ");
			int workingHours = Convert.ToInt32(Console.ReadLine());

			string employeeType = workingHours >= 8 ? "Full-Time" : "Part-Time";
			int wage = workingHours * wagePerHour;

			Console.WriteLine($"Employee Type: {employeeType}");
			Console.WriteLine($"Wage: {wage}");

			return wage;
		}

		// UC-5: Calculate monthly wage
		public int CalculateMonthlyWage()
		{
			if (!isPresent)
			{
				Console.WriteLine("Employee is absent. Monthly Wage = 0");
				return 0;
			}

			Console.Write("Enter number of working days: ");
			int workingDays = Convert.ToInt32(Console.ReadLine());

			Console.Write("Enter working hours per day: ");
			int workingHours = Convert.ToInt32(Console.ReadLine());

			string employeeType = workingHours >= 8 ? "Full-Time" : "Part-Time";
			int totalWage = workingDays * workingHours * wagePerHour;

			Console.WriteLine($"Employee Type: {employeeType}");
			Console.WriteLine($"Monthly Wage: {totalWage}");

			return totalWage;
		}

		// UC-6: Wage with maximum working hours and days limit
		public int CalculateWageWithHourAndDayLimit()
		{
			if (!isPresent)
			{
				Console.WriteLine("Employee is absent. Wage = 0");
				return 0;
			}

			int maxWorkingDays = 20;
			int maxWorkingHours = 100;

			int totalDays = 0;
			int totalHours = 0;
			int totalWage = 0;

			while (totalDays < maxWorkingDays && totalHours < maxWorkingHours)
			{
				Console.Write($"Enter working hours for day {totalDays + 1}: ");
				int hours = Convert.ToInt32(Console.ReadLine());

				if (totalHours + hours > maxWorkingHours)
				{
					Console.WriteLine("Maximum working hours limit reached.");
					break;
				}

				totalDays++;
				totalHours += hours;
				totalWage += hours * wagePerHour;
			}

			Console.WriteLine($"Total Working Days: {totalDays}");
			Console.WriteLine($"Total Working Hours: {totalHours}");
			Console.WriteLine($"Total Wage with limits: {totalWage}");

			return totalWage;
		}
	}
}