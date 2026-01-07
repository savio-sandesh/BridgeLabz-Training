namespace EmployeeWage
{
	internal class Employee
	{
		public int EmployeeId { get; set; }

		public string Name { get; set; }

		public override string ToString()
		{
			return "Employee Id: " + this.EmployeeId +
				   " Employee Name: " + this.Name;
		}
	}
}