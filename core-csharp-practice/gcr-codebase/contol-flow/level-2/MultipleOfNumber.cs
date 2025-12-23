using System;

class MultipleOfNumber{
		static void Main(){
		
		// asking user to enter the number
		Console.WriteLine("Enter the number: ");
		int number = int.Parse(Console.ReadLine());
		
		Console.WriteLine("Multiples of a number below 100 are:");
		
		// Multiples are numbers that are perfectly divisible by the given number.

		for(int r=100;r>=1;r--){
			if(r%number==0){
				Console.WriteLine(r);
			}
		}
	}
}