// This program demonstrates a custom object mapper using Reflection.
// Field values are dynamically assigned from a dictionary to an object.

using System;
using System.Collections.Generic;
using System.Reflection;

namespace ReflectionAssignment
{
    public class ObjectMapperDemo
    {
        public static T ToObject<T>(Dictionary<string, object> properties) where T : new()
        {
            T obj = new T();
            Type type = typeof(T);

            foreach (KeyValuePair<string, object> item in properties)
            {
                FieldInfo field = type.GetField(
                    item.Key,
                    BindingFlags.Public | BindingFlags.Instance
                );

                if (field != null)
                {
                    field.SetValue(obj, item.Value);
                }
            }

            return obj;
        }
    }

    public class UserMappedDemo
    {
        public string Name;
        public int Age;
    }

    class Program_CustomObjectMapper
    {
        static void Main()
        {
            Dictionary<string, object> values = new Dictionary<string, object>
            {
                { "Name", "Alice" },
                { "Age", 28 }
            };

            UserMappedDemo user = ObjectMapperDemo.ToObject<UserMappedDemo>(values);

            Console.WriteLine($"Name: {user.Name}, Age: {user.Age}");
        }
    }
}
