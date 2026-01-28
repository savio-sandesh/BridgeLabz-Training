// This program demonstrates creating an object dynamically using Reflection.
// An instance is created at runtime without using the new keyword.

using System;
using System.Reflection;

namespace ReflectionAssignment
{
    public class StudentDynamicDemo
    {
        private string name;

        public StudentDynamicDemo(string name)
        {
            this.name = name;
        }

        public void Display()
        {
            Console.WriteLine("Student Name: " + name);
        }
    }

    class Program_DynamicObjectCreation
    {
        static void Main()
        {
            Type type = typeof(StudentDynamicDemo);

            ConstructorInfo constructor = type.GetConstructor(
                new Type[] { typeof(string) }
            );

            object studentObject = constructor.Invoke(
                new object[] { "Emma" }
            );

            MethodInfo displayMethod = type.GetMethod("Display");
            displayMethod.Invoke(studentObject, null);
        }
    }
}
