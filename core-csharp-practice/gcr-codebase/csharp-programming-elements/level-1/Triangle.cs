using System;

class Triangle{
		static void Main(){
		
		// Ask the user to enter base of the triangle
		Console.WriteLine("Enter the Base: ");
		
		// Read input from keyboard and convert it to double
		double base1 = double.Parse(Console.ReadLine());

		
		// Ask the user to enter the height of the triangle
		Console.WriteLine("Enter the Height: ");
		
		// Read input from keyboard and convert it to double
		double height = double.Parse(Console.ReadLine());
		
		// area of triangle
		double area=(1.0/2.0)*base1*height;
		
		Console.WriteLine("The area of the triangle is "+area);
		}
		
}