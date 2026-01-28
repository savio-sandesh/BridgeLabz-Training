using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace UnitTestingAssignment
{
    // BUSINESS LOGIC CLASS (Class Under Test)
    public class BankAccount
    {
        private double balance;

        // Adds money to the account
        public void Deposit(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");

            balance += amount;
        }

        // Withdraws money from the account
        public void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive.");

            if (amount > balance)
                throw new InvalidOperationException("Insufficient funds.");

            balance -= amount;
        }

        // Returns the current balance
        public double GetBalance()
        {
            return balance;
        }
    }

    // MSTEST TEST CLASS (Banking Transactions)
    [TestClass]
    public class BankAccountMSTest
    {
        private BankAccount account;

        [TestInitialize]
        public void Setup()
        {
            account = new BankAccount();
        }

        [TestMethod]
        public void Deposit_IncreasesBalance()
        {
            account.Deposit(500);
            Assert.AreEqual(500, account.GetBalance());
        }

        [TestMethod]
        public void Withdraw_DecreasesBalance()
        {
            account.Deposit(500);
            account.Withdraw(200);
            Assert.AreEqual(300, account.GetBalance());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Withdraw_InsufficientFunds_ThrowsException()
        {
            account.Deposit(100);
            account.Withdraw(200);
        }
    }

    // NUNIT TEST CLASS (Banking Transactions)
    [TestFixture]
    public class BankAccountNUnitTest
    {
        private BankAccount account;

        [SetUp]
        public void Setup()
        {
            account = new BankAccount();
        }

        [Test]
        public void Deposit_IncreasesBalance()
        {
            account.Deposit(1000);
            NUnit.Framework.Assert.AreEqual(1000, account.GetBalance());
        }

        [Test]
        public void Withdraw_DecreasesBalance()
        {
            account.Deposit(800);
            account.Withdraw(300);
            NUnit.Framework.Assert.AreEqual(500, account.GetBalance());
        }

        [Test]
        public void Withdraw_InsufficientFunds_ThrowsException()
        {
            account.Deposit(100);

            NUnit.Framework.Assert.Throws<InvalidOperationException>(
                () => account.Withdraw(200)
            );
        }
    }
}
