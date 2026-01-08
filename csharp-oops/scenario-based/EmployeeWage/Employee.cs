namespace EmployeeWage
{
	internal class Employee
	{
		public int EmployeeId { get; set; }
		public string Name { get; set; }
		public string Role { get; set; }
		public string Department { get; set; }

		public override string ToString()
		{
			return $"ID: {EmployeeId}, Name: {Name}, Role: {Role}, Department: {Department}";
		}
	}
}