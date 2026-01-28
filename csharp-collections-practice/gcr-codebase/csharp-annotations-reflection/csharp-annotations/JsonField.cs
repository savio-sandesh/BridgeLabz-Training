// This program demonstrates custom JSON serialization using a JsonField attribute.
// Object fields are mapped to custom JSON keys using reflection.

using System;
using System.Reflection;
using System.Text;

namespace AttributesAssignment
{
    [AttributeUsage(AttributeTargets.Field)]
    public class JsonFieldAttribute : Attribute
    {
        public string Name { get; }

        public JsonFieldAttribute(string name)
        {
            Name = name;
        }
    }

    public class UserJsonDemo
    {
        [JsonField("user_name")]
        public string Username;

        [JsonField("user_age")]
        public int Age;

        public UserJsonDemo(string username, int age)
        {
            Username = username;
            Age = age;
        }
    }

    class Program_JsonField
    {
        static void Main()
        {
            UserJsonDemo user = new UserJsonDemo("Alice", 25);
            string json = SerializeToJson(user);
            Console.WriteLine(json);
        }

        static string SerializeToJson(object obj)
        {
            Type type = obj.GetType();
            FieldInfo[] fields = type.GetFields();
            StringBuilder jsonBuilder = new StringBuilder();

            jsonBuilder.Append("{");

            for (int i = 0; i < fields.Length; i++)
            {
                FieldInfo field = fields[i];
                JsonFieldAttribute attribute =
                    (JsonFieldAttribute)Attribute.GetCustomAttribute(field, typeof(JsonFieldAttribute));

                if (attribute != null)
                {
                    string key = attribute.Name;
                    object value = field.GetValue(obj);

                    jsonBuilder.Append($"\"{key}\": \"{value}\"");

                    if (i < fields.Length - 1)
                        jsonBuilder.Append(", ");
                }
            }

            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }
    }
}
