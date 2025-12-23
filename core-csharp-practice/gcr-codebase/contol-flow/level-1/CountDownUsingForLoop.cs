using System;

class CountDownUsingForLoop{
		
		static void Main(){
		
		// Asking user to enter the number
		Console.WriteLine("Enter the number: ");
		int counter=int.Parse(Console.ReadLine());
		
		for(int i=counter;i>=1;i--){
			Console.WriteLine(i);
		}
	}
}