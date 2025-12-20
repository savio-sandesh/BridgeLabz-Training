using System;

class ProfitAndLoss{
		static void Main(){
		
		int costPrice = 129;
		int sellingPrice = 191;
		
		
		// Calculating profit
		int profit = sellingPrice-costPrice;
		
		// Calculating profit percentage
        	// 100.0 is used to force floating-point division
		double profitPercentage = ((double)profit*100.0)/costPrice;
		
		Console.WriteLine("The Cost Price is INR "+costPrice+" and Selling Price is INR "+sellingPrice);
		Console.WriteLine("The Profit is INR "+profit+" and the Profit Percentage is "+profitPercentage);
		
		}
	}
