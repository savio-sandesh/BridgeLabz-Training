using System;

class DayOfWeek{
		static void Main(){
		
		// asking user to enter the month
		Console.WriteLine("Enter the month: ");
		int m= int.Parse(Console.ReadLine());
		
		
		// asking user to enter the day
		Console.WriteLine("Enter the day: ");
		int d= int.Parse(Console.ReadLine());
		
		// asking user to enter the year
		Console.WriteLine("Enter the year: ");
		int y= int.Parse(Console.ReadLine());
		
		// applying the given formula 
		int yo=y-(14-m)/12;
		int x=yo + yo/4 - yo/100 + yo/400;
		int mo=m+12*((14-m)/12)-2;
		int d0=(d+x+(31*mo)/12)%7;
		
		Console.WriteLine(d0);
	}
}
		