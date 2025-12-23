using System;

class MultiplicationTable{
		static void Main(){
		
		// Asking user to enter the number
		Console.WriteLine("Enter the number: ");
		int number=int.Parse(Console.ReadLine());
		
		for(int i=6;i<=9;i++){
			 Console.WriteLine(number + " * " + i + " = " + (number * i));
		}
	}
}