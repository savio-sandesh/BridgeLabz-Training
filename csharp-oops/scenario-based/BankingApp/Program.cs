using System;
using System.Collections.Generic;

namespace BankingApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Bank & Branch setup
			Bank bank = new Bank("Demo Bank", "demo@bank.com", "9999999999");
			Branch branch = new Branch(
				"Mathura Main Branch",
				"Mathura, Uttar Pradesh",
				"BANK000123"
			);
			bank.AddBranch(branch);

			// Store multiple customers
			List<User> users = new List<User>();

			while (true)
			{
				Console.WriteLine("\n===== Login =====");
				Console.WriteLine("Enter role (customer / manager / exit): ");
				string role = Console.ReadLine().ToLower();

				if (role == "exit")
				{
					Console.WriteLine("Exiting Banking Application...");
					break;
				}
				else if (role == "manager")
				{
					if (AuthenticateManager())
					{
						ManagerMenu(branch, users);
					}
					else
					{
						Console.WriteLine("Invalid manager credentials.");
					}
				}
				else if (role == "customer")
				{
					User loggedInUser = AuthenticateCustomer(users);

					if (loggedInUser != null)
					{
						CustomerMenu(branch, loggedInUser);
					}
					else
					{
						Console.WriteLine("Invalid customer credentials.");
					}
				}
				else
				{
					Console.WriteLine("Invalid role selected.");
				}
			}
		}

		// ---------------- MANAGER AUTH ----------------
		static bool AuthenticateManager()
		{
			Console.Write("Enter Manager ID: ");
			string managerId = Console.ReadLine();

			Console.Write("Enter Password: ");
			string password = Console.ReadLine();

			return managerId == "admin" && password == "admin123";
		}

		// ---------------- CUSTOMER AUTH ----------------
		static User AuthenticateCustomer(List<User> users)
		{
			Console.Write("Enter CIF Number: ");
			string cif = Console.ReadLine();

			Console.Write("Enter Account Number: ");
			string accountNumber = Console.ReadLine();

			foreach (User user in users)
			{
				if (user.CIFNumber == cif && user.AccountNumber == accountNumber)
				{
					return user;
				}
			}
			return null;
		}

		// ---------------- MANAGER MENU ----------------
		static void ManagerMenu(Branch branch, List<User> users)
		{
			int choice;

			do
			{
				Console.WriteLine("\n--- Bank Manager Menu ---");
				Console.WriteLine("1. Create Customer");
				Console.WriteLine("2. Create Account");
				Console.WriteLine("3. Verify KYC");
				Console.WriteLine("4. Freeze Account");
				Console.WriteLine("5. Unfreeze Account");
				Console.WriteLine("6. Apply Interest");
				Console.WriteLine("7. Close Account");
				Console.WriteLine("8. Logout");
				Console.Write("Enter choice: ");

				choice = int.Parse(Console.ReadLine());

				switch (choice)
				{
					case 1:
						Console.Write("Enter Name: ");
						string name = Console.ReadLine();

						Console.Write("Enter CIF Number: ");
						string cif = Console.ReadLine();

						Console.Write("Enter Account Type: ");
						string type = Console.ReadLine();

						Console.Write("Enter Address: ");
						string address = Console.ReadLine();

						Console.Write("Enter Phone: ");
						string phone = Console.ReadLine();

						users.Add(new User(name, cif, type, address, phone));
						Console.WriteLine("Customer created successfully.");
						break;

					case 2:
						Console.Write("Enter CIF Number: ");
						string cifNo = Console.ReadLine();

						User user = users.Find(u => u.CIFNumber == cifNo);
						if (user == null)
						{
							Console.WriteLine("Customer not found.");
							break;
						}

						Console.Write("Enter Account Number: ");
						string accNo = Console.ReadLine();

						Console.WriteLine(
							BankAccountManager.CreateAccount(branch, user, accNo)
							? "Account created successfully."
							: "Account creation failed."
						);
						break;

					case 3:
						Console.Write("Enter CIF Number: ");
						string kycCif = Console.ReadLine();

						User kycUser = users.Find(u => u.CIFNumber == kycCif);
						Console.WriteLine(
							kycUser != null && BankAccountManager.VerifyKYC(kycUser)
							? "KYC verified."
							: "KYC verification failed."
						);
						break;

					case 4:
						Console.Write("Enter Account Number: ");
						Console.WriteLine(
							BankAccountManager.FreezeAccount(branch, Console.ReadLine())
							? "Account frozen."
							: "Operation failed."
						);
						break;

					case 5:
						Console.Write("Enter Account Number: ");
						Console.WriteLine(
							BankAccountManager.UnfreezeAccount(branch, Console.ReadLine())
							? "Account unfrozen."
							: "Operation failed."
						);
						break;

					case 6:
						Console.Write("Enter Account Number: ");
						string interestAcc = Console.ReadLine();

						Console.WriteLine(
							BankAccountManager.ApplyInterest(branch, interestAcc, 0.05)
							? "Interest applied."
							: "Failed to apply interest."
						);
						break;

					case 7:
						Console.Write("Enter CIF Number: ");
						string closeCif = Console.ReadLine();

						User closeUser = users.Find(u => u.CIFNumber == closeCif);
						if (closeUser == null)
						{
							Console.WriteLine("Customer not found.");
							break;
						}

						Console.WriteLine(
							BankAccountManager.CloseAccount(branch, closeUser, closeUser.AccountNumber)
							? "Account closed."
							: "Close account failed."
						);
						break;

					case 8:
						Console.WriteLine("Manager logged out.");
						break;

					default:
						Console.WriteLine("Invalid option.");
						break;
				}

			} while (choice != 8);
		}

		// ---------------- CUSTOMER MENU ----------------
		static void CustomerMenu(Branch branch, User user)
		{
			int choice;

			do
			{
				Console.WriteLine("\n--- Customer Menu ---");
				Console.WriteLine("1. Deposit Money");
				Console.WriteLine("2. Withdraw Money");
				Console.WriteLine("3. Check Balance");
				Console.WriteLine("4. Logout");
				Console.Write("Enter choice: ");

				choice = int.Parse(Console.ReadLine());

				switch (choice)
				{
					case 1:
						Console.Write("Enter amount: ");
						Console.WriteLine(
							BankAccountManager.ApproveDeposit(
								branch, user, user.AccountNumber, double.Parse(Console.ReadLine()))
							? "Deposit successful."
							: "Deposit failed."
						);
						break;

					case 2:
						Console.Write("Enter amount: ");
						Console.WriteLine(
							BankAccountManager.ApproveWithdrawal(
								branch, user, user.AccountNumber, double.Parse(Console.ReadLine()))
							? "Withdrawal successful."
							: "Withdrawal failed."
						);
						break;

					case 3:
						BankAccount acc = branch.GetAccount(user.AccountNumber);
						Console.WriteLine(
							acc != null
							? "Current Balance: " + acc.Balance
							: "Account not found."
						);
						break;

					case 4:
						Console.WriteLine("Customer logged out.");
						break;

					default:
						Console.WriteLine("Invalid option.");
						break;
				}

			} while (choice != 4);
		}
	}
}
