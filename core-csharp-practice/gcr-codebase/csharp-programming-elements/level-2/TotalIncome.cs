using System;

class TotalIncome{
		static void Main(){
		
		// Asking user to enter the salary
		Console.WriteLine("Enter the Salary Amount :");
		
		// read input from user and store in a variable
		double salary=double.Parse(Console.ReadLine());
		
		// Asking user to enter the bonus
		Console.WriteLine("Enter the Bonus Amount :");
		
		// read input from the user and store in a variable 
		double bonus=double.Parse(Console.ReadLine());
		
		// computing income by adding salary and bonus
		double income=salary+bonus;
		
		Console.WriteLine("The salary is INR "+salary+" and bonus is INR "+bonus+". Hence Total Income is INR " + income);
		
	}
}