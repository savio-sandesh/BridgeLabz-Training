using System;

// -------------------- CUSTOMER MODEL --------------------

class Customer
{
    public string Name { get; }
    public string[] Items { get; }

    public Customer(string name, string[] items)
    {
        Name = name;
        Items = items;
    }
}

// -------------------- QUEUE IMPLEMENTATION --------------------

class CustomerNode
{
    public Customer Customer;
    public CustomerNode Next;

    public CustomerNode(Customer customer)
    {
        Customer = customer;
        Next = null;
    }
}

class CustomerQueue
{
    private CustomerNode front;
    private CustomerNode rear;

    public void Enqueue(Customer customer)
    {
        CustomerNode node = new CustomerNode(customer);

        if (rear == null)
        {
            front = rear = node;
        }
        else
        {
            rear.Next = node;
            rear = node;
        }

        Console.WriteLine("Customer added to queue: " + customer.Name);
    }

    public Customer Dequeue()
    {
        if (front == null)
        {
            Console.WriteLine("Queue is empty.");
            return null;
        }

        Customer customer = front.Customer;
        front = front.Next;

        if (front == null)
            rear = null;

        return customer;
    }

    public bool IsEmpty()
    {
        return front == null;
    }
}

// -------------------- HASH MAP IMPLEMENTATION --------------------

class ItemEntry
{
    public string ItemName;
    public int Price;
    public int Stock;
    public ItemEntry Next;

    public ItemEntry(string itemName, int price, int stock)
    {
        ItemName = itemName;
        Price = price;
        Stock = stock;
        Next = null;
    }
}

class ItemHashMap
{
    private const int SIZE = 10;
    private ItemEntry[] table = new ItemEntry[SIZE];

    private int Hash(string key)
    {
        return Math.Abs(key.GetHashCode()) % SIZE;
    }

    public void Put(string item, int price, int stock)
    {
        int index = Hash(item);
        ItemEntry entry = new ItemEntry(item, price, stock);
        entry.Next = table[index];
        table[index] = entry;
    }

    public ItemEntry Get(string item)
    {
        int index = Hash(item);
        ItemEntry current = table[index];

        while (current != null)
        {
            if (current.ItemName.Equals(item))
                return current;
            current = current.Next;
        }
        return null;
    }
}

// -------------------- SMART CHECKOUT LOGIC --------------------

class SmartCheckout
{
    private CustomerQueue queue = new CustomerQueue();
    private ItemHashMap items = new ItemHashMap();

    public SmartCheckout()
    {
        items.Put("Milk", 40, 10);
        items.Put("Bread", 30, 5);
        items.Put("Apple", 10, 20);
    }

    public void AddCustomer(Customer customer)
    {
        queue.Enqueue(customer);
    }

    public void ProcessBilling()
    {
        while (!queue.IsEmpty())
        {
            Customer customer = queue.Dequeue();
            int total = 0;

            Console.WriteLine("\nBilling for: " + customer.Name);

            foreach (string item in customer.Items)
            {
                ItemEntry entry = items.Get(item);

                if (entry != null && entry.Stock > 0)
                {
                    total += entry.Price;
                    entry.Stock--;
                    Console.WriteLine(item + " - Rs" + entry.Price);
                }
                else
                {
                    Console.WriteLine(item + " - Out of stock");
                }
            }

            Console.WriteLine("Total Bill: Rs" + total);
        }
    }
}

// -------------------- MAIN --------------------

public class SmartCheckoutDemo
{
    public static void Main()
    {
        SmartCheckout checkout = new SmartCheckout();

        checkout.AddCustomer(new Customer(
            "Alice",
            new string[] { "Milk", "Apple" }
        ));

        checkout.AddCustomer(new Customer(
            "Bob",
            new string[] { "Bread", "Milk", "Apple" }
        ));

        checkout.AddCustomer(new Customer(
            "Charlie",
            new string[] { "Bread", "Bread" }
        ));

        checkout.ProcessBilling();
    }
}
