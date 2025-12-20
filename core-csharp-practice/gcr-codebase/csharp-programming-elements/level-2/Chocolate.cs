using System;

class Chocolate{
		static void Main(){
		
		// asking user to enter the number of chocolates
		Console.WriteLine("Enter the number of chocolates: ");
        int numberOfChocolates = int.Parse(Console.ReadLine());
		
		// asking user to enter the number of children
		Console.WriteLine("Enter the number of children: ");
        int numberOfChildren = int.Parse(Console.ReadLine());
		
		// calculating number of chocolates per children
		int chocolatesPerChild = numberOfChocolates / numberOfChildren;
		
		
		// calculating remaining chocolates 
		int remainingChocolates = numberOfChocolates % numberOfChildren;
		
		Console.WriteLine(
            "The number of chocolates each child gets is " +
            chocolatesPerChild +
            " and the number of remaining chocolates is " +
            remainingChocolates
        );
    }
}