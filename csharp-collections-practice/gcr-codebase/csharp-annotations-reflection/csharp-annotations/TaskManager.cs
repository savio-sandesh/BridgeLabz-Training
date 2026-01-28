// This program demonstrates creating and using a custom attribute in C#.
// A custom attribute is applied to a method and read at runtime using reflection.

using System;
using System.Reflection;

namespace AttributesAssignment
{
    // Custom attribute definition
    [AttributeUsage(AttributeTargets.Method)]
    public class TaskInfoAttribute : Attribute
    {
        public string Priority { get; }
        public string AssignedTo { get; }

        public TaskInfoAttribute(string priority, string assignedTo)
        {
            Priority = priority;
            AssignedTo = assignedTo;
        }
    }

    public class TaskManager
    {
        [TaskInfo("High", "Alice")]
        public void CompleteTask()
        {
            Console.WriteLine("Task completed.");
        }
    }

    class Program
    {
        static void Main()
        {
            TaskManager manager = new TaskManager();
            MethodInfo method = typeof(TaskManager).GetMethod("CompleteTask");

            TaskInfoAttribute attribute =
                (TaskInfoAttribute)Attribute.GetCustomAttribute(method, typeof(TaskInfoAttribute));

            if (attribute != null)
            {
                Console.WriteLine($"Priority: {attribute.Priority}");
                Console.WriteLine($"Assigned To: {attribute.AssignedTo}");
            }

            manager.CompleteTask();
        }
    }
}
