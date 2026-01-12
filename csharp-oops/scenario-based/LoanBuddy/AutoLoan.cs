namespace LoanBuddy
{
	internal class AutoLoan : Loan
	{
		// Constructor for Auto Loan
		public AutoLoan(Applicant applicant, int term)
			: base(applicant, term, 0.09 / 12) // 9% annual interest
		{
		}

		// Approval logic specific to Auto Loan
		public override bool ApproveLoan()
		{
			bool eligible = BasicEligibilityCheck(600);
			SetApprovalStatus(eligible);
			return eligible;
		}

		// EMI calculation (Polymorphism)
		public override double CalculateEMI()
		{
			double P = applicant.LoanAmount;
			double R = interestRate;
			int N = term;

			return (P * R * Math.Pow(1 + R, N)) /
				   (Math.Pow(1 + R, N) - 1);
		}
	}
}