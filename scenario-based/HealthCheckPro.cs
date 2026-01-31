using System;
using System.Reflection;

// Attribute to mark public APIs
[AttributeUsage(AttributeTargets.Method)]
class PublicAPIAttribute : Attribute
{
    public string Description { get; }

    public PublicAPIAttribute(string description = "Public API")
    {
        Description = description;
    }
}

// Attribute to mark APIs requiring authentication
[AttributeUsage(AttributeTargets.Method)]
class RequiresAuthAttribute : Attribute
{
    public string Role { get; }

    public RequiresAuthAttribute(string role = "User")
    {
        Role = role;
    }
}

// Sample controller class
class LabTestController
{
    [PublicAPI("Fetch all lab tests")]
    public void GetAllTests() { }

    [RequiresAuth("Admin")]
    public void AddTest(string testName) { }

    [PublicAPI]
    [RequiresAuth("User")]
    public void GetTestById(int id) { }
}

// HealthCheckPro scanner
class HealthCheckPro
{
    public void ScanAndGenerateDocs()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type[] types = assembly.GetTypes();

        foreach (Type type in types)
        {
            if (!type.IsClass || !type.Name.EndsWith("Controller"))
                continue;

            Console.WriteLine($"\nController: {type.Name}");

            MethodInfo[] methods =
                type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (MethodInfo method in methods)
            {
                Console.WriteLine($"  Method: {method.Name}");

                object[] attributes = method.GetCustomAttributes(false);

                if (attributes.Length == 0)
                {
                    Console.WriteLine("    - No API metadata found");
                    continue;
                }

                foreach (object attr in attributes)
                {
                    if (attr is PublicAPIAttribute pub)
                        Console.WriteLine($"    - PublicAPI: {pub.Description}");

                    if (attr is RequiresAuthAttribute auth)
                        Console.WriteLine($"    - RequiresAuth: Role = {auth.Role}");
                }
            }
        }
    }
}

// Program entry point
class Program
{
    static void Main()
    {
        Console.WriteLine("HealthCheckPro – API Metadata Validator\n");

        HealthCheckPro checker = new HealthCheckPro();
        checker.ScanAndGenerateDocs();

        Console.WriteLine("\nScan completed. Press any key to exit...");
        Console.ReadKey();
    }
}


// git commit -m "Add HealthCheckPro API metadata validator using custom attributes and reflection"
