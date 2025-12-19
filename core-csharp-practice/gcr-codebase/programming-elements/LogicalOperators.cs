// Logical Operators 

// Logical AND (&&): Returns true if both operands are true.
// Logical OR (||): Returns true if at least one operand is true.
// Logical NOT (!): Reverses the logical state of its operand.

using System;

	class LogicalOperators {
		static void Main(string[] args) {
			bool a = true;
			bool b = false;
				
				
			//Logical AND (&&)
			Console.WriteLine("a && b: " + (a && b)); // false
			
			//Logical OR (||)
			Console.WriteLine("a || b: " + (a || b)); // true
			
			//Logical NOT (!)
			Console.WriteLine("!a: " + (!a)); // false
			
			//Logical NOT (!)
			Console.WriteLine("!b: " + (!b)); // true
}
}