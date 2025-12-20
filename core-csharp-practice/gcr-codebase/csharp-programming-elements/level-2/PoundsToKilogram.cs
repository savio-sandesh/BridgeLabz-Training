using System;

class PoundsToKilogram{
			static void Main(){
			
			// asking user to enter the weight
			Console.WriteLine("Enter weight in pounds: ");
			double pounds = double.Parse(Console.ReadLine());
			
			// converting weight into Kilograms
			double kilograms = pounds / 2.2;
			
			Console.WriteLine(
            "The weight of the person in pounds is " +
            pounds +
            " and in kg is " +
            kilograms
        );
    }
}
			