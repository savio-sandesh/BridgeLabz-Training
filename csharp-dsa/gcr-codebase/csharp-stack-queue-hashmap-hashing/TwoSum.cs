namespace BridgeLabzTraining.csharp_stack_queue_hashmap_hashing
{
	internal class TwoSum
	{
		// Custom HashMap implementation (value -> index)
		private class HashMap
		{
			private int[] keys;
			private int[] values; // store index
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

			public void Put(int key, int value)
			{
				int index = Hash(key);

				while (occupied[index])
				{
					if (keys[index] == key)
						return; // do not overwrite existing index
					index = (index + 1) % size;
				}

				keys[index] = key;
				values[index] = value;
				occupied[index] = true;
			}

			public bool TryGet(int key, out int value)
			{
				int index = Hash(key);

				while (occupied[index])
				{
					if (keys[index] == key)
					{
						value = values[index];
						return true;
					}
					index = (index + 1) % size;
				}

				value = -1;
				return false;
			}
		}

		// Function to find two indices whose values sum to target
		private static void FindTwoSum(int[] arr, int n, int target)
		{
			HashMap map = new HashMap(2 * n);

			for (int i = 0; i < n; i++)
			{
				int complement = target - arr[i];

				if (map.TryGet(complement, out int index))
				{
					Console.WriteLine(
						"Indices found: [" + index + ", " + i + "]"
					);
					Console.WriteLine(
						"Values: " + arr[index] + " + " + arr[i] + " = " + target
					);
					return;
				}

				map.Put(arr[i], i);
			}

			Console.WriteLine("No two indices found with the given sum.");
		}

		// Main method (menu-driven)
		private static void Main(string[] args)
		{
			int[] arr = null;
			int n = 0;

			while (true)
			{
				Console.WriteLine("\n--- Two Sum Problem ---");
				Console.WriteLine("1. Enter Array");
				Console.WriteLine("2. Find Two Sum Indices");
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
						FindTwoSum(arr, n, target);
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