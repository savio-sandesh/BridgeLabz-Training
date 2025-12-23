using System;

class YoungerAndTallest{
		static void Main(){
		
		// asking user to enter the age of Amar
		Console.WriteLine("Enter the age of Amar: ");
		int amarAge = int.Parse(Console.ReadLine());
		
		// asking user to enter the age of Akbar
		Console.WriteLine("Enter the age of Akbar: ");
		int akbarAge = int.Parse(Console.ReadLine());
		
		// asking user to enter the age of Anthony
		Console.WriteLine("Enter the age of Anthony: ");
		int anthonyAge = int.Parse(Console.ReadLine());
		
		// asking user to enter the height of Amar
		Console.WriteLine("Enter the height of Amar: ");
		int amarHeight = int.Parse(Console.ReadLine());
		
		// asking user to enter the height of Akbar
		Console.WriteLine("Enter the height of Akbar: ");
		int akbarHeight = int.Parse(Console.ReadLine());
		
		// asking user to enter the height of Anthony
		Console.WriteLine("Enter the height of Anthony: ");
		int anthonyHeight = int.Parse(Console.ReadLine());
		
		// comparing their age to  find the younger among them 
		// <= and >= are used to handle cases where values can be equal and 
		// avoid missing conditions.

		if(amarAge<=akbarAge && amarAge<=anthonyAge){
				Console.WriteLine("Amar is younger among the three of them");
		}
		else if(akbarAge<=amarAge && akbarAge<=anthonyAge){
				Console.WriteLine("Akbar is younger among the three of them");
		}
		else{
				Console.WriteLine("Anthony is younger among the three of them");
		}
		
		// comparing their height to find tallest among them 
		if(amarHeight>=akbarHeight && amarHeight>=anthonyHeight){
				Console.WriteLine("Amar is tallest among the three of them");
		}
		else if(akbarHeight>=amarHeight && akbarHeight>=anthonyHeight){
				Console.WriteLine("Akbar is tallest among the three of them");
		}
		else{
				Console.WriteLine("Anthony is tallest among the three of them");
		}
	}
}