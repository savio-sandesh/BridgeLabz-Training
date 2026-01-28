// This program demonstrates a custom attribute to mark important methods.
// Methods are annotated and discovered at runtime using reflection.

using System;
using System.Reflection;

namespace AttributesAssignment
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ImportantMethodAttribute : Attribute
    {
        public string Level { get; }

        public ImportantMethodAttribute(string level = "HIGH")
        {
            Level = level;
        }
    }

    public class Service
    {
        [ImportantMethod]
        public void ProcessOrder()
        {
            Console.WriteLine("Order processed.");
        }

        [ImportantMethod("MEDIUM")]
        public void GenerateReport()
        {
            Console.WriteLine("Report generated.");
        }

        public void HelperMethod()
        {
            Console.WriteLine("Helper method.");
        }
    }

    class Program
    {
        static void Main()
        {
            MethodInfo[] methods = typeof(Service).GetMethods();

            foreach (MethodInfo method in methods)
            {
                ImportantMethodAttribute attribute =
                    (ImportantMethodAttribute)Attribute.GetCustomAttribute(
                        method,
                        typeof(ImportantMethodAttribute)
                    );

                if (attribute != null)
                {
                    Console.WriteLine(
                        $"Important Method: {method.Name}, Level: {attribute.Level}"
                    );
                }
            }
        }
    }
}
