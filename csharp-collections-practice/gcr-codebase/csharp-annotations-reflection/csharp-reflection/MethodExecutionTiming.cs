// This program demonstrates measuring method execution time using Reflection.
// Methods are invoked dynamically and timed using Stopwatch.

using System;
using System.Diagnostics;
using System.Reflection;

namespace ReflectionAssignment
{
    public class PerformanceDemo
    {
        public void FastMethod()
        {
            for (int i = 0; i < 1000000; i++) { }
        }

        public void SlowMethod()
        {
            System.Threading.Thread.Sleep(300);
        }
    }

    class Program_MethodExecutionTiming
    {
        static void Main()
        {
            PerformanceDemo demo = new PerformanceDemo();
            Type type = typeof(PerformanceDemo);

            MethodInfo[] methods = type.GetMethods(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly
            );

            foreach (MethodInfo method in methods)
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
