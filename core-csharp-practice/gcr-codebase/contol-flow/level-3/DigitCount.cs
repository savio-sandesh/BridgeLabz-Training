using System;

class DigitCount{
		static void Main(){
		
		// asking user to enter the number
		Console.WriteLine("Enter the number: ");
		int number = int.Parse(Console.ReadLine());
		
		int count =0;
		
		while(number!=0){
			number/=10;
			count++;
		}
		
		Console .WriteLine("Number of Digits: "+count);
	}
}