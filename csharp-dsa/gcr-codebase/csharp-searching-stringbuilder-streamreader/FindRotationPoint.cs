namespace BridgeLabzTraining.csharp_searching_stringbuilder_streamreader
{
	internal class FindRotationPoint
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

			// Binary Search to find rotation point
			while (low < high)
			{
				int mid = (low + high) / 2;

				if (arr[mid] > arr[high])
				{
					low = mid + 1;
				}
				else
				{
					high = mid;
				}
			}

			Console.WriteLine("\nRotation point index: " + low);
			Console.WriteLine("Smallest element: " + arr[low]);
		}
	}
}