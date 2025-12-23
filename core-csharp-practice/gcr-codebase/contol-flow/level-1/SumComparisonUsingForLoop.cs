using System;

class SumComparisonUsingForLoop{
		static void Main(){
			
		// Asking user to enter the number
		Console.WriteLine("Enter the number: ");
		int number=int.Parse(Console.ReadLine());
		
		int totalUsingForLoop = 0;
		int totalUsingFormula = 0;
		
		if(number>=1){
			
			// copying the value of number to n 
			// so the original number remains unchanged for the formula calculation
		
			int n = number;
			
			// sum using while loop
			for(int i=n;i>=1;i--){
				totalUsingForLoop += i;
			}
			
			// sum using formula n*(n+1)/2
			totalUsingFormula=number*(number+1)/2;
			
			Console.WriteLine("Sum using for loop: " + totalUsingForLoop);
            Console.WriteLine("Sum using formula: " + totalUsingFormula);
			}
			
			if(totalUsingForLoop == totalUsingFormula){
				Console.WriteLine("Result is Correct");
			}
			else{
				Console.WriteLine("Result is Inorrect");
			}
			
}
}