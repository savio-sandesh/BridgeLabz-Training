using System.Text;

namespace BridgeLabzTraining.csharp_searching_stringbuilder_streamreader
{
	internal class ConvertByteToCharacter
	{
		private static void Main(string[] args)
		{
			Console.Write("Enter the file path: ");
			string filePath = Console.ReadLine().Trim('"');

			// StreamReader with Encoding to convert byte stream to character stream
			using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
			{
				Console.WriteLine("\n--- File Content (Character Stream) ---");

				int character;
				while ((character = reader.Read()) != -1)
				{
					Console.Write((char)character);
				}
			}
		}
	}
}