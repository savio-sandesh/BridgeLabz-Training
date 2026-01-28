// This program demonstrates how to inspect a class using Reflection.
// It displays methods, fields, and constructors of a class at runtime.

using System;
using System.Reflection;

namespace ReflectionAssignment
{
    class Program_GetClassInfo
    {
        static void Main()
        {
            Console.Write("Enter fully qualified class name (e.g., System.String): ");
            string className = Console.ReadLine();

            Type type = Type.GetType(className);

            if (type == null)
            {
                Console.WriteLine("Class not found.");
                return;
            }

            Console.WriteLine($"\nClass Name: {type.FullName}");

            Console.WriteLine("\nMethods:");
            MethodInfo[] methods = type.GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }

            Console.WriteLine("\nFields:");
            FieldInfo[] fields = type.GetFields(
                BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.Static
            );
            foreach (FieldInfo field in fields)
            {
                Console.WriteLine(field.Name);
            }

            Console.WriteLine("\nConstructors:");
            ConstructorInfo[] constructors = type.GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
            {
                Console.WriteLine(constructor.ToString());
            }
        }
    }
}
