//namespace BridgeLabzTraining.csharp_keywords
//{
//	// bank account class
//	// demonstrates static, this, readonly and is operator
//	internal class BankAccount
//	{
//		// static member shared by all accounts
//		public static string BankName = "Apna Bank";

//		// static counter for total accounts
//		private static int totalAccounts = 0;

//		// readonly member
//		public readonly long AccountNumber;

//		// instance member
//		public string AccountHolderName;

//		// stores all accounts
//		private static List<BankAccount> accountList = new List<BankAccount>();

//		// parameterized constructor
//		public BankAccount(long accountNumber, string accountHolderName)
//		{
//			this.AccountNumber = accountNumber;
//			this.AccountHolderName = accountHolderName;
//			totalAccounts++;
//			accountList.Add(this);
//		}

//		// displays account details
//		public void DisplayAccountDetails()
//		{
//			Console.WriteLine("Bank Name           : " + BankName);
//			Console.WriteLine("Account Number      : " + AccountNumber);
//			Console.WriteLine("Account Holder Name : " + AccountHolderName);
//		}

//		// static method to display total accounts
//		public static void GetTotalAccounts()
//		{
//			Console.WriteLine("Total Accounts : " + totalAccounts);
//		}

//		// displays all accounts using is operator
//		public static void DisplayAllAccounts()
//		{
//			foreach (object obj in accountList)
//			{
//				if (obj is BankAccount acc)
//				{
//					acc.DisplayAccountDetails();
//					Console.WriteLine();
//				}
//			}
//		}
//	}

//	internal class BankAccountSystem
//	{
//		private static void Main()
//		{
//			string choice;

//			do
//			{
//				Console.Write("Enter Account Number : ");
//				long accNo = Convert.ToInt64(Console.ReadLine());

//				Console.Write("Enter Account Holder Name : ");
//				string name = Console.ReadLine();

//				new BankAccount(accNo, name);

//				Console.Write("Would you like to add more accounts? (yes/no) : ");
//				choice = Console.ReadLine().ToLower();

//				Console.WriteLine();
//			} while (choice == "yes");

//			// display all accounts
//			BankAccount.DisplayAllAccounts();

//			// display total accounts
//			BankAccount.GetTotalAccounts();

//			Console.WriteLine("Press Enter to exit...");
//			Console.ReadLine();
//		}
//	}
//}