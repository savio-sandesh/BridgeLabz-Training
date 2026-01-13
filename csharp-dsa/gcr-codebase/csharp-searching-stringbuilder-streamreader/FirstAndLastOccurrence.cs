namespace BridgeLabzTraining.csharp_searching_stringbuilder_streamreader
{
	internal class FirstAndLastOccurrence
	{
		private static void Main(string[] args)
		{
			Console.Write("Enter number of elements: ");
			int n = Convert.ToInt32(Console.ReadLine());

			int[] arr = new int[n];

			// Taking sorted array input
			Console.WriteLine("Enter sorted array elements:");
			for (int i = 0; i < n; i++)
			{
				Console.Write($"Element {i + 1}: ");
				arr[i] = Convert.ToInt32(Console.ReadLine());
			}

			Console.Write("\nEnter target element: ");
			int target = Convert.ToInt32(Console.ReadLine());

			int first = -1;
			int last = -1;

			int low = 0, high = n - 1;

			// Find first occurrence
			while (low <= high)
			{
				int mid = (low + high) / 2;

				if (arr[mid] == target)
				{
					first = mid;
					high = mid - 1;
				}
				else if (arr[mid] < target)
				{
					low = mid + 1;
				}
				else
				{
					high = mid - 1;
				}
			}

			low = 0;
			high = n - 1;

			// Find last occurrence
			while (low <= high)
			{
				int mid = (low + high) / 2;

				if (arr[mid] == target)
				{
					last = mid;
					low = mid + 1;
				}
				else if (arr[mid] < target)
				{
					low = mid + 1;
				}
				else
				{
					high = mid - 1;
				}
			}

			if (first != -1)
			{
				Console.WriteLine($"\nFirst occurrence at index: {first}");
				Console.WriteLine($"Last occurrence at index: {last}");
			}
			else
			{
				Console.WriteLine("\nTarget element not found in the array.");
			}
		}
	}
}