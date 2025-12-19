// Access Modifier-private

using System;
class Car
{

  // If you declare a field with a private access modifier, 
  // it can only be accessed within the same class:
  private string model = "Porsche Cayenne";

  static void Main(string[] args)
  {
    Car myObj = new Car();
    Console.WriteLine(myObj.model);
  }
  
}
 
 
