using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    internal class Branch
    {
        public string BranchName { get; private set; }
        public string Address { get; private set; }
        public string IFSC { get; private set; }

        // branch owns many bank accounts
        private readonly List<BankAccount> bankAccounts;

        public Branch(string branchName, string address, string ifsc)
        {
            BranchName = branchName;
            Address = address;
            IFSC = ifsc;
            bankAccounts = new List<BankAccount>();
        }

        // creating a new account in this branch
        internal BankAccount CreateAccount(string accountNumber)
        {
            // prevent duplicate account numbers
            if (GetAccount(accountNumber) != null)
            {
                return null; // account with this number already exists
            }

            BankAccount account = new BankAccount(accountNumber);
            bankAccounts.Add(account);
            return account;
        }

        // finding an account by account number
        internal BankAccount GetAccount(string accountNumber)
        {
            return bankAccounts.FirstOrDefault(acc => acc.AccountNumber == accountNumber);
        }

        // close an account
        internal bool CloseAccount(string accountNumber)
        {
            BankAccount account = GetAccount(accountNumber);
            if (account == null)
            {
                return false; // account not found
            }
            if (account.Balance != 0)
            {
                return false; // cannot close account with non-zero balance
            }
            bankAccounts.Remove(account);
            return true;
        }
    }
}
