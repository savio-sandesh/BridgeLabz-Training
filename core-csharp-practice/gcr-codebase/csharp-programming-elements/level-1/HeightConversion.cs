using System;

class HeightConversion{
	static void Main(){
	
	// ask user to enter their Height
	Console.WriteLine("Enter Your Height: ");
	double heightInCm=double.Parse(Console.ReadLine());
	
	
	// Convert centimeters to inches
    // Since 1 inch = 2.54cm
    double inches = heightInCm/2.54;
	
	
	// Calculate feet from inches
    int feet = (int)(inches/12);
	
	// Calculate remaining inches
    double Reminches = inches % 12;
	
	 Console.WriteLine(
            "Your Height in cm is " + heightInCm +
            " while in feet is " + feet +
            " and inches is " + Reminches
        );
    }
}
