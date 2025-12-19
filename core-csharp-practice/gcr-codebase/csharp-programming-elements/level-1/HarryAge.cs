using System;

class Harry{
	static void Main(){
	 
	 int birthyear=2000;
	 
	 // Current year is taken as 2024 as per the problem statement.
     // Note: In a real-world scenario, we can use DateTime.Now.Year
     // to dynamically get the current year
	 
	 int currentyear=2024; 
	 int age =currentyear-birthyear;
	 
	 Console.WriteLine("Harry's age in 2024 is " + age);
	}
}