using System;

class HandShakes{
		static void Main(){
		
		// asking user to enter number of students
		Console.WriteLine("Enter the Number of students: ");
		
		// read input from the user
		int n = int.Parse(Console.ReadLine());
		
		// calculating maximum number of handshake using given formula
		// combination = (n * (n - 1)) / 2
		
		int handshakes=(n*(n-1))/2;
		
		Console.WriteLine("The number of possible handshakes: "+handshakes);
		}
	}	
		