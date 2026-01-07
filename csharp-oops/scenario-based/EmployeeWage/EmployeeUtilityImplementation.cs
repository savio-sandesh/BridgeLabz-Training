namespace EmployeeWage
{
	internal class EmployeeUtilityImplementation : IEmployee
	{
		private static readonly Random _random = new Random();

		// UC1 - Check Employee is Present or Absent
		public void CheckAttendance()
		{
			int attendance = _random.Next(0, 2);

			if (attendance == 1)
				Console.WriteLine("Employee is Present");
			else
				Console.WriteLine("Employee is Absent");
		}
	}
}