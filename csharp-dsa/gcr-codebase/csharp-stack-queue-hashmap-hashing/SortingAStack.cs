namespace BridgeLabzTraining.csharp_stack_queue_hashmap_hashing
{
	internal class SortingAStack
	{
		private static bool isSorted = false;

		// Stack implementation from scratch
		private class Stack
		{
			private int[] arr;
			private int top;
			private int size;

			public Stack(int size)
			{
				this.size = size;
				arr = new int[size];
				top = -1;
			}

			public bool IsEmpty()
			{
				return top == -1;
			}

			public bool IsFull()
			{
				return top == size - 1;
			}

			public void Push(int value)
			{
				if (IsFull())
				{
					Console.WriteLine("Stack Overflow!");
					return;
				}
				arr[++top] = value;
				isSorted = false;
			}

			public int Pop()
			{
				if (IsEmpty())
				{
					return -1;
				}
				isSorted = false;
				return arr[top--];
			}

			public int Peek()
			{
				if (IsEmpty())
					return -1;
				return arr[top];
			}

			public void Display()
			{
				if (IsEmpty())
				{
					Console.WriteLine("Stack is empty!");
					return;
				}

				if (isSorted)
				{
					Console.WriteLine("Stack sorted (smallest at bottom)");
					Console.WriteLine("Stack from top to bottom:");
				}
				else
				{
					Console.WriteLine("Stack from top to bottom:");
				}

				for (int i = top; i >= 0; i--)
				{
					Console.Write(arr[i] + " ");
				}
				Console.WriteLine();
			}
		}

		// Recursively sort the stack
		private static void SortStack(Stack stack)
		{
			if (!stack.IsEmpty())
			{
				int temp = stack.Pop();
				SortStack(stack);
				SortedInsert(stack, temp);
			}
		}

		// Insert element in sorted order (ascending)
		private static void SortedInsert(Stack stack, int value)
		{
			if (stack.IsEmpty() || value > stack.Peek())
			{
				stack.Push(value);
				return;
			}

			int temp = stack.Pop();
			SortedInsert(stack, value);
			stack.Push(temp);
		}

		// Main method (menu-driven)
		private static void Main(string[] args)
		{
			Console.Write("Enter size of stack: ");
			int size = Convert.ToInt32(Console.ReadLine());

			Stack stack = new Stack(size);

			while (true)
			{
				Console.WriteLine("\n--- Sort Stack Using Recursion ---");
				Console.WriteLine("1. Push");
				Console.WriteLine("2. Pop");
				Console.WriteLine("3. Display");
				Console.WriteLine("4. Sort Stack");
				Console.WriteLine("5. Exit");
				Console.Write("Enter your choice: ");

				int choice = Convert.ToInt32(Console.ReadLine());

				switch (choice)
				{
					case 1:
						Console.Write("Enter value to push: ");
						int value = Convert.ToInt32(Console.ReadLine());
						stack.Push(value);
						break;

					case 2:
						int popped = stack.Pop();
						if (popped != -1)
							Console.WriteLine(popped + " popped from stack.");
						else
							Console.WriteLine("Stack is empty!");
						break;

					case 3:
						stack.Display();
						break;

					case 4:
						SortStack(stack);
						isSorted = true;
						Console.WriteLine("Stack sorted successfully!");
						break;

					case 5:
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