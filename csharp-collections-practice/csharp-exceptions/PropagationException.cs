// Create a C# program with three methods:
// Method1(): Throws an ArithmeticException (10 / 0).
// Method2(): Calls Method1().
// Main(): Calls Method2() and handles the exception.

using System;

class PropagationException
{
    static void Method1()
    {
        // Exception is intentionally thrown to demonstrate propagation
        int result = 10 / 0;
    }

    static void Method2()
    {
        // Exception is not handled here to allow propagation
        Method1();
    }

    static void Main()
    {
        try
        {
            Method2();
        }
        catch (ArithmeticException)
        {
            // Exception is handled at the top level
            Console.WriteLine("Handled exception in Main");
        }
    }
}
