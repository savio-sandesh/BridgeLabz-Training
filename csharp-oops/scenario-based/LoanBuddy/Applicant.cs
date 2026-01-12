namespace LoanBuddy
{
	internal class Applicant
	{
		// Private field (Encapsulation)
		private int creditScore;

		// Public properties
		public string Name { get; private set; }

		public double Income { get; private set; }
		public double LoanAmount { get; private set; }

		// Constructor
		public Applicant(string name, int creditScore, double income, double loanAmount)
		{
			Name = name;
			this.creditScore = creditScore;
			Income = income;
			LoanAmount = loanAmount;
		}

		// Public method to safely access credit score
		public int GetCreditScore()
		{
			return creditScore;
		}
	}
}