using System;

class QuotientAndRemainder{
		static void Main(){
		
		// Ask the user to enter number1
		Console.WriteLine("Enter the First Number: ");
		
		// Read input from keyboard and convert it to double
		int number1 = int.Parse(Console.ReadLine());

		
		// Ask the user to enter number2
		Console.WriteLine("Enter the Second Number: ");
		
		// Read input from keyboard and convert it to double
		int number2 = int.Parse(Console.ReadLine());
		
		// to find quotient
		int quotient = number1/number2;
		
		//to find remainder
		int remainder =number1%number2;
		
		Console.WriteLine("The Quotient is "+quotient+" and Remainder is "+ 
							remainder +" of two numbers "+number1+" and "+number2);
		}
	}
							