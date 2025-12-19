// Access Modifier--Private

// If you declare a field with a public access modifier, 
// it is accessible for all classes:

using System;
class Car
{
  public string model = "Wagnor";
}

class Program
{
  static void Main(string[] args)
  {
    Car myObj = new Car();
    Console.WriteLine(myObj.model);
  }
}