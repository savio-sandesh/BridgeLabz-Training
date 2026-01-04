namespace BridgeLabzTraining.csharp_accessmodifiers
{
	// bank account class
	// demonstrates access modifiers using properties
	internal class BankAccount
	{
		// public property
		public long AccountNumber { get; set; }

		// protected property
		protected string AccountHolder { get; set; }

		// private set property
		public double Balance { get; private set; }

		// stores all accounts
		private static List<BankAccount> accountList = new List<BankAccount>();

		// parameterized constructor
		public BankAccount(long accountNumber, string accountHolder, double balance)
		{
			AccountNumber = accountNumber;
			AccountHolder = accountHolder;
			Balance = balance;
			accountList.Add(this);
		}

		// public method to update balance
		public void UpdateBalance(double newBalance)
		{
			Balance = newBalance;
		}

		// displays account details
		public virtual void DisplayAccountDetails()
		{
			Console.WriteLine("Account Number : " + AccountNumber);
			Console.WriteLine("Account Holder : " + AccountHolder);
			Console.WriteLine("Balance        : INR " + Balance);
		}

		// displays all accounts
		public static void DisplayAllAccounts()
		{
			foreach (BankAccount acc in accountList)
			{
				acc.DisplayAccountDetails();
				Console.WriteLine();
			}
		}
	}

	// subclass to demonstrate protected access
	internal class SavingsAccount : BankAccount
	{
		public SavingsAccount(long accountNumber, string accountHolder, double balance)
			: base(accountNumber, accountHolder, balance)
		{
		}

		// accessing public and protected members
		public override void DisplayAccountDetails()
		{
			Console.WriteLine("Account Number : " + AccountNumber);   // public
			Console.WriteLine("Account Holder : " + AccountHolder);   // protected
			Console.WriteLine("Balance        : INR " + Balance);     // public get
		}
	}

	internal class BankAccountManagement
	{
		private static void Main()
		{
			string choice;

			do
			{
				Console.Write("Enter Account Number : ");
				long accNo = Convert.ToInt64(Console.ReadLine());

				Console.Write("Enter Account Holder Name : ");
				string holder = Console.ReadLine();

				Console.Write("Enter Balance : ");
				double balance = Convert.ToDouble(Console.ReadLine());

				new SavingsAccount(accNo, holder, balance);

				Console.Write("Would you like to add more accounts? (yes/no) : ");
				choice = Console.ReadLine().ToLower();

				Console.WriteLine();
			} while (choice == "yes");

			// list all accounts
			BankAccount.DisplayAllAccounts();

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}