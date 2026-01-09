namespace BridgeLabzTraining.csharp_stack_queue_hashmap_hashing
{
	internal class CustomHashMap
	{
		// Node for linked list (key-value pair)
		private class Node
		{
			public int Key;
			public int Value;
			public Node Next;

			public Node(int key, int value)
			{
				Key = key;
				Value = value;
				Next = null;
			}
		}

		// Custom HashMap using Separate Chaining
		private class HashMap
		{
			private Node[] buckets;
			private int size;

			public HashMap(int size)
			{
				this.size = size;
				buckets = new Node[size];
			}

			// Hash function
			private int Hash(int key)
			{
				return Math.Abs(key) % size;
			}

			// Insert or Update
			public void Put(int key, int value)
			{
				int index = Hash(key);
				Node head = buckets[index];

				Node current = head;
				while (current != null)
				{
					if (current.Key == key)
					{
						current.Value = value; // update
						Console.WriteLine("Key updated successfully.");
						return;
					}
					current = current.Next;
				}

				Node newNode = new Node(key, value);
				newNode.Next = head;
				buckets[index] = newNode;

				Console.WriteLine("Key inserted successfully.");
			}

			// Retrieve value
			public void Get(int key)
			{
				int index = Hash(key);
				Node current = buckets[index];

				while (current != null)
				{
					if (current.Key == key)
					{
						Console.WriteLine("Value for key " + key + " is: " + current.Value);
						return;
					}
					current = current.Next;
				}

				Console.WriteLine("Key not found.");
			}

			// Delete key
			public void Remove(int key)
			{
				int index = Hash(key);
				Node current = buckets[index];
				Node prev = null;

				while (current != null)
				{
					if (current.Key == key)
					{
						if (prev == null)
							buckets[index] = current.Next;
						else
							prev.Next = current.Next;

						Console.WriteLine("Key removed successfully.");
						return;
					}

					prev = current;
					current = current.Next;
				}

				Console.WriteLine("Key not found.");
			}

			// Display HashMap
			public void Display()
			{
				Console.WriteLine("\nHash Map Contents:");
				for (int i = 0; i < size; i++)
				{
					Console.Write("Bucket " + i + ": ");
					Node current = buckets[i];

					if (current == null)
					{
						Console.WriteLine("Empty");
						continue;
					}

					while (current != null)
					{
						Console.Write("[" + current.Key + " : " + current.Value + "] -> ");
						current = current.Next;
					}
					Console.WriteLine("NULL");
				}
			}
		}

		// Main method (menu-driven)
		private static void Main(string[] args)
		{
			Console.Write("Enter hash map size: ");
			int size = Convert.ToInt32(Console.ReadLine());

			HashMap map = new HashMap(size);

			while (true)
			{
				Console.WriteLine("\n--- Custom Hash Map ---");
				Console.WriteLine("1. Insert / Update");
				Console.WriteLine("2. Get Value");
				Console.WriteLine("3. Remove Key");
				Console.WriteLine("4. Display Hash Map");
				Console.WriteLine("5. Exit");
				Console.Write("Enter your choice: ");

				int choice = Convert.ToInt32(Console.ReadLine());

				switch (choice)
				{
					case 1:
						Console.Write("Enter key: ");
						int key = Convert.ToInt32(Console.ReadLine());
						Console.Write("Enter value: ");
						int value = Convert.ToInt32(Console.ReadLine());
						map.Put(key, value);
						break;

					case 2:
						Console.Write("Enter key to search: ");
						int searchKey = Convert.ToInt32(Console.ReadLine());
						map.Get(searchKey);
						break;

					case 3:
						Console.Write("Enter key to remove: ");
						int removeKey = Convert.ToInt32(Console.ReadLine());
						map.Remove(removeKey);
						break;

					case 4:
						map.Display();
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