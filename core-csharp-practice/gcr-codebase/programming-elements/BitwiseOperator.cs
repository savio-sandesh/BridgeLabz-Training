// Bitwise Operators

using System;

class BitwiseOperator {
		static void Main(string[] args) {
		int a = 8; // 0101 in binary
		int b = 4; // 0011 in binary
		
		// AND (&): Performs a bitwise AND.
		Console.WriteLine("a & b: " + (a & b));  //0

		// OR (|): Performs a bitwise OR.
 		Console.WriteLine("a | b: " + (a | b));  //12
		
		// XOR (^): Performs a bitwise XOR.
		Console.WriteLine("a ^ b: " + (a ^ b));  //12
		
		// Complement (~): Inverts all bits.
		Console.WriteLine("~a: " + (~a));		 //-9
		
		// Left shift (<<): Shifts bits to the left.
		Console.WriteLine("a << 1: " + (a << 1));  //16
		
		// Right shift (>>): Shifts bits to the right.  
		Console.WriteLine("a >> 1: " + (a >> 1));   //4
}
}