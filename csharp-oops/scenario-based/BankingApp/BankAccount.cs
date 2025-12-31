using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    internal class BankAccount
    {
        public string AccountNumber { get; private set; }
        public double Balance { get; private set; }
        public bool IsFrozen { get; internal set; }
        public bool IsBlocked { get; internal set; }

        public BankAccount(string accountNumber)
        {
            AccountNumber = accountNumber;
            Balance = 0;
            IsFrozen = false;
            IsBlocked = false;
        }

        internal bool Deposit(double amount)
        {
            if (IsBlocked || amount <= 0)
                return false;
            Balance += amount;
            return true;
        }

        internal bool Withdraw(double amount)
        {
            if (IsBlocked || IsFrozen || amount <= 0 || amount > Balance)
                return false;
            Balance -= amount;
            return true;
        }
    }
}
