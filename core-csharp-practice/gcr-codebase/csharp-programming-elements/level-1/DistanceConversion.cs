using System;
 class DistanceConversion{
		
		static void Main(){
		
		// Ask the user to enter distance in kilometers
		Console.WriteLine("Enter the Distance: ");
		
		// Read input from keyboard and convert it to double
		double Km = double.Parse(Console.ReadLine());
		
		
		// given 1km=1.6miles 
		// so that 1 mile=1/1.6=>0.625
		// converting kilometers into miles
		double miles = Km*0.625;
		
		Console.WriteLine("The total miles is "+miles+ " mile for the given "+ Km+ " km");

		}
	}
		
		