// This program demonstrates role-based access control using a custom attribute.
// Access to a method is allowed or denied based on the user's role at runtime.

using System;
using System.Reflection;

namespace AttributesAssignment
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RoleAllowedAttribute : Attribute
    {
        public string Role { get; }

        public RoleAllowedAttribute(string role)
        {
            Role = role;
        }
    }

    public class SecureOperations
    {
        [RoleAllowed("ADMIN")]
        public void DeleteAllRecords()
        {
            Console.WriteLine("All records deleted.");
        }

        public void ViewRecords()
        {
            Console.WriteLine("Viewing records.");
        }
    }

    class Program_RoleAllowed
    {
        static void Main()
        {
            string currentUserRole = "USER"; // Change to ADMIN to allow access

            SecureOperations ops = new SecureOperations();
            MethodInfo method = typeof(SecureOperations).GetMethod("DeleteAllRecords");

            RoleAllowedAttribute attribute =
                (RoleAllowedAttribute)Attribute.GetCustomAttribute(method, typeof(RoleAllowedAttribute));

            if (attribute != null && attribute.Role == currentUserRole)
            {
                method.Invoke(ops, null);
            }
            else
            {
                Console.WriteLine("Access Denied!");
            }

            ops.ViewRecords();
        }
    }
}
