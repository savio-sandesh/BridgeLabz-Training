namespace BridgeLabzTraining.csharp_stack_queue_hashmap_hashing
{
	internal class CircularTour
	{
		// Queue implementation from scratch (stores indices)
		private class Queue
		{
			private int[] arr;
			private int front, rear, size;

			public Queue(int size)
			{
				this.size = size;
				arr = new int[size];
				front = rear = -1;
			}

			public bool IsEmpty()
			{
				return front == -1;
			}

			public void Enqueue(int value)
			{
				if (rear == size - 1)
					return;

				if (front == -1)
					front = 0;

				arr[++rear] = value;
			}

			public int Dequeue()
			{
				if (IsEmpty())
					return -1;

				int value = arr[front];
				if (front == rear)
					front = rear = -1;
				else
					front++;

				return value;
			}
		}

		// Function to find starting petrol pump
		private static int FindStartingPoint(int[] petrol, int[] distance, int n)
		{
			Queue queue = new Queue(n);
			int start = 0, end = 0;
			int currPetrol = 0;

			queue.Enqueue(0);
			currPetrol = petrol[0] - distance[0];

			while (!queue.IsEmpty() && (start != end || currPetrol < 0))
			{
				while (currPetrol < 0 && !queue.IsEmpty())
				{
					int removed = queue.Dequeue();
					currPetrol -= petrol[removed] - distance[removed];
					start = (removed + 1) % n;

					if (start == 0)
						return -1;
				}

				end = (end + 1) % n;
				queue.Enqueue(end);
				currPetrol += petrol[end] - distance[end];
			}

			return start;
		}

		// Main method (menu-driven)
		private static void Main(string[] args)
		{
			int[] petrol = null;
			int[] distance = null;
			int n = 0;

			while (true)
			{
				Console.WriteLine("\n--- Circular Tour Problem ---");
				Console.WriteLine("1. Enter Petrol Pumps Data");
				Console.WriteLine("2. Find Starting Point");
				Console.WriteLine("3. Exit");
				Console.Write("Enter your choice: ");

				int choice = Convert.ToInt32(Console.ReadLine());

				switch (choice)
				{
					case 1:
						Console.Write("Enter number of petrol pumps: ");
						n = Convert.ToInt32(Console.ReadLine());

						petrol = new int[n];
						distance = new int[n];

						Console.WriteLine("Enter petrol and distance for each pump:");
						for (int i = 0; i < n; i++)
						{
							while (true)
							{
								Console.Write($"Pump {i + 1} Petrol: ");
								string p = Console.ReadLine();
								Console.Write($"Pump {i + 1} Distance to next: ");
								string d = Console.ReadLine();

								if (int.TryParse(p, out petrol[i]) &&
									int.TryParse(d, out distance[i]))
									break;

								Console.WriteLine("Invalid input! Enter integers only.");
							}
						}
						break;

					case 2:
						if (petrol == null || distance == null)
						{
							Console.WriteLine("Please enter petrol pump data first!");
							break;
						}

						int start = FindStartingPoint(petrol, distance, n);
						if (start == -1)
							Console.WriteLine("No possible circular tour.");
						else
							Console.WriteLine("Start at petrol pump index: " + start);
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