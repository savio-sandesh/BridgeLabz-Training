using System;
using System.Reflection;
using System.Text;
using System.Collections.Generic;

// Custom attribute to mark auditable actions
[AttributeUsage(AttributeTargets.Method)]
public class AuditTrailAttribute : Attribute
{
    public string Description { get; }

    public AuditTrailAttribute(string description)
    {
        Description = description;
    }
}

// Sample service classes
public class UserActions
{
    [AuditTrail("User logged into the system")]
    public void Login(string user)
    {
        Console.WriteLine($"{user} logged in");
    }

    [AuditTrail("User uploaded a file")]
    public void Upload(string file)
    {
        Console.WriteLine($"Uploaded {file}");
    }

    public void ViewProfile() { }
}

public class OrderActions
{
    [AuditTrail("Order placed")]
    public void PlaceOrder(int id) { }

    [AuditTrail("Order cancelled")]
    public void CancelOrder(int id) { }
}

// Audit log record
public class AuditRecord
{
    public string Time;
    public string ClassName;
    public string Method;
    public string Description;
    public string User;

    public string ToJsonLike()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("{");
        sb.AppendLine($"  \"time\": \"{Time}\",");
        sb.AppendLine($"  \"class\": \"{ClassName}\",");
        sb.AppendLine($"  \"method\": \"{Method}\",");
        sb.AppendLine($"  \"description\": \"{Description}\",");
        sb.AppendLine($"  \"user\": \"{User}\"");
        sb.Append("}");
        return sb.ToString();
    }
}

// Core audit tracker
public class EventTracker
{
    private List<AuditRecord> records = new List<AuditRecord>();

    public void Scan(string user)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        foreach (Type type in assembly.GetTypes())
        {
            if (!type.IsClass || type.IsAbstract) continue;

            foreach (MethodInfo method in type.GetMethods(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                AuditTrailAttribute attr =
                    method.GetCustomAttribute<AuditTrailAttribute>();

                if (attr == null) continue;

                records.Add(new AuditRecord
                {
                    Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    ClassName = type.Name,
                    Method = method.Name,
                    Description = attr.Description,
                    User = user
                });
            }
        }
    }

    public void Print()
    {
        Console.WriteLine("\nAudit Log:");
        foreach (var r in records)
        {
            Console.WriteLine(
                $"[{r.Time}] {r.ClassName}.{r.Method} - {r.Description} ({r.User})");
        }
    }

    public void ExportJsonLike()
    {
        Console.WriteLine("\nJSON-like Output:");
        Console.WriteLine("[");
        for (int i = 0; i < records.Count; i++)
        {
            Console.Write(records[i].ToJsonLike());
            if (i < records.Count - 1) Console.Write(",");
            Console.WriteLine();
        }
        Console.WriteLine("]");
    }
}

// Entry point
public class Program
{
    public static void Main()
    {
        Console.Write("Enter current user: ");
        string user = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(user)) user = "system";

        EventTracker tracker = new EventTracker();
        tracker.Scan(user);
        tracker.Print();
        tracker.ExportJsonLike();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
