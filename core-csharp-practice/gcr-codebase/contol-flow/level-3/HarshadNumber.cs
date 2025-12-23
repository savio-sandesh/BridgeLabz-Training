using System;

class HarshadNumber{
		static void Main(){
		
		// asking user to enter the number
		Console.WriteLine("Enter the number: ");
		int number = int.Parse(Console.ReadLine());
		
		int n=number;
		int sum=0;
		
		// A number is Harshad if it is divisible by the sum of its digits.

		while(n!=0){
			int remainder = n%10;
			sum+=remainder;
			n/=10;
		}
		
		if(number%sum==0){
				Console.WriteLine("Harshad Number");
		}
		else{
				Console.WriteLine("Not a Harshad Number");
		}
	}
}