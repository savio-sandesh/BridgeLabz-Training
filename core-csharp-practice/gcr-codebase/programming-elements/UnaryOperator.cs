// Unary Operators 
// Unary plus (+): Indicates a positive value.
// Unary minus (-): Negates the value.

// Increment (++): Increases the value by 1.
// Decrement (--): Decreases the value by 1.
// Logical complement (!): Inverts the value of a boolean.
using System;

class UnaryOperators {
		static void Main() {
		int a = 5;

		Console.WriteLine("a: " + a); // 5
		Console.WriteLine("++a: " + ++a); // 6 (pre-increment)
		Console.WriteLine("a++: " + a++); // 6 (post-increment)
		Console.WriteLine("a: " + a); // 7
		Console.WriteLine("--a: " + --a); // 6 (pre-decrement)
		Console.WriteLine("a--: " + a--); // 6 (post-decrement)
		Console.WriteLine("a: " + a); // 5
}
}