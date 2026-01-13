namespace BridgeLabzTraining.csharp_searching_stringbuilder_streamreader
{
	internal class ChallengeProblem
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

			// Part 1: Linear Search
			// First Missing Positive Integer
			bool[] present = new bool[n + 1];

			for (int i = 0; i < n; i++)
			{
				if (arr[i] > 0 && arr[i] <= n)
				{
					present[arr[i]] = true;
				}
			}

			int missing = 1;
			for (int i = 1; i <= n; i++)
			{
				if (!present[i])
				{
					missing = i;
					break;
				}
			}

			Console.WriteLine("\nFirst missing positive integer: " + missing);

			// Part 2: Binary Search
			Console.Write("\nEnter target element to search: ");
			int target = Convert.ToInt32(Console.ReadLine());

			// Bubble Sort
			for (int i = 0; i < n - 1; i++)
			{
				for (int j = 0; j < n - i - 1; j++)
				{
					if (arr[j] > arr[j + 1])
					{
						int temp = arr[j];
						arr[j] = arr[j + 1];
						arr[j + 1] = temp;
					}
				}
			}

			// Print sorted array
			Console.WriteLine("\nSorted array:");
			for (int i = 0; i < n; i++)
			{
				Console.Write(arr[i] + " ");
			}
			Console.WriteLine();

			int low = 0, high = n - 1;
			int index = -1;

			// Binary Search
			while (low <= high)
			{
				int mid = (low + high) / 2;

				if (arr[mid] == target)
				{
					index = mid;
					break;
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

			if (index != -1)
			{
				Console.WriteLine("Target found at index (after sorting): " + index);
			}
			else
			{
				Console.WriteLine("Target not found. Index: -1");
			}
		}
	}
}