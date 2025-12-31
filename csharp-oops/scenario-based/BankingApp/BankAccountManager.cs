using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
	internal static class BankAccountManager
	{
		// -----------------------------
		// Account Lifecycle
		// -----------------------------

		internal static bool CreateAccount(Branch branch, User user, string accountNumber)
		{
			if (branch == null || user == null || string.IsNullOrWhiteSpace(accountNumber))
				return false;

			// Ask branch to create the account
			BankAccount account = branch.CreateAccount(accountNumber);

			// If account already exists or creation failed
			if (account == null)
				return false;

			// Link account to user
			user.AccountNumber = accountNumber;

			return true;
		}

		internal static bool CloseAccount(Branch branch, User user, string accountNumber)
		{
			if (branch == null || user == null || string.IsNullOrWhiteSpace(accountNumber))
				return false;

			// Ensure the user is closing their own account
			if (user.AccountNumber != accountNumber)
				return false;

			// Ask branch to close the account
			bool isClosed = branch.CloseAccount(accountNumber);

			if (!isClosed)
				return false;

			// Unlink account from user after successful closure
			user.AccountNumber = null;

			return true;
		}

		// -----------------------------
		// Account Control
		// -----------------------------

		internal static bool FreezeAccount(Branch branch, string accountNumber)
		{
			if (branch == null || string.IsNullOrWhiteSpace(accountNumber))
				return false;

			BankAccount account = branch.GetAccount(accountNumber);
			if (account == null)
				return false;

			account.IsFrozen = true;
			return true;
		}

		internal static bool UnfreezeAccount(Branch branch, string accountNumber)
		{
			if (branch == null || string.IsNullOrWhiteSpace(accountNumber))
				return false;

			BankAccount account = branch.GetAccount(accountNumber);
			if (account == null)
				return false;

			// Do not unfreeze a blocked account
			if (account.IsBlocked)
				return false;

			account.IsFrozen = false;
			return true;
		}

		internal static bool BlockAccount(Branch branch, string accountNumber)
		{
			if (branch == null || string.IsNullOrWhiteSpace(accountNumber))
				return false;

			BankAccount account = branch.GetAccount(accountNumber);
			if (account == null)
				return false;

			account.IsBlocked = true;
			account.IsFrozen = true; // Blocked accounts are always frozen

			return true;
		}

		// -----------------------------
		// Compliance
		// -----------------------------

		internal static bool VerifyKYC(User user)
		{
			if (user == null)
				return false;

			// KYC is a one-way operation
			user.IsKYCVerified = true;

			return true;
		}

		internal static bool UpdateUserDetails(User user, string address, string phone)
		{
			if (user == null)
				return false;

			if (!string.IsNullOrWhiteSpace(address))
				user.UserAddress = address;

			if (!string.IsNullOrWhiteSpace(phone))
				user.PhoneNumber = phone;

			return true;
		}

		// -----------------------------
		// Financial Operations
		// -----------------------------

		internal static bool ApproveDeposit(
			Branch branch,
			User user,
			string accountNumber,
			double amount)
		{
			if (branch == null || user == null || string.IsNullOrWhiteSpace(accountNumber))
				return false;

			// Ensure user owns the account
			if (user.AccountNumber != accountNumber)
				return false;

			// Optional compliance gate
			if (!user.IsKYCVerified)
				return false;

			BankAccount account = branch.GetAccount(accountNumber);
			if (account == null)
				return false;

			// Delegate money rules to BankAccount
			return account.Deposit(amount);
		}

		internal static bool ApproveWithdrawal(
			Branch branch,
			User user,
			string accountNumber,
			double amount)
		{
			if (branch == null || user == null || string.IsNullOrWhiteSpace(accountNumber))
				return false;

			// Ensure user owns the account
			if (user.AccountNumber != accountNumber)
				return false;

			// Compliance gate
			if (!user.IsKYCVerified)
				return false;

			BankAccount account = branch.GetAccount(accountNumber);
			if (account == null)
				return false;

			// Delegate all money/state rules to BankAccount
			return account.Withdraw(amount);
		}

		internal static bool ReverseTransaction(
			Branch branch,
			User user,
			string accountNumber,
			double amount)
		{
			if (branch == null || user == null || string.IsNullOrWhiteSpace(accountNumber))
				return false;

			// Ensure user owns the account
			if (user.AccountNumber != accountNumber)
				return false;

			if (amount <= 0)
				return false;

			BankAccount account = branch.GetAccount(accountNumber);
			if (account == null)
				return false;

			// Even if frozen or blocked, reversal is allowed
			return account.Deposit(amount);
		}

		internal static bool ApplyFeesAndCharges(
			Branch branch,
			string accountNumber,
			double feeAmount)
		{
			if (branch == null || string.IsNullOrWhiteSpace(accountNumber))
				return false;

			if (feeAmount <= 0)
				return false;

			BankAccount account = branch.GetAccount(accountNumber);
			if (account == null)
				return false;

			// Fees should not be applied to blocked accounts
			if (account.IsBlocked)
				return false;

			// Reuse withdrawal logic
			return account.Withdraw(feeAmount);
		}

		internal static bool ApplyInterest(
			Branch branch,
			string accountNumber,
			double interestRate)
		{
			if (branch == null || string.IsNullOrWhiteSpace(accountNumber))
				return false;

			if (interestRate <= 0)
				return false;

			BankAccount account = branch.GetAccount(accountNumber);
			if (account == null)
				return false;

			// Interest should not be applied to blocked accounts
			if (account.IsBlocked)
				return false;

			double interestAmount = account.Balance * interestRate;

			if (interestAmount <= 0)
				return false;

			// Credit interest using existing deposit rules
			return account.Deposit(interestAmount);
		}
	}
}
