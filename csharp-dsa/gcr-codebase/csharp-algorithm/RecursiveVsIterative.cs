using System.Diagnostics;

namespace BridgeLabzTraining.csharp_algorithm
{
	internal class RecursiveVsIterative
	{
		/*
         * This program compares recursive and iterative approaches
         * for computing Fibonacci numbers. Execution time is measured
         * to analyze performance and scalability differences.
         */

		private static void Main()
		{
			Console.Write("Enter Fibonacci number (N): ");
			int n = int.Parse(Console.ReadLine());

			Stopwatch sw = new Stopwatch();

			// -------- Recursive Fibonacci --------
			sw.Start();
			int recursiveResult = FibonacciRecursive(n);
			sw.Stop();
			double recursiveTime = sw.Elapsed.TotalMilliseconds;

			// -------- Iterative Fibonacci --------
			sw.Restart();
			int iterativeResult = FibonacciIterative(n);
			sw.Stop();
			double iterativeTime = sw.Elapsed.TotalMilliseconds;

			// Output results
			Console.WriteLine("\n--- Fibonacci Performance Comparison ---");
			Console.WriteLine($"Recursive Result : {recursiveResult}");
			Console.WriteLine($"Recursive Time   : {recursiveTime} ms   (O(2^N))");
			Console.WriteLine($"Iterative Result : {iterativeResult}");
			Console.WriteLine($"Iterative Time   : {iterativeTime} ms   (O(N))");

			// Expected result
			Console.WriteLine("\nExpected Result:");
			Console.WriteLine(
				"Recursive approach is infeasible for large values of N due to exponential growth. " +
				"The iterative approach is significantly faster and memory-efficient."
			);
		}

		// Recursive Fibonacci implementation
		private static int FibonacciRecursive(int n)
		{
			if (n <= 1)
				return n;

			return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
		}

		// Iterative Fibonacci implementation
		private static int FibonacciIterative(int n)
		{
			if (n <= 1)
				return n;

			int a = 0, b = 1, sum = 0;

			for (int i = 2; i <= n; i++)
			{
				sum = a + b;
				a = b;
				b = sum;
			}

			return b;
		}
	}
}