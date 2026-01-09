namespace BridgeLabzTraining.csharp_stack_queue_hashmap_hashing
{
	internal class SlidingWindowMaximum
	{
		// Deque implementation from scratch (stores indices)
		private class Deque
		{
			private int[] arr;
			private int front;
			private int rear;
			private int size;

			public Deque(int size)
			{
				this.size = size;
				arr = new int[size];
				front = -1;
				rear = -1;
			}

			public bool IsEmpty()
			{
				return front == -1;
			}

			public void AddRear(int value)
			{
				if (rear == size - 1)
					return;

				if (front == -1)
					front = 0;

				arr[++rear] = value;
			}

			public void RemoveFront()
			{
				if (IsEmpty())
					return;

				if (front == rear)
					front = rear = -1;
				else
					front++;
			}

			public void RemoveRear()
			{
				if (IsEmpty())
					return;

				if (front == rear)
					front = rear = -1;
				else
					rear--;
			}

			public int GetFront()
			{
				return arr[front];
			}

			public int GetRear()
			{
				return arr[rear];
			}
		}

		// Function to calculate sliding window maximum
		private static void SlidingWindowMax(int[] arr, int n, int k)
		{
			if (k > n)
			{
				Console.WriteLine("Window size cannot be greater than array size.");
				return;
			}

			Deque deque = new Deque(n);

			// Process first k elements
			for (int i = 0; i < k; i++)
			{
				while (!deque.IsEmpty() && arr[deque.GetRear()] <= arr[i])
				{
					deque.RemoveRear();
				}
				deque.AddRear(i);
			}

			Console.WriteLine("\nSliding Window Maximums:");

			// Process remaining elements
			for (int i = k; i < n; i++)
			{
				Console.Write(arr[deque.GetFront()] + " ");

				// Remove indices out of current window
				while (!deque.IsEmpty() && deque.GetFront() <= i - k)
				{
					deque.RemoveFront();
				}

				// Remove smaller elements
				while (!deque.IsEmpty() && arr[deque.GetRear()] <= arr[i])
				{
					deque.RemoveRear();
				}

				deque.AddRear(i);
			}

			// Print max of last window
			Console.Write(arr[deque.GetFront()]);
			Console.WriteLine();
		}

		// Main method (menu-driven)
		private static void Main(string[] args)
		{
			int[] arr = null;
			int n = 0;

			while (true)
			{
				Console.WriteLine("\n--- Sliding Window Maximum ---");
				Console.WriteLine("1. Enter Array");
				Console.WriteLine("2. Find Sliding Window Maximum");
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

						Console.Write("Enter window size k: ");
						int k = Convert.ToInt32(Console.ReadLine());
						SlidingWindowMax(arr, n, k);
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