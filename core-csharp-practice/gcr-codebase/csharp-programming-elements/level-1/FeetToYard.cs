using System;

class FeetToYard{
		static void Main(){
		
		
		// asking user to enter the distance
		Console.WriteLine("Enter the Distance in Feet: ");
		
		double distanceInFeet = double.Parse(Console.ReadLine());
		
		
		// converting feet into yards
		//  1 yard is 3 feet
		double distanceInYards =distanceInFeet/3.0;
		
		// coverting yard into miles
		// 1 mile = 1760 yards
		double distanceInMiles=distanceInYards/1760.0;
		
		Console.WriteLine(
            "Distance in yards is " + distanceInYards +
            " and distance in miles is " + distanceInMiles
        );
		
		}
}