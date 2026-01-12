namespace LoanBuddy
{
	internal abstract class Loan : IApprovable
	{
		// Protected members (accessible to child classes)
		protected Applicant applicant;

		protected int term;
		protected double interestRate;

		// Private loan status (Encapsulation)
		private bool approved;

		// Constructor
		protected Loan(Applicant applicant, int term, double interestRate)
		{
			this.applicant = applicant;
			this.term = term;
			this.interestRate = interestRate;
		}

		// Only internal logic can change loan status
		protected void SetApprovalStatus(bool status)
		{
			approved = status;
		}

		// Public read-only access to loan status
		public bool IsApproved()
		{
			return approved;
		}

		// Common eligibility check
		protected bool BasicEligibilityCheck(int minCreditScore)
		{
			return applicant.GetCreditScore() >= minCreditScore &&
				   applicant.Income * 12 >= applicant.LoanAmount;
		}

		// Interface methods (must be implemented by child classes)
		public abstract bool ApproveLoan();

		public abstract double CalculateEMI();
	}
}