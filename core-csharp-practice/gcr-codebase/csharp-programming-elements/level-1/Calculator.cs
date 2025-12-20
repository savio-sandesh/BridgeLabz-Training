using System;

class Calculator{
		static void Main(){
		
		// Ask the user to enter number1
		Console.WriteLine("Enter the First Number: ");
		
		// Read input from keyboard and convert it to double
		double number1 = double.Parse(Console.ReadLine());

		
		// Ask the user to enter number2
		Console.WriteLine("Enter the Second Number: ");
		
		// Read input from keyboard and convert it to double
		double number2 = double.Parse(Console.ReadLine());
		
		// addition operation 
		double sum=number1+number2;
		
		// subtraction operation
		double sub = number1-number2;
		
		// multiplication operation
		double product = number1*number2;
		
		// divison operation 
		double divison= number1/number2;
		
		// display the result
		Console.WriteLine("The addition, subtraction, multiplication and division value of 2 numbers "+ number1+" and "+number2+" is "+ sum+", "+sub+", "+product+" and "+divison);
		}
}