using System;

class FindGreatestFactor{
		static void Main(){
		
		// asking user to enter the number
		Console.WriteLine("Enter the number: ");
		int number = int.Parse(Console.ReadLine());
		
		int greatestFactor=1;
		
		for(int s = number-1;s>=1;s--){
				if(number%s==0){
						greatestFactor=s;
						break;
				}
			}
			
		Console.WriteLine("The greatest factor beside itself is: "+greatestFactor);
		}
	}