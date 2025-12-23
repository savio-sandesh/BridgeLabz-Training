using System;

class FizzBuzzUsingWhile{
		static  void Main(){
		
		Console.WriteLine("Enter the number: ");
		int number=int.Parse(Console.ReadLine());
		
		if(number>0){
			int s=1;
			
			while(s<=number){
					
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
				s++;
			}
		}
	}
}