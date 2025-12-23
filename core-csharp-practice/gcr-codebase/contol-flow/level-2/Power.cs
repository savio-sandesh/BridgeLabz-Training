using System;

class Power{
		static void Main(){
			
		// asking user to enter the number
		Console.WriteLine("Enter the number: ");
		int number = int.Parse(Console.ReadLine());
		
		// asking user to enter the power
		Console.WriteLine("Enter the power: ");
		int power = int.Parse(Console.ReadLine());
		
		int result=1;
		
		for(int q=1;q<=power;q++){
			result*=number;
		}
		
		Console.WriteLine("Result is "+result);
		}
	}