// This program demonstrates accessing and modifying a private static field using Reflection.
// A static configuration value is updated dynamically at runtime.

using System;
using System.Reflection;

namespace ReflectionAssignment
{
    public class ConfigurationStaticDemo
    {
        private static string API_KEY = "DEFAULT_KEY";
    }

    class Program_ModifyStaticField
    {
        static void Main()
        {
            Type type = typeof(ConfigurationStaticDemo);

            FieldInfo field = type.GetField(
                "API_KEY",
                BindingFlags.NonPublic | BindingFlags.Static
            );

            Console.WriteLine("Old API Key: " + field.GetValue(null));

            field.SetValue(null, "NEW_SECURE_KEY");

            Console.WriteLine("New API Key: " + field.GetValue(null));
        }
    }
}
