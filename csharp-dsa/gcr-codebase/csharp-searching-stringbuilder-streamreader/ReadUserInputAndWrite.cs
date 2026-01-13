namespace BridgeLabzTraining.csharp_searching_stringbuilder_streamreader
{
	internal class ReadUserInputAndWrite
	{
		private static void Main(string[] args)
		{
			Console.Write("Enter the file path where data should be written: ");
			string filePath = Console.ReadLine().Trim('"');

			Console.Write("Enter text to write into the file: ");
			string userInput = Console.ReadLine();

			using (StreamWriter writer = new StreamWriter(filePath))
			{
				writer.WriteLine(userInput);
			}

			Console.WriteLine("\nData written to file successfully.");
		}
	}
}