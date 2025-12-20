using System;

class Square{
   static void Main(){
   
		// Ask the user to enter the Perimeter of square
		Console.WriteLine("Enter the Perimeter of square: ");
		
		// Read input from keyboard and convert it to double
		double peri = double.Parse(Console.ReadLine());
		
		// find the length of side using formula (side = perimeter / 4)
		double length=peri/4.0;
		
		Console.WriteLine("The length of the side is " + length + " whose perimeter is " + peri);
		}
}