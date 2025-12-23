using System;

class NaturalNumberSum{

		static void Main(){
		
		// Asking user to enter the number
		Console.WriteLine("Enter the number: ");
		int number=int.Parse(Console.ReadLine());
		
		if(number>0){
				Console.WriteLine("The sum of " + number+ " natural numbers is " + (number*(number+1)/2));
			}
		else{
				Console.WriteLine("The number "+ number + " is not a natural number");
			}
			
		}
}