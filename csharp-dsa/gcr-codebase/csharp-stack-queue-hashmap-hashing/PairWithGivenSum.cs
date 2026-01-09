namespace BridgeLabzTraining.csharp_stack_queue_hashmap_hashing
{
	internal class PairWithGivenSum
	{
		// Custom HashMap with frequency (from scratch)
		private class HashMap
		{
			private int[] keys;
			private int[] values; // frequency
			private bool[] occupied;
			private int size;

			public HashMap(int size)
			{
				this.size = size;
				keys = new int[size];
				values = new int[size];
				occupied = new bool[size];
			}

			private int Hash(int key)
			{
				return Math.Abs(key) % size;
			}

			public void Put(int key)
			{
				int index = Hash(key);

				while (occupied[index])
				{
					if (keys[index] == key)
					{
						values[index]++;
						return;
					}
					index = (index + 1) % size;
				}

				keys[index] = key;
				values[index] = 1;
				occupied[index] = true;
			}

			public int GetCount(int key)
			{
				int index = Hash(key);

				while (occupied[index])
				{
					if (keys[index] == key)
						return values[index];

					index = (index + 1) % size;
				}
				return 0;
			}

			public void Decrement(int key)
			{
				int index = Hash(key);

				while (occupied[index])
				{
					if (keys[index] == key)
					{
						values[index]--;
						return;
					}
					index = (index + 1) % size;
				}
			}
		}

		// Function to find ALL UNIQUE pairs with given sum
		private static void CheckAllPairsWithSum(int[] arr, int n, int target)
		{
			HashMap map = new HashMap(2 * n);

			// Store frequency of each element
			for (int i = 0; i < n; i++)
			{
				map.Put(arr[i]);
			}

			bool found = false;

			Console.WriteLine("\nPairs with given sum:");

			for (int i = 0; i < n; i++)
			{
				int x = arr[i];
				int y = target - x;

				// Check availability
				if (map.GetCount(x) > 0 && map.GetCount(y) > 0)
				{
					// Same element case (e.g., 5 + 5)
					if (x == y && map.GetCount(x) < 2)
						continue;

					Console.WriteLine(x + " + " + y + " = " + target);
					found = true;

					// Reduce frequency to avoid duplicate pairs
					map.Decrement(x);
					map.Decrement(y);
				}
			}

			if (!found)
			{
				Console.WriteLine("No pairs found with the given sum.");
			}
		}

		// Main method (menu-driven)
		private static void Main(string[] args)
		{
			int[] arr = null;
			int n = 0;

			while (true)
			{
				Console.WriteLine("\n--- Pair With Given Sum (Multiple Pairs) ---");
				Console.WriteLine("1. Enter Array");
				Console.WriteLine("2. Find All Pairs");
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
							break;
						}

						Console.Write("Enter target sum: ");
						int target = Convert.ToInt32(Console.ReadLine());
						CheckAllPairsWithSum(arr, n, target);
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