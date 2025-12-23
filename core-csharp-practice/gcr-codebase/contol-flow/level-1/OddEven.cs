using System;

class OddEven{
	static void Main(){
	
		// Asking user to enter the number
		Console.WriteLine("Enter the number: ");
		int number=int.Parse(Console.ReadLine());
		
		if(number<=0){
			Console.WriteLine("Not a Natural Number");
			
		}
		
		else{
			for(int i=1;i<=number;i++){
			
				if(i%2==0){
					Console.WriteLine(i+" is Even");
					}
				else{
					Console.WriteLine(i+" is Odd");
					}
				}
			}
		}
	}