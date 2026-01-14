using System.Diagnostics;

namespace BridgeLabzTraining.csharp_algorithm
{
	internal class SortingAlgorithmComparison
	{
		/*
         * This program compares the performance of Bubble Sort, Merge Sort,
         * and Quick Sort on large datasets.
         */

		// Single Random instance for dataset generation
		private static Random rand = new Random();

		private static void Main()
		{
			// Read dataset size from user
			Console.Write("Enter dataset size (N): ");
			int n = int.Parse(Console.ReadLine());

			// Generate original unsorted dataset
			int[] originalData = GenerateData(n);

			Stopwatch sw = new Stopwatch();

			// ---------- Bubble Sort (O(N^2)) ----------
			int[] bubbleData = (int[])originalData.Clone();
			sw.Start();
			BubbleSort(bubbleData);
			sw.Stop();
			double bubbleTime = sw.Elapsed.TotalMilliseconds;

			// ---------- Merge Sort (O(N log N)) ----------
			int[] mergeData = (int[])originalData.Clone();
			sw.Restart();
			MergeSort(mergeData, 0, mergeData.Length - 1);
			sw.Stop();
			double mergeTime = sw.Elapsed.TotalMilliseconds;

			// ---------- Quick Sort (O(N log N) average) ----------
			int[] quickData = (int[])originalData.Clone();
			sw.Restart();
			QuickSort(quickData, 0, quickData.Length - 1);
			sw.Stop();
			double quickTime = sw.Elapsed.TotalMilliseconds;

			// Display results
			Console.WriteLine("\n--- Sorting Performance Comparison ---");
			Console.WriteLine($"Bubble Sort Time : {bubbleTime} ms   (O(N^2))");
			Console.WriteLine($"Merge Sort Time  : {mergeTime} ms   (O(N log N))");
			Console.WriteLine($"Quick Sort Time  : {quickTime} ms   (O(N log N) avg)");
		}

		// Generates an array of random integers
		private static int[] GenerateData(int size)
		{
			int[] arr = new int[size];
			for (int i = 0; i < size; i++)
			{
				arr[i] = rand.Next(1, size * 5);
			}
			return arr;
		}

		// Bubble Sort implementation
		private static void BubbleSort(int[] arr)
		{
			for (int i = 0; i < arr.Length - 1; i++)
			{
				for (int j = 0; j < arr.Length - i - 1; j++)
				{
					if (arr[j] > arr[j + 1])
					{
						int temp = arr[j];
						arr[j] = arr[j + 1];
						arr[j + 1] = temp;
					}
				}
			}
		}

		// Merge Sort implementation
		private static void MergeSort(int[] arr, int left, int right)
		{
			if (left >= right)
				return;

			int mid = left + (right - left) / 2;

			MergeSort(arr, left, mid);
			MergeSort(arr, mid + 1, right);
			Merge(arr, left, mid, right);
		}

		private static void Merge(int[] arr, int left, int mid, int right)
		{
			int[] temp = new int[right - left + 1];
			int i = left, j = mid + 1, k = 0;

			while (i <= mid && j <= right)
			{
				temp[k++] = arr[i] <= arr[j] ? arr[i++] : arr[j++];
			}

			while (i <= mid) temp[k++] = arr[i++];
			while (j <= right) temp[k++] = arr[j++];

			for (int x = 0; x < temp.Length; x++)
			{
				arr[left + x] = temp[x];
			}
		}

		// Quick Sort implementation
		private static void QuickSort(int[] arr, int low, int high)
		{
			if (low >= high)
				return;

			int pivotIndex = Partition(arr, low, high);
			QuickSort(arr, low, pivotIndex - 1);
			QuickSort(arr, pivotIndex + 1, high);
		}

		private static int Partition(int[] arr, int low, int high)
		{
			int pivot = arr[high];
			int i = low - 1;

			for (int j = low; j < high; j++)
			{
				if (arr[j] < pivot)
				{
					i++;
					int temp = arr[i];
					arr[i] = arr[j];
					arr[j] = temp;
				}
			}

			int swap = arr[i + 1];
			arr[i + 1] = arr[high];
			arr[high] = swap;

			return i + 1;
		}
	}
}