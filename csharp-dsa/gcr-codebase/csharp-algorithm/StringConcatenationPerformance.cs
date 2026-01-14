using System.Text;

namespace BridgeLabzTraining.csharp_algorithm
{
	internal class StringConcatenationPerformance
	{
		/*
         * This program compares the performance of string concatenation
         * using immutable string objects and mutable StringBuilder.
         * Execution time is measured and related to time complexity.
         */

		private static void Main()
		{
			Console.Write("Enter number of concatenations (N): ");
			int n = int.Parse(Console.ReadLine());

			// -------- String Concatenation --------
			DateTime startString = DateTime.Now;
			ConcatenateUsingString(n);
			DateTime endString = DateTime.Now;
			double stringTime = (endString - startString).TotalMilliseconds;

			// -------- StringBuilder Concatenation --------
			DateTime startBuilder = DateTime.Now;
			ConcatenateUsingStringBuilder(n);
			DateTime endBuilder = DateTime.Now;
			double builderTime = (endBuilder - startBuilder).TotalMilliseconds;

			// Output results
			Console.WriteLine("\n--- String Concatenation Performance ---");
			Console.WriteLine($"String Time        : {stringTime} ms   (O(N^2))");
			Console.WriteLine($"StringBuilder Time : {builderTime} ms   (O(N))");

			// Expected result
			Console.WriteLine("\nExpected Result:");
			Console.WriteLine("StringBuilder is much more efficient than string for concatenation.");
		}

		// Concatenation using immutable string
		private static void ConcatenateUsingString(int n)
		{
			string result = "";
			for (int i = 0; i < n; i++)
			{
				result += "a";
			}
		}

		// Concatenation using mutable StringBuilder
		private static void ConcatenateUsingStringBuilder(int n)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < n; i++)
			{
				sb.Append("a");
			}
		}
	}
}