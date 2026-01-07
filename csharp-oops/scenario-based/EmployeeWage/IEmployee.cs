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
	}
}