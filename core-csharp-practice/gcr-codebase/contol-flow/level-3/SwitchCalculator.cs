using System;

class SwitchCalculator{
		static void Main(){
		
		// asking user to enter the first number
		Console.WriteLine("Enter the first number: ");
		double firstNum= double.Parse(Console.ReadLine());
		
		// asking user to enter the second number
		Console.WriteLine("Enter the second number: ");
		double secondNum= double.Parse(Console.ReadLine());
		
		// asking for the operator 
		Console.WriteLine("Enter the operator(+, -, *, /): ");
		string operation=Console.ReadLine();
		
		switch(operation)
		{
			case"+":
				Console.WriteLine(firstNum+secondNum);
				break;
				
			case"-":
				Console.WriteLine(firstNum-secondNum);
				break;
				
			case"*":
				Console.WriteLine(firstNum*secondNum);
				break;
				
			case"/":
				if(secondNum!=0){
					Console.WriteLine(firstNum/secondNum);		
				}
				else{
					Console.WriteLine("divisionn by zero not possible");
					}
					break;
			default:
				Console.WriteLine("Invalid Operation");
				break;
			}
		}
}