using System;

class PerimeterOfRectangle{
		static void Main(){
		
		// length of the rectangle
		double length=10.25;
		
		// breadth of the rectangle
		double breadth=12.56;
		
		// Calculate perimeter of rectangle using formula:
        // Perimeter = 2 × (length + breadth)
		double perimeter=2*(length+breadth);
		
		Console.WriteLine(perimeter);
		
		}
}