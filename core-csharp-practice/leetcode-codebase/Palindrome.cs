using System;
class Palindrome {
    static void Main() {
		int x=1331; // Number to check
		
        int org=x;  //Store original number

        int rev=0;  // Variable to store reversed number
		
		// Reverse the number
        while(x>0)
        {
		// Check if original number is equal to reversed number
        int rem=x%10;
        rev=rev*10+rem;
        x=x/10;
        }
        if(org==rev){
            Console.WriteLine("Palindrome number");
        }
        else{
            Console.WriteLine("Not a palindrome number");
        }

    }
}