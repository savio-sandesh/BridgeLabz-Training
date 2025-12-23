using System;

class SumUntillZero{
		static void Main(){
		
		// variable to store the total sum of the numbers
		double total =0.0;
		
		// Asking user to enter the number
		Console.WriteLine("Enter the number: ");
		double number=double.Parse(Console.ReadLine());
		
		while(number!=0){
				// add the entered number to total
				total += number;
				
				// ask user to enter the next number
				Console.WriteLine("Enter the number: ");
				
				number=double.Parse(Console.ReadLine());
		}
		
		Console.WriteLine("The Total Value is "+total);
}
}