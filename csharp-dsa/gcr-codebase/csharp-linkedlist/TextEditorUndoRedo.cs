namespace BridgeLabzTraining.csharp_linkedlist
{
	// Doubly Linked List – Undo/Redo Functionality for Text Editor
	// This program implements undo and redo functionality using a doubly linked list.
	// Each node represents a text state after an action. The system supports adding
	// new text states, undoing and redoing actions, displaying the current text,
	// and limiting the undo/redo history to the last 10 states using a menu-driven approach.

	internal class TextEditorUndoRedo
	{
		public static void Main()
		{
			TextHistory history = new TextHistory(10);
			int choice;

			do
			{
				Console.WriteLine("1. Add New Text State");
				Console.WriteLine("2. Undo");
				Console.WriteLine("3. Redo");
				Console.WriteLine("4. Display Current Text");
				Console.WriteLine("0. Exit");
				Console.Write("Enter your choice: ");

				choice = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine();

				switch (choice)
				{
					case 1:
						Console.Write("Enter text: ");
						string text = Console.ReadLine();
						history.AddState(text);
						break;

					case 2:
						history.Undo();
						break;

					case 3:
						history.Redo();
						break;

					case 4:
						history.DisplayCurrentState();
						break;

					case 0:
						Console.WriteLine("Exiting editor...");
						break;

					default:
						Console.WriteLine("Invalid choice");
						break;
				}

				Console.WriteLine();
			} while (choice != 0);
		}
	}

	// Doubly linked list node representing a text state
	internal class TextNode
	{
		public string Content;
		public TextNode Prev;
		public TextNode Next;

		public TextNode(string content)
		{
			Content = content;
			Prev = null;
			Next = null;
		}
	}

	// Doubly linked list managing undo/redo history
	internal class TextHistory
	{
		private TextNode head;
		private TextNode tail;
		private TextNode current;
		private int maxSize;
		private int size;

		public TextHistory(int limit)
		{
			maxSize = limit;
			size = 0;
		}

		// Add a new text state
		public void AddState(string text)
		{
			TextNode newNode = new TextNode(text);

			// First state
			if (head == null)
			{
				head = tail = current = newNode;
				size++;
				return;
			}

			// Remove redo history if new state is added after undo
			if (current != tail)
			{
				TextNode temp = current.Next;
				while (temp != null)
				{
					TextNode next = temp.Next;
					temp.Prev = null;
					temp.Next = null;
					temp = next;
					size--;
				}
				current.Next = null;
				tail = current;
			}

			// Add new state at end
			tail.Next = newNode;
			newNode.Prev = tail;
			tail = newNode;
			current = newNode;
			size++;

			// Enforce history size limit
			if (size > maxSize)
			{
				head = head.Next;
				head.Prev = null;
				size--;
				Console.WriteLine("Oldest state removed (history limit reached).");
			}
		}

		// Undo operation
		public void Undo()
		{
			if (current == null || current.Prev == null)
			{
				Console.WriteLine("Nothing to undo");
				return;
			}

			current = current.Prev;
			Console.WriteLine("Undo successful");
		}

		// Redo operation
		public void Redo()
		{
			if (current == null || current.Next == null)
			{
				Console.WriteLine("Nothing to redo");
				return;
			}

			current = current.Next;
			Console.WriteLine("Redo successful");
		}

		// Display current text state
		public void DisplayCurrentState()
		{
			if (current == null)
			{
				Console.WriteLine("No text available");
				return;
			}

			Console.WriteLine("Current Text:");
			Console.WriteLine(current.Content);
		}
	}
}