// Assignment Operators

using System;
class AssignmentOperator{
		static void Main(string[] args) {
		
		// Assignment (=): Assigns the right operand to the left operand.
		int a = 20;
		int b = 25;
		
		
		// Addition assignment (+=): Adds the right operand to the left operand and assigns the
		// result to the left operand.
		a += b; // a = a + b
		Console.WriteLine("a += b: " + a); // 

		//Subtraction assignment (-=): Subtracts the right operand from the left operand and
		//assigns the result.
		a -= b; // a = a - b
		Console.WriteLine("a -= b: " + a); // 
		
		// Multiplication assignment (*=): Multiplies the right operand with the left operand
		//and assigns the result.
		a *= b; // a = a * b
		Console.WriteLine("a *= b: " + a); //
		
		// Division assignment (/=): Divides the left operand by the right operand and assigns
		// the result.
		a /= b; // a = a / b
		Console.WriteLine("a /= b: " + a); // 
		
		// Modulus assignment (%=): Takes the modulus using two operands and assigns the
		//result.
		a %= b; // a = a % b
		Console.WriteLine("a %= b: " + a); //
}
}