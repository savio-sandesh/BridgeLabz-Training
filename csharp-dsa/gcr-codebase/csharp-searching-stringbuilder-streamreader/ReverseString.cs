using System.Text;

namespace BridgeLabzTraining.csharp_searching
{
	internal class ReverseString
	{
		private static void Main(string[] args)
		{
			Console.Write("Enter a string: ");
			string input = Console.ReadLine();

			// StringBuilder with predefined capacity (best practice)
			StringBuilder reversed = new StringBuilder(input.Length);

			// Reverse logic
			for (int i = input.Length - 1; i >= 0; i--)
			{
				reversed.Append(input[i]);
			}

			Console.WriteLine("Reversed String: " + reversed.ToString());
		}
	}
}