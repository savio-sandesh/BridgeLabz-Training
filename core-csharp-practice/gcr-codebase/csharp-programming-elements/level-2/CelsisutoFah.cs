using System;

class CelsisutoFah{
		static void Main(){
			

		// Ask the user to enter the Temperature in Celsius
		Console.WriteLine("Enter the value of Temperature in Celsius:");
		double celsius =	double.Parse(Console.ReadLine());
		
		// Convert Celsius to Fahrenheit using formula:
        // Fahrenheit = (Celsius × 9 / 5) + 32
		double f=(celsius*(9/5)) + 32;
		
		
		Console.WriteLine("The "+ celsius+" Celsius is "+ f+ " Fahrenheit");
		}
	}