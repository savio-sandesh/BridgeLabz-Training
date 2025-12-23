using System;

class ArmstrongNumber{
		static void Main(){
		
		// asking user to enter the number
		Console.WriteLine("Enter the number: ");
		int number = int.Parse(Console.ReadLine());
		
		int n=number;
		int sum=0;
		
		while(n!=0){
			
			int remainder = n%10;
			sum+=remainder*remainder*remainder;
			n/=10;
			
		}
			if(sum==number){
				Console.WriteLine(number+" is an armstrong number");
			}
			else{
				Console.WriteLine(number+" is not an armstrong number");
			}
		}
}		