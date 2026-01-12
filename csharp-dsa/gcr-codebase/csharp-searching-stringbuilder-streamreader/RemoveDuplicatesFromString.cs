using System.Text;

namespace BridgeLabzTraining.csharp_searching
{
	//Read input string
	//Create empty StringBuilder
	//For each character in string
	//	If character not present in StringBuilder
	//		Append character
	//Print StringBuilder

	internal class RemoveDuplicateCharacters
	{
		private static void Main(string[] args)
		{
			Console.Write("Enter a string: ");
			string input = Console.ReadLine();

			StringBuilder result = new StringBuilder();

			for (int i = 0; i < input.Length; i++)
			{
				char currentChar = input[i];

				// Check if character already exists in StringBuilder
				if (result.ToString().IndexOf(currentChar) == -1)
				{
					result.Append(currentChar);
				}
			}

			Console.WriteLine("String after removing duplicates: " + result.ToString());
		}
	}
}