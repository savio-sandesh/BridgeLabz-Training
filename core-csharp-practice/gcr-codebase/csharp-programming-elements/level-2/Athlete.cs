using System;

class Athlete{
		static void Main(){
		
		// Asking user for side1
		Console.WriteLine("Enter side 1 of the park (meters): ");
        double side1 = double.Parse(Console.ReadLine());
		
		// Asking user for side2
        Console.WriteLine("Enter side 1 of the park (meters): ");
        double side2 = double.Parse(Console.ReadLine());

		// // Asking user for side3
        Console.WriteLine("Enter side 1 of the park (meters): ");
        double side3 = double.Parse(Console.ReadLine());

        double perimeter = side1 + side2 + side3;
		
		// 1 km -- 1000m
        double totalDistance = 5000; 
		
		// Calculating total number of rounds
        double rounds = totalDistance / perimeter;

        Console.WriteLine(
            "The total number of rounds the athlete will run is " +
            rounds + " to complete 5 km"
        );
    }
}
		