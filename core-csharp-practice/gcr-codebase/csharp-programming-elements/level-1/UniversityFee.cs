using System;

class UniversityFee{
		static void Main(){
		
		// Original university fee amount
		int fee = 125000;
		
		// Discount percentage offered on the fee
		double discountPercent=10.0;
		
		
		// Calculating discount amount using percentage formula
        	// Formula: (fee * discountPercent) / 100
		double discount= (fee*discountPercent)/100;
		
		
		// Calculating final fee after applying discount
		double feeToPay = fee-discount;
		
		Console.WriteLine("The discount amount is INR "+ discount+" and final discounted fee is INR "+feeToPay);
		
		}
	}