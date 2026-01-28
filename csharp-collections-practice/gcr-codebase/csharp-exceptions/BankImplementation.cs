// Develop a Bank Account System where:
// Withdraw(double amount) method:
// Throws InsufficientFundsException if withdrawal amount exceeds balance.
// Throws ArgumentException if the amount is negative.
// Handle exceptions in Main().

using System;

class InsufficientFundsException : Exception
{
}

class BankAccount
{
    private double balance = 5000;

    public void Withdraw(double amount)
    {
        // Validation is done early to protect account state
        if (amount < 0)
        {
            throw new ArgumentException();
        }

        if (amount > balance)
        {
            throw new InsufficientFundsException();
        }

        balance -= amount;
        Console.WriteLine("Withdrawal successful, new balance: " + balance);
    }
}

class BankImplementation
{
    static void Main()
    {
        BankAccount account = new BankAccount();

        Console.WriteLine("1. Withdraw Amount");
        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            try
            {
                Console.Write("Enter withdrawal amount: ");
                double amount = double.Parse(Console.ReadLine());

                account.Withdraw(amount);
            }
            catch (InsufficientFundsException)
            {
                // Custom exception enforces business rule for balance check
                Console.WriteLine("Insufficient balance!");
            }
            catch (ArgumentException)
            {
                // Prevents invalid withdrawal requests
                Console.WriteLine("Invalid amount!");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice");
        }
    }
}
