using System.Text;

namespace BridgeLabzTraining.csharp_searching_stringbuilder_streamreader
{
	internal class CompareStringbuilder
	{
		private static void Main(string[] args)
		{
			// Ask user for number of iterations
			Console.Write("Enter number of times to concatenate string: ");
			int iterations = Convert.ToInt32(Console.ReadLine());

			// ---------------- Using normal string ----------------
			string normalString = "";
			DateTime stringStartTime = DateTime.Now;

			for (int i = 0; i < iterations; i++)
			{
				normalString = normalString + "A";
			}

			DateTime stringEndTime = DateTime.Now;
			TimeSpan stringTimeTaken = stringEndTime - stringStartTime;

			// ---------------- Using StringBuilder ----------------
			StringBuilder sb = new StringBuilder();
			DateTime sbStartTime = DateTime.Now;

			for (int i = 0; i < iterations; i++)
			{
				sb.Append("A");
			}

			DateTime sbEndTime = DateTime.Now;
			TimeSpan sbTimeTaken = sbEndTime - sbStartTime;

			// ---------------- Display Result ----------------
			Console.WriteLine("\n--- Performance Comparison ---");
			Console.WriteLine("Time taken using String (+): " +
							  stringTimeTaken.TotalMilliseconds + " ms");

			Console.WriteLine("Time taken using StringBuilder: " +
							  sbTimeTaken.TotalMilliseconds + " ms");
		}
	}
}