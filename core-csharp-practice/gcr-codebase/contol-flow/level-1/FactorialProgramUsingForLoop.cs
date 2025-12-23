using System;

class FactorialProgramUsingForLoop{
		static void Main(){
		
		// Asking user to enter the number
		Console.WriteLine("Enter the number: ");
		int number=int.Parse(Console.ReadLine());
		
		long factorial=1;
		
		if(number>=0){
				
				int n=number;
				
				for(int i=n;i>=1;i--){
					factorial=factorial*i;
				
				}
				
				Console.WriteLine("Factorial of "+number+" is " +factorial);
			}
		else{
			 Console.WriteLine("Factorial is not defined for negative numbers.");
		}
		
		}
	}