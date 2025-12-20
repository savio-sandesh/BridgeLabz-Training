using System;

class VolumeOfEarth{
		static void Main(){
		
		// Radius of Earth in kilometers
		int radius=6378;
		
		// Converting radius from kilometers to miles
        // 1 km = 0.621371 miles
		double newRadius=radius*0.6213712;
		
		
		// Calculating volume in cubic kilometers
        // Formula: (4/3) * PI * r^3
        // 4.0/3.0 is used to avoid integer division
		double volume = (4.0/3.0)*Math.PI*radius*radius*radius;
		
		
		// Calculating volume in cubic miles
		double newVolume = (4.0/3.0)*Math.PI*newRadius*newRadius*newRadius;
		
		Console.WriteLine("The volume of earth in cubic kilometers is "+volume+" and cubic miles is "+newVolume);
		}
}