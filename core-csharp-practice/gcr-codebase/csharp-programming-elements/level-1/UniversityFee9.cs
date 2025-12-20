using System;

class UniversityFee9{
		static void Main(){
		
		// Ask the user to enter Original university fee amount
		Console.WriteLine("Enter the Fee Amount: ");
		
		// Read input from keyboard and convert it to double
		double fee = double.Parse(Console.ReadLine());

		
		// Ask the user to enter discount percentage
		Console.WriteLine("Enter the Discount Percentage: ");
		
		// Read input from keyboard and convert it to double
		double discountPercent = double.Parse(Console.ReadLine());

		
		
		// Calculating discount amount using percentage formula
        // Formula: (fee * discountPercent) / 100
		double discount= (fee*discountPercent)/100;
		
		
		// Calculating final fee after applying discount
		double feeToPay = fee-discount;
		
		Console.WriteLine("The discount amount is INR "+ discount+" and final discounted fee is INR "+feeToPay);
		
		}
	}