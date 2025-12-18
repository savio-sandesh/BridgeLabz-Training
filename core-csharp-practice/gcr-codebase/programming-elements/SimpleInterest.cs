using System;

class SimpleInterest{
		static void Main(string[] args)
{
		// Principal amount
		float p=2700f;
		
		// Rate of interest per year
		float r=2.5f;
		
		// Time period in years
		float t=2f;
		
		// Calculate Simple Interest using formula:
        // Simple Interest = (Principal * Rate * Time) / 100
		float si=p*r*t/100;
		
		Console.WriteLine(si);
		}
	}