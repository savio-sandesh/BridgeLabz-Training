using System;

class IntegerTypeCheck{
		static void Main(){
		
		// Asking user to enter the number
		Console.WriteLine("Enter the number: ");
		int number=int.Parse(Console.ReadLine());
		
		if(number==0){
				Console.WriteLine("Zero");
		}
		
		else if(number>0){
				Console.WriteLine("Positive");
		}
		else {
				Console.WriteLine("Negative");
		}
	}
}