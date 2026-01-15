namespace BrowserBuddy
{
	// Manages browsing history for a tab
	// Uses Doubly Linked List and Stack logic
	internal class HistoryManager
	{
		// Node for doubly linked list
		private class HistoryNode
		{
			public string Url;
			public HistoryNode Prev;
			public HistoryNode Next;
		}

		// Points to the current page
		private HistoryNode current;

		// Stack to store closed pages (array based)
		private HistoryNode[] closedStack = new HistoryNode[10];

		// Stack top index
		private int top = -1;

		// Adds a new page to history
		public void Visit(string url)
		{
			HistoryNode newNode = new HistoryNode();
			newNode.Url = url;
			newNode.Prev = current;
			newNode.Next = null;

			if (current != null)
			{
				current.Next = newNode;
			}

			current = newNode;
		}

		// Moves to the previous page
		public string GoBack()
		{
			if (current != null && current.Prev != null)
			{
				current = current.Prev;
				return current.Url;
			}
			return null;
		}

		// Moves to the next page
		public string GoForward()
		{
			if (current != null && current.Next != null)
			{
				current = current.Next;
				return current.Url;
			}
			return null;
		}

		// Closes the current page and stores it in stack
		public void CloseCurrent()
		{
			if (current == null)
				return;

			if (top < closedStack.Length - 1)
			{
				top++;
				closedStack[top] = current;
			}
		}

		// Displays all visited pages in order
		public void ShowHistory()
		{
			if (current == null)
			{
				Console.WriteLine("No browsing history.");
				return;
			}

			Console.WriteLine("=== Page History ===");

			// Move to first visited page
			HistoryNode temp = current;
			while (temp.Prev != null)
			{
				temp = temp.Prev;
			}

			// Traverse forward and display URLs
			while (temp != null)
			{
				Console.WriteLine(temp.Url);
				temp = temp.Next;
			}
		}

		// Restores the last closed page
		public string Restore()
		{
			if (top >= 0)
			{
				current = closedStack[top];
				closedStack[top] = null;
				top--;
				return current.Url;
			}
			return null;
		}
	}
}