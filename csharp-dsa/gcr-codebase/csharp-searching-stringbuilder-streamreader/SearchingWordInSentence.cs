namespace BridgeLabzTraining.csharp_searching_stringbuilder_streamreader
{
	internal class SearchingWordInSentence
	{
		private static void Main(string[] args)
		{
			Console.Write("Enter number of sentences: ");
			int n = Convert.ToInt32(Console.ReadLine());

			string[] sentences = new string[n];

			// Taking sentence input
			for (int i = 0; i < n; i++)
			{
				Console.Write($"Enter sentence {i + 1}: ");
				sentences[i] = Console.ReadLine();
			}

			Console.Write("\nEnter the word to search: ");
			string searchWord = Console.ReadLine();

			bool found = false;

			// Linear Search
			for (int i = 0; i < sentences.Length; i++)
			{
				if (sentences[i].Contains(searchWord, StringComparison.OrdinalIgnoreCase))
				{
					Console.WriteLine("\nFirst sentence containing the word:");
					Console.WriteLine(sentences[i]);
					found = true;
					break;
				}
			}

			if (!found)
			{
				Console.WriteLine("\nNo sentence contains the given word.");
			}
		}
	}
}