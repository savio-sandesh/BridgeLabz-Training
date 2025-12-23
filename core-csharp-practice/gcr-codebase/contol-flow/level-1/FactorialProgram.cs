using System;

class FactorialProgram{
		static void Main(){
		
		// Asking user to enter the number
		Console.WriteLine("Enter the number: ");
		int number=int.Parse(Console.ReadLine());
		
		long factorial=1;
		
		if(number>=0){
				
				int n=number;
				
				while(n>=1){
					factorial=factorial*n;
					n--;
				}
				
				Console.WriteLine("Factorial of "+number+" is " +factorial);
			}
		else{
			 Console.WriteLine("Factorial is not defined for negative numbers.");
		}
		
		}
	}