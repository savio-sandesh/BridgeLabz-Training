using System;

class Sam {
	static void Main(){
		int Maths=94;
		int Physics=95;
		int Chemistry=96;
		
		int sum = Maths+Physics+Chemistry;
		
		double average=sum/3.0;
		
		// Total marks are 300 (3 subjects × 100)
        // Using 300.0 to ensure correct percentage calculation
		double percentage = (sum/300.0)*100;
		
		Console.WriteLine("Sam’s average mark in PCM is " + percentage + "%");
		}
	}
	 