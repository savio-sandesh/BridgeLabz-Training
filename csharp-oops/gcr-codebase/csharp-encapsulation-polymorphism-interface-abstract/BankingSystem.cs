namespace BridgeLabzTraining.csharp_encapsulation_polymorphism_interface_abstract
{
	// Banking System using OOP concepts in C#
	// Demonstrates encapsulation, inheritance, polymorphism, and abstraction
	// Supports different account types with interest and loan facilities

	internal class BankingSystem
	{
		public static void Main()
		{
			// Polymorphism: parent class reference holding different child objects
			List<BankAccount> accounts = new List<BankAccount>();

			accounts.Add(new SavingsAccount("SA101", "Sandesh", 10000));
			accounts.Add(new CurrentAccount("CA202", "Sahil", 20000));

			foreach (BankAccount account in accounts)
			{
				Console.WriteLine("Account Holder: " + account.HolderName);
				Console.WriteLine("Interest Earned: " + account.CalculateInterest());

				// Interface-based polymorphism using safe type checking
				if (account is ILoanable loanable)
				{
					loanable.ApplyForLoan();
					Console.WriteLine("Loan Eligibility: " + loanable.CalculateLoanEligibility());
				}

				Console.WriteLine("--------------------------");
			}
		}
	}

	// Abstract base class defining common bank account structure (Abstraction)
	internal abstract class BankAccount
	{
		// Encapsulation: private setters protect account details
		public string AccountNumber { get; private set; }

		public string HolderName { get; private set; }

		// Protected balance allows controlled access to child classes
		protected double balance;

		// Constructor to initialize account details
		public BankAccount(string accountNumber, string holderName, double initialBalance)
		{
			AccountNumber = accountNumber;
			HolderName = holderName;
			balance = initialBalance;
		}

		// Method to deposit money safely
		public void Deposit(double amount)
		{
			if (amount > 0)
				balance += amount;
		}

		// Method to withdraw money with validation
		public void Withdraw(double amount)
		{
			if (amount > 0 && amount <= balance)
				balance -= amount;
		}

		// Abstract method forcing subclasses to implement interest logic
		public abstract double CalculateInterest();
	}

	// Interface defining loan-related behavior (Abstraction)
	internal interface ILoanable
	{
		void ApplyForLoan();

		double CalculateLoanEligibility();
	}

	// SavingsAccount inherits BankAccount and implements loan functionality
	internal class SavingsAccount : BankAccount, ILoanable
	{
		private const double InterestRate = 0.04;

		public SavingsAccount(string accountNumber, string holderName, double balance)
			: base(accountNumber, holderName, balance)
		{
		}

		// Overridden method for savings account interest calculation
		public override double CalculateInterest()
		{
			return balance * InterestRate;
		}

		public void ApplyForLoan()
		{
			Console.WriteLine("Loan applied under Savings Account.");
		}

		public double CalculateLoanEligibility()
		{
			return balance * 2;
		}
	}

	// CurrentAccount inherits BankAccount and implements loan functionality
	internal class CurrentAccount : BankAccount, ILoanable
	{
		private const double InterestRate = 0.02;

		public CurrentAccount(string accountNumber, string holderName, double balance)
			: base(accountNumber, holderName, balance)
		{
		}

		// Overridden method for current account interest calculation
		public override double CalculateInterest()
		{
			return balance * InterestRate;
		}

		public void ApplyForLoan()
		{
			Console.WriteLine("Loan applied under Current Account.");
		}

		public double CalculateLoanEligibility()
		{
			return balance * 3;
		}
	}
}