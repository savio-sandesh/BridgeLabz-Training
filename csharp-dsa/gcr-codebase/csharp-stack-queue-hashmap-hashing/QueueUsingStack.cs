namespace BridgeLabzTraining.csharp_stack_queue_hashmap_hashing
{
	internal class QueueUsingStack
	{
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
			}

			public int Pop()
			{
				if (IsEmpty())
				{
					return -1;
				}
				return arr[top--];
			}

			public int Peek()
			{
				if (IsEmpty())
					return -1;
				return arr[top];
			}
		}

		// Queue using two stacks
		private class Queue
		{
			private Stack stack1;
			private Stack stack2;

			public Queue(int size)
			{
				stack1 = new Stack(size);
				stack2 = new Stack(size);
			}

			public void Enqueue(int value)
			{
				stack1.Push(value);
				Console.WriteLine(value + " enqueued successfully.");
			}

			public void Dequeue()
			{
				if (stack2.IsEmpty())
				{
					while (!stack1.IsEmpty())
					{
						stack2.Push(stack1.Pop());
					}
				}

				if (stack2.IsEmpty())
				{
					Console.WriteLine("Queue is empty!");
					return;
				}

				Console.WriteLine(stack2.Pop() + " dequeued successfully.");
			}

			public void Display()
			{
				if (stack1.IsEmpty() && stack2.IsEmpty())
				{
					Console.WriteLine("Queue is empty!");
					return;
				}

				Console.Write("Queue elements: ");

				// Temporary stack for display
				Stack temp = new Stack(100);

				while (!stack2.IsEmpty())
				{
					int val = stack2.Pop();
					Console.Write(val + " ");
					temp.Push(val);
				}

				while (!temp.IsEmpty())
				{
					stack2.Push(temp.Pop());
				}

				int[] arr = new int[100];
				int index = 0;

				while (!stack1.IsEmpty())
				{
					arr[index++] = stack1.Pop();
				}

				for (int i = index - 1; i >= 0; i--)
				{
					Console.Write(arr[i] + " ");
					stack1.Push(arr[i]);
				}

				Console.WriteLine();
			}
		}

		// Main Method (Menu Driven)
		private static void Main(string[] args)
		{
			Console.Write("Enter size of Queue: ");
			int size = Convert.ToInt32(Console.ReadLine());

			Queue queue = new Queue(size);

			while (true)
			{
				Console.WriteLine("\n--- Queue Using Stack Menu ---");
				Console.WriteLine("1. Enqueue");
				Console.WriteLine("2. Dequeue");
				Console.WriteLine("3. Display");
				Console.WriteLine("4. Exit");
				Console.Write("Enter your choice: ");

				int choice = Convert.ToInt32(Console.ReadLine());

				switch (choice)
				{
					case 1:
						Console.Write("Enter value to enqueue: ");
						int value = Convert.ToInt32(Console.ReadLine());
						queue.Enqueue(value);
						break;

					case 2:
						queue.Dequeue();
						break;

					case 3:
						queue.Display();
						break;

					case 4:
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