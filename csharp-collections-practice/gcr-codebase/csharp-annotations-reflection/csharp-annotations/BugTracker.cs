// This program demonstrates the use of a repeatable custom attribute in C#.
// The same attribute is applied multiple times to a method and read using reflection.

using System;
using System.Reflection;

namespace AttributesAssignment
{
    // Repeatable attribute definition
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class BugReportAttribute : Attribute
    {
        public string Description { get; }

        public BugReportAttribute(string description)
        {
            Description = description;
        }
    }

    public class BugTracker
    {
        [BugReport("Null reference issue")]
        [BugReport("Performance slowdown under load")]
        public void ProcessData()
        {
            Console.WriteLine("Processing data...");
        }
    }

    class Program
    {
        static void Main()
        {
            MethodInfo method = typeof(BugTracker).GetMethod("ProcessData");

            object[] attributes = method.GetCustomAttributes(typeof(BugReportAttribute), false);

            foreach (BugReportAttribute bug in attributes)
            {
                Console.WriteLine($"Bug: {bug.Description}");
            }

            BugTracker tracker = new BugTracker();
            tracker.ProcessData();
        }
    }
}
