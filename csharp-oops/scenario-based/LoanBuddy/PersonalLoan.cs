namespace LoanBuddy
{
	internal class PersonalLoan : Loan
	{
		// Constructor for Personal Loan
		public PersonalLoan(Applicant applicant, int term)
			: base(applicant, term, 0.12 / 12) // 12% annual interest
		{
		}

		// Approval logic specific to Personal Loan
		public override bool ApproveLoan()
		{
			// Personal loans usually require higher credit score
			bool eligible = BasicEligibilityCheck(700);
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