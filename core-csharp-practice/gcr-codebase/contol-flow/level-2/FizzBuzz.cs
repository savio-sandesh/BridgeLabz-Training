using System;

class FizzBuzz{
		static void Main(){
		
		// asking user to enter the number 
		Console.WriteLine("Enter the number: ");
		int number=int.Parse(Console.ReadLine());
		
		if(number>0){
			
			for(int s =1;s<=number;s++){
					
				if(s%3==0 && s%5==0){
					Console.WriteLine("FizzBuzz");
				}
				else if(s%3==0){
					Console.WriteLine("Fizz");
				}
				else if(s%5==0){
					Console.WriteLine("Buzz");
				}
				else{
					Console.WriteLine(s);
				}
			}
		}
	}
}
		
		