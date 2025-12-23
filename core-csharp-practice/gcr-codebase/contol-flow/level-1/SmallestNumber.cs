using System;

class SmallestNumber{
	static void Main(){
		
		// Asking user to enter the number1
		Console.WriteLine("Enter the number1: ");
		int number1=int.Parse(Console.ReadLine());
		
		// Asking user to enter the number2
		Console.WriteLine("Enter the number2: ");
		int number2=int.Parse(Console.ReadLine());
		
		// Asking user to enter the number3
		Console.WriteLine("Enter the number3: ");
		int number3=int.Parse(Console.ReadLine());
		
		if(number1<number2 && number1<number3){
		
				Console.WriteLine("Is the first number the smallest? "+"Yes");
		}
		
		else{
				Console.WriteLine("Is the first number the smallest? "+"No");
		
		}
		
}
}