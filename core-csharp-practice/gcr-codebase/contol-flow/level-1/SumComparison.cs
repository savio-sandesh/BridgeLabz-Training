using System;

class SumComparison{
		static void Main(){
			
		// Asking user to enter the number
		Console.WriteLine("Enter the number: ");
		int number=int.Parse(Console.ReadLine());
		
		int totalUsingWhile = 0;
		int totalUsingFormula = 0;
		
		if(number>=1){
			
			int n = number;
			// sum using while loop
			while(n!=0){
				totalUsingWhile += n;
				n--;
			}
			
			// sum using formula n*(n+1)/2
			totalUsingFormula=number*(number+1)/2;
			
			Console.WriteLine("Sum using while loop: " + totalUsingWhile);
            Console.WriteLine("Sum using formula: " + totalUsingFormula);
			}
			
			if(totalUsingWhile == totalUsingFormula){
				Console.WriteLine("Result is Correct");
			}
			else{
				Console.WriteLine("Result is Inorrect");
			}
			
}
}