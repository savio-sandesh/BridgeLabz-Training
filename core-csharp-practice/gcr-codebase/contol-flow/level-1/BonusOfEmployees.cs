using System;

class BonusOfEmployees{
		static void Main(){
		
		// asking user to enter the salary
		Console.WriteLine("Enter the salary:");
        double salary = double.Parse(Console.ReadLine());

		// asking user to enter the number of years
        Console.WriteLine("Enter the years of service:");
        int years = int.Parse(Console.ReadLine());
		
		if(years>5){
            double bonus = salary*0.05;
            Console.WriteLine("Bonus amount is: " + bonus);
        }
        else
        {
            Console.WriteLine("No bonus applicable.");
        }
	}
}