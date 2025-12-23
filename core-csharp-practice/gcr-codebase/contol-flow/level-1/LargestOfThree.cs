using System;

class LargestOfThree{

		static void Main(){
		
		// Asking user to senter the number1
		Console.WriteLine("Enter the number1: ");
		int number1=int.Parse(Console.ReadLine());
		
		// Asking user to enter the number2
		Console.WriteLine("Enter the number2: ");
		int number2=int.Parse(Console.ReadLine());
		
		// Asking user to enter the number3
		Console.WriteLine("Enter the number3: ");
		int number3=int.Parse(Console.ReadLine());
		
		bool isFirstLargest  = number1 > number2 && number1 > number3;
        bool isSecondLargest = number2 > number1 && number2 > number3;
        bool isThirdLargest  = number3 > number1 && number3 > number2;
		
		Console.WriteLine("Is the first number the largest?  " + (isFirstLargest ? "Yes" : "No"));
		Console.WriteLine("Is the second number the largest? " + (isSecondLargest ? "Yes" : "No"));
		Console.WriteLine("Is the third number the largest?  " + (isThirdLargest ? "Yes" : "No"));

		}
}		