// This program demonstrates a simple dependency injection mechanism using Reflection.
// Dependencies marked with an Inject attribute are resolved and injected at runtime.

using System;
using System.Reflection;

namespace ReflectionAssignment
{
    [AttributeUsage(AttributeTargets.Field)]
    public class InjectAttribute : Attribute
    {
    }

    public interface IServiceDemo
    {
        void Serve();
    }

    public class ServiceDemo : IServiceDemo
    {
        public void Serve()
        {
            Console.WriteLine("Service is serving...");
        }
    }

    public class ClientDemo
    {
        [Inject]
        private IServiceDemo service;

        public void Start()
        {
            service.Serve();
        }
    }

    public class SimpleDIContainer
    {
        public static void InjectDependencies(object obj)
        {
            Type type = obj.GetType();
            FieldInfo[] fields = type.GetFields(
                BindingFlags.NonPublic | BindingFlags.Instance
            );

            foreach (FieldInfo field in fields)
            {
                if (Attribute.IsDefined(field, typeof(InjectAttribute)))
                {
                    Type dependencyType = field.FieldType;
                    object dependencyInstance = Activator.CreateInstance(dependencyType);
                    field.SetValue(obj, dependencyInstance);
                }
            }
        }
    }

    class Program_DependencyInjection
    {
        static void Main()
        {
            ClientDemo client = new ClientDemo();
            SimpleDIContainer.InjectDependencies(client);
            client.Start();
        }
    }
}
