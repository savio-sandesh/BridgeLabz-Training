namespace BridgeLabzTraining.csharp_searching_stringbuilder_streamreader
{
	internal class FirstNegativeNumber
	{
		private static void Main(string[] args)
		{
			Console.Write("Enter number of elements: ");
			int n = Convert.ToInt32(Console.ReadLine());

			int[] arr = new int[n];

			// Taking array input
			for (int i = 0; i < n; i++)
			{
				Console.Write($"Enter element {i + 1}: ");
				arr[i] = Convert.ToInt32(Console.ReadLine());
			}

			bool found = false;

			// Linear Search for first negative number
			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i] < 0)
				{
					Console.WriteLine("\nFirst negative number is: " + arr[i]);
					found = true;
					break;
				}
			}

			if (!found)
			{
				Console.WriteLine("\nNo negative number found in the array.");
			}
		}
	}
}