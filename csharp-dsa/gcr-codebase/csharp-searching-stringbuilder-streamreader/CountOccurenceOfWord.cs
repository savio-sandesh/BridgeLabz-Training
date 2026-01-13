namespace BridgeLabzTraining.csharp_searching_stringbuilder_streamreader
{
	internal class CountOccurenceOfWord
	{
		private static void Main(string[] args)
		{
			Console.Write("Enter the file path: ");
			string filePath = Console.ReadLine().Trim('"');

			Console.Write("Enter the word to search: ");
			string searchWord = Console.ReadLine();

			int count = 0;

			try
			{
				using (StreamReader reader = new StreamReader(filePath))
				{
					string line;

					while ((line = reader.ReadLine()) != null)
					{
						string[] words = line.Split(' ', ',', '.', '!', '?', ';', ':');

						for (int i = 0; i < words.Length; i++)
						{
							if (words[i].Equals(searchWord, StringComparison.OrdinalIgnoreCase))
							{
								count++;
							}
						}
					}
				}

				Console.WriteLine($"\nThe word \"{searchWord}\" appears {count} times in the file.");
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine("Error: File not found.");
			}
			catch (IOException ex)
			{
				Console.WriteLine("I/O Error: " + ex.Message);
			}
		}
	}
}