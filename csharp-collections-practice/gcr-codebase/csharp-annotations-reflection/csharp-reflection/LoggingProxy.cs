// This program demonstrates a custom logging proxy using Reflection.
// Method calls are intercepted to log the method name before execution.

using System;
using System.Reflection;

namespace ReflectionAssignment
{
    public interface IGreetingDemo
    {
        void SayHello();
    }

    public class GreetingDemo : IGreetingDemo
    {
        public void SayHello()
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class LoggingProxy : DispatchProxy
    {
        private object target;

        public static T Create<T>(T targetInstance)
        {
            object proxy = Create<T, LoggingProxy>();
            ((LoggingProxy)proxy).target = targetInstance;
            return (T)proxy;
        }

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            Console.WriteLine("Calling Method: " + targetMethod.Name);
            return targetMethod.Invoke(target, args);
        }
    }

    class Program_LoggingProxy
    {
        static void Main()
        {
            IGreetingDemo greeting = new GreetingDemo();
            IGreetingDemo proxy = LoggingProxy.Create(greeting);

            proxy.SayHello();
        }
    }
}
