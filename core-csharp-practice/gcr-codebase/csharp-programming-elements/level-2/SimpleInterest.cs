using System;

class SimpleInterest{
		static void Main(){
		
		// asking user to enter the principal amount
		Console.WriteLine("Enter Principal amount: ");
        double p = double.Parse(Console.ReadLine());
		
		// asking user to enter the interest rate
		Console.WriteLine("Enter Rate of Interest: ");
        double r = double.Parse(Console.ReadLine());
		
		// asking user for the time period
		Console.WriteLine("Enter Time (Years): ");
        double t = double.Parse(Console.ReadLine());
		
		// calculating simple interest with the help of given formula 
		// (Principal * Rate * Time) / 100
		double simpleInterest = (p*r*t)/100.0;
		
		Console.WriteLine(
            "The Simple Interest is " + simpleInterest +
            " for Principal " + p +
            ", Rate of Interest " + r +
            " and Time " + t
        );
    }
}
		