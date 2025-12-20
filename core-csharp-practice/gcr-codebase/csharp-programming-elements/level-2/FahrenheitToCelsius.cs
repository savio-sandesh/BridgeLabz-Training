using System;

class FahrenheitToCelsius{
		static void Main(){
			

		// Ask the user to enter the Temperature in Fahrenheit
		Console.WriteLine("Enter the value of Temperature in Fahrenheit:");
		double Fahrenheit =	double.Parse(Console.ReadLine());
		
		// Convert Fahrenheit to Celsius using formula:
        // Fahrenheit to Celsius: (°F − 32) x 5/9 = °C
		double c=(Fahrenheit-32)*5/9;
		
		
		Console.WriteLine("The "+ Fahrenheit+" Fahrenheit is "+ c+ " Celsius");
		}
	}