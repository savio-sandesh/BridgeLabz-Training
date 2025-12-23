using System;

class DivisibilityCheck{
		static void Main(){
		
		// asking user to enter the number 
		Console.WriteLine("Enter the number: ");
		int number= int.Parse(Console.ReadLine());
		
		// check if the number is divisible my 5 or Not
		if(number%5==0){
		
			Console.WriteLine("Is the number "+number+ " divisible by 5? " + "Yes");
			
		}
		else{
			
			Console.WriteLine("Is the number "+number+ " divisible by 5? " + "No");
		
		}
		
}

}