using System;

class LeapYear{
	static void Main(){
	
		// asking user to enter the year 
		Console.WriteLine("Enter a year:");
        int year = int.Parse(Console.ReadLine());
		
		if(year<1582){
			Console.WriteLine(" Leap Year calculation is valid only for year 1582 or later.");
			}
			
		else{
			if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0){
				Console.WriteLine(year + " is a Leap Year.");
			}
			else {
				Console.WriteLine(year + " is not a Leap Year.");
			}
		}
	}
}