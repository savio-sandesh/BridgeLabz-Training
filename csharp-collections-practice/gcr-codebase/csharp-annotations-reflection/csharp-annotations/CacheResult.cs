// This program demonstrates method result caching using a custom CacheResult attribute.
// Cached results are reused to avoid repeated expensive computations.

using System;
using System.Collections.Generic;
using System.Reflection;

namespace AttributesAssignment
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CacheResultAttribute : Attribute
    {
    }

    public class CalculationCacheDemo
    {
        private static Dictionary<string, int> cache = new Dictionary<string, int>();

        [CacheResult]
        public int ExpensiveCalculation(int number)
        {
            string key = $"{nameof(ExpensiveCalculation)}_{number}";

            if (cache.ContainsKey(key))
            {
                Console.WriteLine("Returning cached result.");
                return cache[key];
            }

            Console.WriteLine("Performing expensive calculation...");
            int result = number * number; // Simulated expensive operation

            cache[key] = result;
            return result;
        }
    }

    class Program_CacheResult
    {
        static void Main()
        {
            CalculationCacheDemo demo = new CalculationCacheDemo();
            MethodInfo method = typeof(CalculationCacheDemo).GetMethod("ExpensiveCalculation");

            if (Attribute.IsDefined(method, typeof(CacheResultAttribute)))
            {
                Console.WriteLine(demo.ExpensiveCalculation(5));
                Console.WriteLine(demo.ExpensiveCalculation(5));
            }
        }
    }
}
