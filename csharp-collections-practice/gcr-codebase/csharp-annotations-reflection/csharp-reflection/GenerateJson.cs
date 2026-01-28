// This program demonstrates generating a JSON-like string using Reflection.
// Object fields and their values are inspected dynamically at runtime.

using System;
using System.Reflection;
using System.Text;

namespace ReflectionAssignment
{
    public class JsonObjectDemo
    {
        public string Name;
        public int Age;
        public string City;
    }

    class Program_GenerateJson
    {
        static void Main()
        {
            JsonObjectDemo user = new JsonObjectDemo
            {
                Name = "Alice",
                Age = 30,
                City = "New York"
            };

            string json = ConvertToJson(user);
            Console.WriteLine(json);
        }

        static string ConvertToJson(object obj)
        {
            Type type = obj.GetType();
            FieldInfo[] fields = type.GetFields(
                BindingFlags.Public | BindingFlags.Instance
            );

            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{ ");

            for (int i = 0; i < fields.Length; i++)
            {
                FieldInfo field = fields[i];
                object value = field.GetValue(obj);

                jsonBuilder.Append($"\"{field.Name}\": \"{value}\"");

                if (i < fields.Length - 1)
                    jsonBuilder.Append(", ");
            }

            jsonBuilder.Append(" }");
            return jsonBuilder.ToString();
        }
    }
}
