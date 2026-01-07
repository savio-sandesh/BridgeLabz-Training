namespace EmployeeWage
{
	internal class EmployeeMain
	{
		private readonly IEmployee employeeUtility;

		public EmployeeMain()
		{
			// Create object using interface reference
			employeeUtility = new EmployeeUtilityImplementation();
		}

		public void Start()
		{
			// UC-2: Get daily wage
			int dailyWage = employeeUtility.CalculateDailyWage();

			// Display daily wage
			Console.WriteLine("Daily Employee Wage: " + dailyWage);
		}
	}
}