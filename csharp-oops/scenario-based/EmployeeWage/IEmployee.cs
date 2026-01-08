namespace EmployeeWage
{
	internal interface IEmployee
	{
		// UC-1: Check if employee is present or absent
		bool CheckAttendance();

		// UC-2: Calculate daily wage of employee
		int CalculateDailyWage();

		// UC-3: Calculate wage based on employee type (full-time / part-time)
		int CalculateEmployeeWageByType();

		// UC-5: Calculate monthly wage for 20 working days
		int CalculateMonthlyWage();

		// UC-6: Calculate wage with maximum working hours and days limit
		int CalculateWageWithHourAndDayLimit();
	}
}

// define the contract for all employee-related operations
// such as attendance check, daily wage, monthly wage, etc.