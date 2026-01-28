// This program demonstrates retrieving a custom attribute at runtime using Reflection.
// An Author attribute is applied to a class and its value is read dynamically.

using System;
using System.Reflection;

namespace ReflectionAssignment
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AuthorAttribute : Attribute
    {
        public string Name { get; }

        public AuthorAttribute(string name)
        {
            Name = name;
        }
    }

    [Author("John Smith")]
    public class BookAuthorDemo
    {
        public void Display()
        {
            Console.WriteLine("Book class loaded.");
        }
    }

    class Program_RetrieveAuthorAttribute
    {
        static void Main()
        {
            Type type = typeof(BookAuthorDemo);

            AuthorAttribute attribute =
                (AuthorAttribute)Attribute.GetCustomAttribute(type, typeof(AuthorAttribute));

            if (attribute != null)
            {
                Console.WriteLine("Author Name: " + attribute.Name);
            }

            BookAuthorDemo book = new BookAuthorDemo();
            book.Display();
        }
    }
}
