// This program demonstrates accessing and modifying a private field using Reflection.
// A private field value is retrieved and updated at runtime.

using System;
using System.Reflection;

namespace ReflectionAssignment
{
    public class PersonPrivateFieldDemo
    {
        private int age = 25;
    }

    class Program_AccessPrivateField
    {
        static void Main()
        {
            PersonPrivateFieldDemo person = new PersonPrivateFieldDemo();
            Type type = person.GetType();

            FieldInfo field = type.GetField(
                "age",
                BindingFlags.NonPublic | BindingFlags.Instance
            );

            Console.WriteLine("Old Age: " + field.GetValue(person));

            field.SetValue(person, 30);

            Console.WriteLine("New Age: " + field.GetValue(person));
        }
    }
}
