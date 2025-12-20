using System;

class DoubleOperation{
		static void Main(){
		
		// Ask the user to enter the value of a
		Console.WriteLine("Enter the value of a: ");
		double a =	double.Parse(Console.ReadLine());
		
		// Ask the user to enter the value of b
		Console.WriteLine("Enter the value of b: ");
		double b = double.Parse(Console.ReadLine());
		
		// Ask the user to enter the value of c
		Console.WriteLine("Enter the value of c: ");
		double c = double.Parse(Console.ReadLine());
		
		// Operation 1
		double op1 = a+b*c;
		
		// Operation 2
		double op2 = a*b+c;
		
		// Operation 3
		double op3 = c+a/b;
		
		// Operation 4
		double op4 = a%b+c;
		
		Console.WriteLine("The results of Int Operations are "+op1+
							", "+op2+", "+op3+", "+op4);
			}
	}