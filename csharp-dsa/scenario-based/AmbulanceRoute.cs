using System;

// Node representing a hospital unit in the circular linked list
class HospitalUnit
{
    public string Name;
    public bool Available;
    public HospitalUnit Next;

    public HospitalUnit(string name)
    {
        Name = name;
        Available = true;
        Next = null;
    }
}

// Circular linked list to manage ambulance routing
class AmbulanceRoute
{
    private HospitalUnit head;
    private HospitalUnit tail;

    // Adds a hospital unit to the circular route
    public void AddUnit(string name)
    {
        HospitalUnit unit = new HospitalUnit(name);

        if (head == null)
        {
            head = tail = unit;
            unit.Next = head;
        }
        else
        {
            tail.Next = unit;
            tail = unit;
            tail.Next = head;
        }
    }

    // Removes a hospital unit from the route (maintenance case)
    public void RemoveUnit(string name)
    {
        if (head == null) return;

        if (head.Name == name)
        {
            if (head == tail)
            {
                head = tail = null;
                return;
            }
            tail.Next = head.Next;
            head = head.Next;
            return;
        }

        HospitalUnit current = head;
        while (current.Next != head)
        {
            if (current.Next.Name == name)
            {
                if (current.Next == tail)
                    tail = current;

                current.Next = current.Next.Next;
                return;
            }
            current = current.Next;
        }
    }

    // Finds the next available hospital unit starting from a given unit
    public HospitalUnit FindNextAvailable(HospitalUnit start)
    {
        if (start == null) return null;

        HospitalUnit current = start;
        do
        {
            if (current.Available)
                return current;

            current = current.Next;
        } while (current != start);

        return null;
    }

    // Retrieves a hospital unit by name
    public HospitalUnit GetUnit(string name)
    {
        if (head == null) return null;

        HospitalUnit current = head;
        do
        {
            if (current.Name == name)
                return current;

            current = current.Next;
        } while (current != head);

        return null;
    }

    // Displays all hospital units in the route
    public void PrintUnits()
    {
        if (head == null)
        {
            Console.WriteLine("No hospital units available.");
            return;
        }

        HospitalUnit current = head;
        do
        {
            Console.WriteLine($"{current.Name} (Available: {current.Available})");
            current = current.Next;
        } while (current != head);
    }
}

// Entry point for simulating ambulance navigation
public class AmbulanceRouteDemo
{
    public static void Main()
    {
        AmbulanceRoute route = new AmbulanceRoute();

        route.AddUnit("Emergency");
        route.AddUnit("Radiology");
        route.AddUnit("Surgery");
        route.AddUnit("ICU");

        Console.WriteLine("Hospital Units:");
        route.PrintUnits();

        Console.Write("\nEnter unit to mark unavailable: ");
        string unavailable = Console.ReadLine();
        if (!string.IsNullOrEmpty(unavailable))
        {
            HospitalUnit unit = route.GetUnit(unavailable);
            if (unit != null) unit.Available = false;
        }

        Console.Write("\nEnter starting unit (default Emergency): ");
        string startName = Console.ReadLine();
        if (string.IsNullOrEmpty(startName)) startName = "Emergency";

        HospitalUnit start = route.GetUnit(startName);
        HospitalUnit next = route.FindNextAvailable(start);

        if (next != null)
            Console.WriteLine("Patient redirected to: " + next.Name);
        else
            Console.WriteLine("No available unit found.");

        Console.Write("\nEnter unit to remove for maintenance: ");
        string remove = Console.ReadLine();
        if (!string.IsNullOrEmpty(remove))
        {
            route.RemoveUnit(remove);
            Console.WriteLine("\nAfter removal:");
            route.PrintUnits();
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
