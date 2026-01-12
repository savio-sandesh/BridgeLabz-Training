using System.Text;

namespace BridgeLabzTraining.csharp_searching_stringbuilder_streamreader
{
	//Create an array of strings.
	//Create a StringBuilder object.
	//Traverse the array using a loop.
	//Append each string to the StringBuilder.
	//Convert the result to a string and display it.
	internal class ConcatenateStrings
	{
		private static void Main(string[] args)
		{
			Console.Write("Enter number of strings: ");
			int n = Convert.ToInt32(Console.ReadLine());

			string[] words = new string[n];

			// Taking user input
			for (int i = 0; i < n; i++)
			{
				Console.Write($"Enter string {i + 1}: ");
				words[i] = Console.ReadLine();
			}

			// StringBuilder for efficient concatenation
			StringBuilder result = new StringBuilder();

			// Concatenate all strings
			for (int i = 0; i < words.Length; i++)
			{
				result.Append(words[i]);
			}

			Console.WriteLine("\nConcatenated String:");
			Console.WriteLine(result.ToString());
		}
	}
}