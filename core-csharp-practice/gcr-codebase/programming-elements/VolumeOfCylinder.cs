using System;

class VolumeOfCylinder{
	 static void Main()
	 {
		// Radius of the cylinder
	    double r=2.5;
		
		// Height of the cylinder
		double h=7;
		
		// Calculate volume of the cylinder using formula:
        // Volume = π × r × r × h
		double volume=Math.PI*r*r*h;
		Console.WriteLine(volume);
	 }
}