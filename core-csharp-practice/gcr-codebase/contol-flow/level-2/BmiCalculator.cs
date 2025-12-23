using System;

class BmiCalculator{
		static void Main(){
		
		// asking user to enter the age
		Console.WriteLine("Enter weight in Kg: ");
        double weightInKg = double.Parse(Console.ReadLine());
		
		// asking user to enter the height
		Console.WriteLine("Enter height in Cm: ");
		double heightInCm = double.Parse(Console.ReadLine());
		
		double heightInM = heightInCm/100.0;
		
		// calculating bmi
		double bmi = weightInKg/(heightInM*heightInM);
		
		Console.WriteLine("Your BMI is: "+bmi);
		
		// categorizing bmi status
		if(bmi<=18.4){
				Console.WriteLine("Underweight");
		}
		else if(bmi>=18.5 && bmi<=24.9){
				Console.WriteLine("Normal");
		}
		else if(bmi>=25.0 && bmi<=29.9){
				Console.WriteLine("Overweight");
		}
		else{
				Console.WriteLine("Obese");
		}
	}
}