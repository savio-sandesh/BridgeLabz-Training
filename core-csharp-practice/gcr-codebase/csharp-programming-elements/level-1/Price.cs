using System;

class Price{
		static void Main(){
		
		// asking user to input the unit price
		Console.WriteLine("Enter the Unit Price of the item: ");
		
		// reading input from user 
		double unitPrice=double.Parse(Console.ReadLine());
		
		// asking user to input the quantity to be bought
		Console.WriteLine("Enter the quantity to be bought: ");
		
		// reading input from user 
		double quantity=double.Parse(Console.ReadLine());
		
		// calculation of total price
		double totalPrice=unitPrice*quantity;
		
		
		Console.WriteLine("The total purchase price is INR "+totalPrice+" if the quantity is "+quantity+" and unit price is INR "+unitPrice);
}
}		
		