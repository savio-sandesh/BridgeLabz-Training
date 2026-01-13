namespace BridgeLabzTraining.csharp_searching_stringbuilder_streamreader
{
	internal class PeakElement
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

			int low = 0;
			int high = n - 1;

			while (low <= high)
			{
				int mid = (low + high) / 2;

				bool leftOk = (mid == 0) || (arr[mid] >= arr[mid - 1]);
				bool rightOk = (mid == n - 1) || (arr[mid] >= arr[mid + 1]);

				if (leftOk && rightOk)
				{
					Console.WriteLine("\nPeak element found: " + arr[mid]);
					Console.WriteLine("Peak index: " + mid);
					break;
				}
				else if (mid > 0 && arr[mid - 1] > arr[mid])
				{
					high = mid - 1;
				}
				else
				{
					low = mid + 1;
				}
			}
		}
	}
}