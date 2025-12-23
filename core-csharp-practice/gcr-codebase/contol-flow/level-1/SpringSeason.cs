using System;

class SpringSeason{
		static void Main(){
		
		// Asking user to enter the month
		Console.WriteLine("Enter the month: ");
		int month=int.Parse(Console.ReadLine());
		
		// Asking user to enter the day
		Console.WriteLine("Enter the day: ");
		int day=int.Parse(Console.ReadLine());
		
		

		if((month==3 && day>=20) ||  (month == 4) || (month == 5) || (month==6 && day<=20)){
				Console.WriteLine("Its a Spring Season");
		}
		else{
			Console.WriteLine("Not a Spring Season");
		}
		
			/*
			 We can use DateTime struct to handle all the edge cases.
             DateTime is a built-in .NET structure that represents
             a complete calendar date (year, month, day).

             By creating a DateTime object, we automatically get:
             - validation of correct dates (e.g., April 31 is invalid)
             - ability to compare dates using relational operators
            */
	}
}