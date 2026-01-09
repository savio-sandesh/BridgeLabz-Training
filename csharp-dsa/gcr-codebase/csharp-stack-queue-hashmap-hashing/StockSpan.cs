namespace BridgeLabzTraining.csharp_stack_queue_hashmap_hashing
{
	internal class StockSpan
	{
		// Stack implementation from scratch (stores indices)
		private class Stack
		{
			private int[] arr;
			private int top;

			public Stack(int size)
			{
				arr = new int[size];
				top = -1;
			}

			public bool IsEmpty()
			{
				return top == -1;
			}

			public void Push(int value)
			{
				arr[++top] = value;
			}

			public int Pop()
			{
				if (IsEmpty())
					return -1;
				return arr[top--];
			}

			public int Peek()
			{
				if (IsEmpty())
					return -1;
				return arr[top];
			}
		}

		// Function to calculate stock span
		private static void CalculateStockSpan(int[] prices, int n)
		{
			int[] span = new int[n];
			Stack stack = new Stack(n);

			// First day span is always 1
			span[0] = 1;
			stack.Push(0);

			for (int i = 1; i < n; i++)
			{
				while (!stack.IsEmpty() && prices[stack.Peek()] <= prices[i])
				{
					stack.Pop();
				}

				span[i] = stack.IsEmpty() ? i + 1 : i - stack.Peek();
				stack.Push(i);
			}

			Console.WriteLine("\nStock Prices:");
			for (int i = 0; i < n; i++)
			{
				Console.Write(prices[i] + " ");
			}

			Console.WriteLine("\n\nStock Span:");
			for (int i = 0; i < n; i++)
			{
				Console.Write(span[i] + " ");
			}
			Console.WriteLine();
		}

		// Main method (menu-driven)
		private static void Main(string[] args)
		{
			int[] prices = null;
			int n = 0;

			while (true)
			{
				Console.WriteLine("\n--- Stock Span Problem ---");
				Console.WriteLine("1. Enter Stock Prices");
				Console.WriteLine("2. Calculate Stock Span");
				Console.WriteLine("3. Exit");
				Console.Write("Enter your choice: ");

				int choice = Convert.ToInt32(Console.ReadLine());

				switch (choice)
				{
					case 1:
						Console.Write("Enter number of days: ");
						n = Convert.ToInt32(Console.ReadLine());
						prices = new int[n];

						Console.WriteLine("Enter stock prices:");
						for (int i = 0; i < n; i++)
						{
							prices[i] = Convert.ToInt32(Console.ReadLine());
						}
						break;

					case 2:
						if (prices == null)
						{
							Console.WriteLine("Please enter stock prices first!");
						}
						else
						{
							CalculateStockSpan(prices, n);
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