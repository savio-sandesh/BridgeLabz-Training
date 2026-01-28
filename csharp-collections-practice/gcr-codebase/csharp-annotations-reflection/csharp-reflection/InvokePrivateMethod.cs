// This program demonstrates invoking a private method using Reflection.
// A private method is accessed and executed dynamically at runtime.

using System;
using System.Reflection;

namespace ReflectionAssignment
{
    public class CalculatorPrivateMethodDemo
    {
        private int Multiply(int a, int b)
        {
            return a * b;
        }
    }

    class Program_InvokePrivateMethod
    {
        static void Main()
        {
            CalculatorPrivateMethodDemo calculator = new CalculatorPrivateMethodDemo();
            Type type = calculator.GetType();

            MethodInfo method = type.GetMethod(
                "Multiply",
                BindingFlags.NonPublic | BindingFlags.Instance
            );

            object result = method.Invoke(
                calculator,
                new object[] { 5, 4 }
            );

            Console.WriteLine("Multiplication Result: " + result);
        }
    }
}
