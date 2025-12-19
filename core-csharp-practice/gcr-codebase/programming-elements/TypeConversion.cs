// Type Conversion
// changing data from one type to another.

using System;
class TypeConversion{
     static void Main(){
	 
	 // Implicit conversion (safe, automatic)
	 int a = 10;
     double b = a;   // int → double


     // Explicit conversion (manual, risky)
	 double x = 10.8;
     int y = (int)x;   // explicit casting

	 // Convert class
	 int p= Convert.ToInt32(10.8);   // result: 11 (rounds)
     double q = Convert.ToDouble("12.5");
     string r = Convert.ToString(100);
	 
	 }
	}
