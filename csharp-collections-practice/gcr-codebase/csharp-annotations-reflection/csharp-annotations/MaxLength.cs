// This program demonstrates a custom MaxLength attribute for field validation.
// The attribute is read at runtime to enforce string length constraints.

using System;
using System.Reflection;

namespace AttributesAssignment
{
    [AttributeUsage(AttributeTargets.Field)]
    public class MaxLengthAttribute : Attribute
    {
        public int Length { get; }

        public MaxLengthAttribute(int length)
        {
            Length = length;
        }
    }

    public class UserMaxLengthDemo
    {
        [MaxLength(10)]
        public string Username;

        public UserMaxLengthDemo(string username)
        {
            FieldInfo field = typeof(UserMaxLengthDemo).GetField("Username");
            MaxLengthAttribute attribute =
                (MaxLengthAttribute)Attribute.GetCustomAttribute(field, typeof(MaxLengthAttribute));

            if (attribute != null && username.Length > attribute.Length)
            {
                throw new ArgumentException($"Username cannot exceed {attribute.Length} characters.");
            }

            Username = username;
        }
    }

    class Program_MaxLength
    {
        static void Main()
        {
            try
            {
                UserMaxLengthDemo user = new UserMaxLengthDemo("VeryLongUsername");
                Console.WriteLine($"Username: {user.Username}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
