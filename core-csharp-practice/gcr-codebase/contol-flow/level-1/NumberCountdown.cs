using System;

class NumberCountdown{
			static void Main(){
		
		// Asking user to enter the number
		Console.WriteLine("Enter the number: ");
		int counter=int.Parse(Console.ReadLine());
		
		while(counter>=1){
			Console.WriteLine(counter);
			counter--;
		}
	}
}