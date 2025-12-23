using System;

class AbundantNumber{
		static void Main(){
		
		// asking user to enter the number
		Console.WriteLine("Enter the number: ");
		int number = int.Parse(Console.ReadLine());
		
		int sum=0;
		
		//finding all the possible divisors and their sum
		for(int t=1;t<number;t++){
			if(number%t==0){
				sum+=t;
			}
		}
		
		// An abundant number has the sum of its proper divisors greater than the number itself.
 
		if(sum>number){
			Console.WriteLine("Abundant Number");
		}
		else{
			Console.WriteLine("Not an Abundant Number");
		}
		
		}
}
