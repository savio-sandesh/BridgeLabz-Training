namespace LoanBuddy
{
	internal class HomeLoan : Loan
	{
		// Constructor for Home Loan
		public HomeLoan(Applicant applicant, int term)
			: base(applicant, term, 0.07 / 12) // 7% annual interest
		{
		}

		// Approval logic specific to Home Loan
		public override bool ApproveLoan()
		{
			bool eligible = BasicEligibilityCheck(650);
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