using System;

class Swap{
		static void main(){
		
		// Ask the user to enter number1
		Console.WriteLine("Enter the First Number: ");
		
		// Read input from keyboard and convert it to double
		int number1 = int.Parse(Console.ReadLine());

		
		// Ask the user to enter number2
		Console.WriteLine("Enter the Second Number: ");
		
		// Read input from keyboard and convert it to double
		int number2 = int.Parse(Console.ReadLine());
		
		// creating a temporary variable 
		int temp;
		
		// Swapping of  two numbers
		temp=number1;
		number1=number2;
		number2=temp;
		
		Console.WriteLine("The Swapped numbers are "+number1+" and "+number2);
		}
	}