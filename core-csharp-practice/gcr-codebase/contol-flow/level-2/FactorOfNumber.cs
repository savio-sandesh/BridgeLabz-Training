using System;

class FactorOfNumber{
		static void Main(){
				
		// asking user to enter the number
		Console.WriteLine("Enter the number: ");
		int number = int.Parse(Console.ReadLine());
		
		Console.WriteLine("The Factor of "+number+" are");
		
		// A factor divides the number perfectly with zero remainder.
		for(int q=1;q<number;q++){
			if(number%q==0){
				Console.WriteLine(q);
				}
			}
		}
	}