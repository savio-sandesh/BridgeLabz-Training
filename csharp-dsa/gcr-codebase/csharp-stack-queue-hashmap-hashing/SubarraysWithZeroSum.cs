namespace BridgeLabzTraining.csharp_stack_queue_hashmap_hashing
{
	internal class SubarraysWithZeroSum
	{
		// Custom HashMap implementation from scratch
		private class HashMap
		{
			private int[] keys;
			private int[][] values; // store multiple indices
			private int[] valueCounts;
			private int size;

			public HashMap(int size)
			{
				this.size = size;
				keys = new int[size];
				values = new int[size][];
				valueCounts = new int[size];

				for (int i = 0; i < size; i++)
				{
					keys[i] = int.MinValue;
					values[i] = new int[size];
				}
			}

			private int Hash(int key)
			{
				return Math.Abs(key) % size;
			}

			public void Put(int key, int index)
			{
				int hashIndex = Hash(key);

				while (keys[hashIndex] != int.MinValue && keys[hashIndex] != key)
				{
					hashIndex = (hashIndex + 1) % size;
				}

				if (keys[hashIndex] == int.MinValue)
				{
					keys[hashIndex] = key;
				}

				values[hashIndex][valueCounts[hashIndex]++] = index;
			}

			public int[] Get(int key, out int count)
			{
				int hashIndex = Hash(key);

				while (keys[hashIndex] != int.MinValue)
				{
					if (keys[hashIndex] == key)
					{
						count = valueCounts[hashIndex];
						return values[hashIndex];
					}
					hashIndex = (hashIndex + 1) % size;
				}

				count = 0;
				return null;
			}
		}

		// Function to find all zero-sum subarrays
		private static void FindZeroSumSubarrays(int[] arr, int n)
		{
			HashMap map = new HashMap(2 * n);
			int sum = 0;
			bool found = false;

			Console.WriteLine("\nZero-sum subarrays (start index -- end index):");

			for (int i = 0; i < n; i++)
			{
				sum += arr[i];

				// Case 1: sum is zero
				if (sum == 0)
				{
					Console.WriteLine("0 -- " + i);
					found = true;
				}

				// Case 2: sum already exists
				int count;
				int[] indices = map.Get(sum, out count);
				if (indices != null)
				{
					for (int j = 0; j < count; j++)
					{
						Console.WriteLine((indices[j] + 1) + " -- " + i);
						found = true;
					}
				}

				// Store current sum with index
				map.Put(sum, i);
			}

			if (!found)
			{
				Console.WriteLine("No zero-sum subarrays found.");
			}
		}

		// Main method (menu-driven)
		private static void Main(string[] args)
		{
			int[] arr = null;
			int n = 0;

			while (true)
			{
				Console.WriteLine("\n--- Subarrays With Zero Sum ---");
				Console.WriteLine("1. Enter Array");
				Console.WriteLine("2. Find Zero-Sum Subarrays");
				Console.WriteLine("3. Exit");
				Console.Write("Enter your choice: ");

				int choice = Convert.ToInt32(Console.ReadLine());

				switch (choice)
				{
					case 1:
						Console.Write("Enter array size: ");
						n = Convert.ToInt32(Console.ReadLine());
						arr = new int[n];

						Console.WriteLine("Enter array elements:");
						for (int i = 0; i < n; i++)
						{
							while (true)
							{
								Console.Write("Element " + (i + 1) + ": ");
								string input = Console.ReadLine();
								if (int.TryParse(input, out arr[i]))
									break;
								else
									Console.WriteLine("Invalid input! Enter an integer.");
							}
						}
						break;

					case 2:
						if (arr == null)
						{
							Console.WriteLine("Please enter the array first!");
						}
						else
						{
							FindZeroSumSubarrays(arr, n);
						}
						break;

					case 3:
						Console.WriteLine("Exiting program...");
						return;

					default:
						Console.WriteLine("Invalid choice!");
						break;
				}
			}
		}
	}
}