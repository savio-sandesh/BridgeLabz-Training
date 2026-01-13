//namespace BridgeLabzTraining.csharp_searching_stringbuilder_streamreader
//{
//	internal class ReadAFileLineWise
//	{
//		private static void Main(string[] args)
//		{
//			Console.Write("Enter the file path: ");
//			string filePath = Console.ReadLine();

//			try
//			{
//				using (StreamReader reader = new StreamReader(filePath))
//				{
//					string line;
//					Console.WriteLine("\n--- File Content ---");

//					while ((line = reader.ReadLine()) != null)
//					{
//						Console.WriteLine(line);
//					}
//				}
//			}
//			catch (FileNotFoundException)
//			{
//				Console.WriteLine("Error: File not found.");
//			}
//			catch (IOException ex)
//			{
//				Console.WriteLine("I/O Error: " + ex.Message);
//			}
//		}
//	}
//}