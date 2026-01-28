using System;

// This program demonstrates method overriding using inheritance.
// A child class overrides a virtual method of the parent class
// to achieve runtime polymorphism.
namespace AttributesAssignment
{
    // Parent class
    public class Animal
    {
        // Virtual method that can be overridden
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound");
        }
    }

    // Child class
    public class Dog : Animal
    {
        // Overriding the parent class method
        public override void MakeSound()
        {
            Console.WriteLine("Dog barks");
        }
    }

    class Program
    {
        static void Main()
        {
            Animal animal = new Dog();
            animal.MakeSound();
        }
    }
}
