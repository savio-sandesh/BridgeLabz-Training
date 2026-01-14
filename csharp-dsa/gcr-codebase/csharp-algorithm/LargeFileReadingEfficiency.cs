namespace BridgeLabzTraining.csharp_algorithm
{
	internal class LargeFileReadingEfficiency
	{
		/*
         * This program compares the performance of reading a large file
         * using StreamReader and FileStream. Execution time is measured
         * to evaluate their efficiency for large file processing.
         */

		private static void Main()
		{
			Console.Write("Enter full file path to read: ");
			string filePath = Console.ReadLine();

			// -------- StreamReader Reading --------
			DateTime startStreamReader = DateTime.Now;
			ReadUsingStreamReader(filePath);
			DateTime endStreamReader = DateTime.Now;
			double streamReaderTime =
				(endStreamReader - startStreamReader).TotalMilliseconds;

			// -------- FileStream Reading --------
			DateTime startFileStream = DateTime.Now;
			ReadUsingFileStream(filePath);
			DateTime endFileStream = DateTime.Now;
			double fileStreamTime =
				(endFileStream - startFileStream).TotalMilliseconds;

			// Output results
			Console.WriteLine("\n--- Large File Reading Performance ---");
			Console.WriteLine($"StreamReader Time : {streamReaderTime} ms");
			Console.WriteLine($"FileStream Time   : {fileStreamTime} ms");

			// Expected result
			Console.WriteLine("\nExpected Result:");
			Console.WriteLine(
				"FileStream is more efficient for reading large files, while StreamReader is suitable for text-based data."
			);
		}

		// Reads file using StreamReader (text-based reading)
		private static void ReadUsingStreamReader(string path)
		{
			using (StreamReader reader = new StreamReader(path))
			{
				while (reader.ReadLine() != null)
				{
					// Reading file line by line
				}
			}
		}

		// Reads file using FileStream (byte-based reading)
		private static void ReadUsingFileStream(string path)
		{
			using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				byte[] buffer = new byte[4096];
				while (fs.Read(buffer, 0, buffer.Length) > 0)
				{
					// Reading bytes into buffer
				}
			}
		}
	}
}