using System;

class PenDistribution{
		static void Main(){
		
		// Total number of pens
		int pens =14;
		
		// Total number of students
		int students=3;
		
		// Modulus operator (%) gives the remaining pens after equal distribution
		int remainingPen=pens%students; //14%3
		
		// Division operator (/) gives number of pens per student
		int penPerStudent=pens/students;  //14/3
		
		
		Console.WriteLine("The Pen Per Student is "+penPerStudent+" and the reamining pen not distributed is "+ remainingPen);
		}
		}