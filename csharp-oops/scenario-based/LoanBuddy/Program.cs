//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

namespace LoanBuddy
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("===== Welcome to LoanBuddy =====\n");

			// Applicant details
			Console.Write("Enter Applicant Name: ");
			string name = Console.ReadLine();

			Console.Write("Enter Credit Score: ");
			int creditScore = int.Parse(Console.ReadLine());

			Console.Write("Enter Monthly Income: ");
			double income = double.Parse(Console.ReadLine());

			Console.Write("Enter Loan Amount: ");
			double loanAmount = double.Parse(Console.ReadLine());

			Applicant applicant = new Applicant(name, creditScore, income, loanAmount);

			// Loan type menu
			Console.WriteLine("\nSelect Loan Type:");
			Console.WriteLine("1. Home Loan");
			Console.WriteLine("2. Auto Loan");
			Console.WriteLine("3. Personal Loan");
			Console.Write("Enter choice: ");
			int choice = int.Parse(Console.ReadLine());

			Console.Write("Enter Loan Term (in months): ");
			int term = int.Parse(Console.ReadLine());

			Loan loan = null;

			switch (choice)
			{
				case 1:
					loan = new HomeLoan(applicant, term);
					break;

				case 2:
					loan = new AutoLoan(applicant, term);
					break;

				case 3:
					loan = new PersonalLoan(applicant, term);
					break;

				default:
					Console.WriteLine("Invalid loan type selected.");
					return;
			}

			// Loan approval & EMI calculation
			if (loan.ApproveLoan())
			{
				Console.WriteLine("\nLoan Approved!");
				Console.WriteLine($"Monthly EMI: {loan.CalculateEMI():F2}");
			}
			else
			{
				Console.WriteLine("\n Loan Rejected due to eligibility criteria.");
			}

			Console.WriteLine("\nThank you for using LoanBuddy!");
		}
	}
}