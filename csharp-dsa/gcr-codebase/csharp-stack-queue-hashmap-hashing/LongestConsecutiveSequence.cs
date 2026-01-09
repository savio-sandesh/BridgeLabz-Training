namespace BridgeLabzTraining.csharp_stack_queue_hashmap_hashing
{
	internal class LongestConsecutiveSequence
	{
		// Custom HashMap implementation from scratch
		private class HashMap
		{
			private int[] keys;
			private bool[] occupied;
			private int size;

			public HashMap(int size)
			{
				this.size = size;
				keys = new int[size];
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
						return; // already exists
					index = (index + 1) % size;
				}

				keys[index] = key;
				occupied[index] = true;
			}

			public bool Contains(int key)
			{
				int index = Hash(key);

				while (occupied[index])
				{
					if (keys[index] == key)
						return true;
					index = (index + 1) % size;
				}
				return false;
			}
		}

		// Function to find longest consecutive sequence length
		private static void FindLongestConsecutiveSequence(int[] arr, int n)
		{
			HashMap map = new HashMap(2 * n);

			// Store all elements
			for (int i = 0; i < n; i++)
			{
				map.Put(arr[i]);
			}

			int longest = 0;

			for (int i = 0; i < n; i++)
			{
				int current = arr[i];

				// Check if this is the start of a sequence
				if (!map.Contains(current - 1))
				{
					int length = 1;

					while (map.Contains(current + length))
					{
						length++;
					}

					if (length > longest)
						longest = length;
				}
			}

			Console.WriteLine("\nLength of Longest Consecutive Sequence: " + longest);
		}

		// Main method (menu-driven)
		private static void Main(string[] args)
		{
			int[] arr = null;
			int n = 0;

			while (true)
			{
				Console.WriteLine("\n--- Longest Consecutive Sequence ---");
				Console.WriteLine("1. Enter Array");
				Console.WriteLine("2. Find Longest Consecutive Sequence");
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
							FindLongestConsecutiveSequence(arr, n);
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