using System;

class IntOperation{
		static void Main(){
		
		// Ask the user to enter the value of a
		Console.WriteLine("Enter the value of a: ");
		int a = int.Parse(Console.ReadLine());
		
		// Ask the user to enter the value of b
		Console.WriteLine("Enter the value of b: ");
		int b = int.Parse(Console.ReadLine());
		
		// Ask the user to enter the value of c
		Console.WriteLine("Enter the value of c: ");
		int c = int.Parse(Console.ReadLine());
		
		// Operation 1
		int op1 = a+b*c;
		
		// Operation 2
		int op2 = a*b+c;
		
		// Operation 3
		int op3 = c+a/b;
		
		// Operation 4
		int op4 = a%b+c;
		
		Console.WriteLine("The results of Int Operations are "+op1+
							", "+op2+", "+op3+", "+op4);
			}
	}