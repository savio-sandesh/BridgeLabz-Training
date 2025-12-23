using System;

class PrimeNumber{
		static void Main(){
		
		// asking user to enter the number 
		Console.WriteLine("Enter the number: ");
		int number=int.Parse(Console.ReadLine());
		
		bool isPrime=true;
		
		if(number>1){
			
			for (int i=2;i<number;i++){
				
				if(number%i==0){
					isPrime=false;
					break;
				}
			}
			
			if(isPrime){
				Console.WriteLine(number+" is a prime number");
			}
			else{
				Console.WriteLine(number+" is not a prime number");
			}
		}
		else{
			Console.WriteLine(number+" is not a prime number");
		}
	}
}		
		