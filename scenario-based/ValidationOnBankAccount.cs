using NUnit.Framework;
using System;

[TestFixture]
public class UnitTest
{
    private Program account;

    [SetUp]
    public void Setup()
    {
        account = new Program(1000m);
    }

    [Test]
    public void Test_Deposit_ValidAmount()
    {
        account.Deposit(500m);
        Assert.AreEqual(1500m, account.Balance);
    }

    [Test]
    public void Test_Deposit_NegativeAmount()
    {
        Exception ex = Assert.Throws<Exception>(() =>
            account.Deposit(-200m));

        Assert.AreEqual("Deposit amount cannot be negative", ex.Message);
    }

    [Test]
    public void Test_Withdraw_ValidAmount()
    {
        account.Withdraw(400m);
        Assert.AreEqual(600m, account.Balance);
    }

    [Test]
    public void Test_Withdraw_InsufficientFunds()
    {
        Exception ex = Assert.Throws<Exception>(() =>
            account.Withdraw(2000m));

        Assert.AreEqual("Insufficient funds.", ex.Message);
    }
}

public class Program
{
    public decimal Balance { get; private set; }

    public Program(decimal initialBalance)
    {
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount < 0)
            throw new Exception("Deposit amount cannot be negative");

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount > Balance)
            throw new Exception("Insufficient funds.");

        Balance -= amount;
    }
}
