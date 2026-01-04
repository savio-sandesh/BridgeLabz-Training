namespace BridgeLabzTraining.csharp_inheritance
{
	// bank account class
	// acts as the superclass
	internal class BankAccount
	{
		public string AccountNumber;
		public double Balance;
	}

	// savings account class
	// inherits from bank account
	internal class SavingsAccount : BankAccount
	{
		public double InterestRate;

		public void DisplayAccountType()
		{
			Console.WriteLine("Account Type   : Savings Account");
			Console.WriteLine("Account Number : " + AccountNumber);
			Console.WriteLine("Balance        : INR " + Balance);
			Console.WriteLine("Interest Rate  : " + InterestRate + "%");
		}
	}

	// checking account class
	// inherits from bank account
	internal class CheckingAccount : BankAccount
	{
		public int WithdrawalLimit;

		public void DisplayAccountType()
		{
			Console.WriteLine("Account Type     : Checking Account");
			Console.WriteLine("Account Number  : " + AccountNumber);
			Console.WriteLine("Balance         : INR " + Balance);
			Console.WriteLine("Withdrawal Limit: " + WithdrawalLimit);
		}
	}

	// fixed deposit account class
	// inherits from bank account
	internal class FixedDepositAccount : BankAccount
	{
		public int LockPeriod;

		public void DisplayAccountType()
		{
			Console.WriteLine("Account Type   : Fixed Deposit Account");
			Console.WriteLine("Account Number: " + AccountNumber);
			Console.WriteLine("Balance       : INR " + Balance);
			Console.WriteLine("Lock Period   : " + LockPeriod + " months");
		}
	}

	internal class BankAccountTypes
	{
		private static void Main()
		{
			// savings account object
			SavingsAccount savings = new SavingsAccount();
			savings.AccountNumber = "SA101";
			savings.Balance = 50000;
			savings.InterestRate = 4.5;

			savings.DisplayAccountType();
			Console.WriteLine();

			// checking account object
			CheckingAccount checking = new CheckingAccount();
			checking.AccountNumber = "CA202";
			checking.Balance = 30000;
			checking.WithdrawalLimit = 5;

			checking.DisplayAccountType();
			Console.WriteLine();

			// fixed deposit account object
			FixedDepositAccount fd = new FixedDepositAccount();
			fd.AccountNumber = "FD303";
			fd.Balance = 100000;
			fd.LockPeriod = 12;

			fd.DisplayAccountType();

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}