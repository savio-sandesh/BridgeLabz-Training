namespace EmployeeWage
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("Welcome to Employee Wage Computation Program");

			EmployeeMain employeeMain = new EmployeeMain();
			employeeMain.Start();
		}
	}
}