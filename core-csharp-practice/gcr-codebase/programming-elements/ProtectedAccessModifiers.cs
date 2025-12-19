// Access Modifier -- Protected

// The code is accessible within the same class, 
// or in a class that is inherited from that class. 
// You will learn more about inheritance in a later chapter

using System;

class Parent
{
    // protected variable
    protected int money = 1000;

    protected void ShowMoney()
    {
        Console.WriteLine("Parent's money: " + money);
    }
}

class Child : Parent
{
    public void AccessProtected()
    {
        // Accessing protected members
        Console.WriteLine("Child can see money: " + money);
        ShowMoney();
    }
}

class Program
{
    static void Main()
    {
        Child c = new Child();
        c.AccessProtected();

        // This will cause error
        // c.money;
        // c.ShowMoney();
    }
}
