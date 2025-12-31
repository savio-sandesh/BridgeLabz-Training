//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BridgeLabzTraining.scenario_based
//{
//    internal class MathematicalOperations
//    {

//        // A method to check if a number is prime.
//        internal static bool PrimeCheck(int number)
//        {
//            if (number <= 1)
//                return false;

//            for (int k = 2; k < number; k++)
//            {
//                if (number % k == 0)
//                    return false;
//            }
//            return true;
//        }

//        // A method to calculate the Greatest Common Divisor (GCD) of two numbers.
//        internal static int GCD(int a, int b)
//        {
//            a=Math.Abs(a);
//            b=Math.Abs(b);

//            if(a==0 && b==0)
//                return 0;

//            while (b!=0)
//            {
//                int remainder = a % b;
//                a = b;
//                b = remainder;
//            }
//            return a;
//        }

//        // A method to calculate the factorial of a number.
//        internal static long Factorial(int number)
//        {
//            // factorial is not defined for negative numbers
//            if (number < 0)
//            {
//                return -1;
//            }

//            long factorial = 1;

//            for (int k = 2; k <= number; k++)
//            {
//                factorial *= k;
//            }

//            return factorial;

//        }

//        //  A method to find the nth Fibonacci number.
//        internal static int Fibonacci(int n)
//        {
//            // Fibonacci not defined for negative numbers
//            if (n < 0) { return -1; }

//            if(n == 0) { return 0; }

//            if(n == 1) { return 1; }

//            int first = 0;
//            int second = 1;
//            int fibonacci = 0;

//            for(int g = 2; g <= n; g++)
//            {
//                fibonacci = first + second;
//                first = second;
//                second = fibonacci;
//            }
//            return fibonacci;
//        }

            
//        static void Main(string[] args)
//        {
//            // Testing methods with various inputs,
//            // including edge cases like zero, one, and negative numbers.
//            Console.WriteLine("Prime Check:");
//            Console.WriteLine($"Is 11 prime? {PrimeCheck(11)}"); 
//            Console.WriteLine($"Is 15 prime? {PrimeCheck(15)}");
//            Console.WriteLine($"Is -3 prime? {PrimeCheck(-3)}");

//            Console.WriteLine("\nGCD Calculation:");
//            Console.WriteLine($"GCD of 48 and 18: {GCD(48, 18)}");
//            Console.WriteLine($"GCD of -48 and 18: {GCD(-48, 18)}");
//            Console.WriteLine($"GCD of 0 and 0: {GCD(0, 0)}");
            
//            Console.WriteLine("\nFactorial Calculation:");
//            Console.WriteLine($"Factorial of 5: {Factorial(5)}");
//            Console.WriteLine($"Factorial of 0: {Factorial(0)}");
//            Console.WriteLine($"Factorial of -4: {Factorial(-4)}");

//            Console.WriteLine("\nFibonacci Calculation:");
//            Console.WriteLine($"Fibonacci of 7: {Fibonacci(7)}");
//            Console.WriteLine($"Fibonacci of 0: {Fibonacci(0)}");
//            Console.WriteLine($"Fibonacci of -5: {Fibonacci(-5)}");

//        }
//    }
//}
