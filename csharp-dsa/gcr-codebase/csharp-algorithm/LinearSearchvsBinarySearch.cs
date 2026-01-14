using System.Diagnostics;

public class SearchComparisonClean
{
	private static Random rand = new Random();

	public static void Main()
	{
		Console.Write("Enter dataset size (N): ");
		int n = int.Parse(Console.ReadLine());

		int[] data = GenerateData(n);

		// Target is GUARANTEED to exist
		int target = data[rand.Next(0, data.Length)];

		Stopwatch sw = new Stopwatch();

		// -------- Linear Search --------
		sw.Start();
		LinearSearch(data, target);
		sw.Stop();
		double linearTime = sw.Elapsed.TotalMilliseconds;

		// -------- Binary Search --------
		sw.Restart();
		Array.Sort(data); // O(N log N)
		sw.Stop();
		double sortTime = sw.Elapsed.TotalMilliseconds;

		sw.Restart();
		BinarySearch(data, target); // O(log N)
		sw.Stop();
		double binarySearchTime = sw.Elapsed.TotalMilliseconds;

		// -------- Output --------
		Console.WriteLine("\n--- Performance Comparison ---");
		Console.WriteLine($"Linear Search Time  : {linearTime} ms  (O(N))");
		Console.WriteLine($"Binary Search Time : {binarySearchTime} ms  (O(log N))");
		Console.WriteLine($"Sorting Time       : {sortTime} ms  (O(N log N))");
		Console.WriteLine($"Total Binary Search Time  : {sortTime + binarySearchTime} ms");
	}

	private static int[] GenerateData(int size)
	{
		int[] arr = new int[size];
		for (int i = 0; i < size; i++)
		{
			arr[i] = rand.Next(1, size * 5);
		}
		return arr;
	}

	private static void LinearSearch(int[] arr, int target)
	{
		for (int i = 0; i < arr.Length; i++)
		{
			if (arr[i] == target)
				return;
		}
	}

	private static void BinarySearch(int[] arr, int target)
	{
		int left = 0, right = arr.Length - 1;

		while (left <= right)
		{
			int mid = left + (right - left) / 2;

			if (arr[mid] == target)
				return;

			if (arr[mid] < target)
				left = mid + 1;
			else
				right = mid - 1;
		}
	}
}