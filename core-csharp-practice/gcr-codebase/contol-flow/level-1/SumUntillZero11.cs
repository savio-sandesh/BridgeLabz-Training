using System;

class SumUntillZero11{
		static void Main(){
		
		// variable to store the total sum of the numbers
		double total =0.0;
		
		// infinite while loop
		while(true){
				// Asking user to enter the number
				Console.WriteLine("Enter the number: ");
				double number=double.Parse(Console.ReadLine());
				
				if(number<=0){
					break;
				}
				
				total+=number;
		}
		
		Console.WriteLine("The Total Value is "+total);
}
}