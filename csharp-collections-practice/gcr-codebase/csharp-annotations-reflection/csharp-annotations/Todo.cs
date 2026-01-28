// This program demonstrates a custom Todo attribute for pending tasks.
// Methods are annotated with task details and discovered using reflection.

using System;
using System.Reflection;

namespace AttributesAssignment
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class TodoAttribute : Attribute
    {
        public string Task { get; }
        public string AssignedTo { get; }
        public string Priority { get; }

        public TodoAttribute(string task, string assignedTo, string priority = "MEDIUM")
        {
            Task = task;
            AssignedTo = assignedTo;
            Priority = priority;
        }
    }

    public class TodoDemo
    {
        [Todo("Implement login feature", "Alice", "HIGH")]
        [Todo("Add validation checks", "Bob")]
        public void BuildAuthentication()
        {
            Console.WriteLine("Authentication module in progress.");
        }

        [Todo("Optimize database queries", "Charlie", "LOW")]
        public void OptimizeDatabase()
        {
            Console.WriteLine("Database optimization pending.");
        }
    }

    class Program_Todo
    {
        static void Main()
        {
            MethodInfo[] methods = typeof(TodoDemo).GetMethods();

            foreach (MethodInfo method in methods)
            {
                object[] attributes = method.GetCustomAttributes(typeof(TodoAttribute), false);

                foreach (TodoAttribute todo in attributes)
                {
                    Console.WriteLine(
                        $"Method: {method.Name}, Task: {todo.Task}, Assigned To: {todo.AssignedTo}, Priority: {todo.Priority}"
                    );
                }
            }
        }
    }
}
