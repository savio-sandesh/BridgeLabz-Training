// This program demonstrates dynamic method invocation using Reflection.
// A method is selected at runtime based on user input and executed dynamically.

using System;
using System.Reflection;

namespace ReflectionAssignment
{
    public class MathOperationsDemo
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }

    class Program_DynamicMethodInvocation
    {
        static void Main()
        {
            MathOperationsDemo math = new MathOperationsDemo();
            Type type = typeof(MathOperationsDemo);

            Console.Write("Enter method name (Add / Subtract / Multiply): ");
            string methodName = Console.ReadLine();

            MethodInfo method = type.GetMethod(methodName);

            if (method == null)
            {
                Console.WriteLine("Invalid method name.");
                return;
            }

            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine());

            object result = method.Invoke(math, new object[] { a, b });

            Console.WriteLine("Result: " + result);
        }
    }
}
