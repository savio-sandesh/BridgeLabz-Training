// This program demonstrates logging method execution time using a custom attribute.
// Execution time is measured at runtime using reflection and Stopwatch.

using System;
using System.Diagnostics;
using System.Reflection;

namespace AttributesAssignment
{
    [AttributeUsage(AttributeTargets.Method)]
    public class LogExecutionTimeAttribute : Attribute
    {
    }

    public class ExecutionTimeDemo
    {
        [LogExecutionTime]
        public void FastOperation()
        {
            for (int i = 0; i < 1000000; i++) { }
        }

        [LogExecutionTime]
        public void SlowOperation()
        {
            System.Threading.Thread.Sleep(500);
        }
    }

    class Program_LogExecutionTime
    {
        static void Main()
        {
            ExecutionTimeDemo demo = new ExecutionTimeDemo();
            MethodInfo[] methods = typeof(ExecutionTimeDemo).GetMethods();

            foreach (MethodInfo method in methods)
            {
                if (Attribute.IsDefined(method, typeof(LogExecutionTimeAttribute)))
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    method.Invoke(demo, null);
                    stopwatch.Stop();

                    Console.WriteLine(
                        $"Method: {method.Name}, Execution Time: {stopwatch.ElapsedMilliseconds} ms"
                    );
                }
            }
        }
    }
}
