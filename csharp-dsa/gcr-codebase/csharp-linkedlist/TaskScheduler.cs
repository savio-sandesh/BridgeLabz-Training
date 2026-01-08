namespace BridgeLabzTraining.csharp_linkedlist
{
	// Circular Linked List – Task Scheduler System
	// This program implements a task scheduler using a circular linked list.
	// Each task node stores task ID, task name, priority, and due date.
	// The system supports insertion at different positions, deletion by task ID,
	// viewing the current task and moving to the next task, searching by priority,
	// and displaying all tasks starting from the head.

	internal class TaskScheduler
	{
		public static void Main()
		{
			CircularTaskList list = new CircularTaskList();
			int choice;

			do
			{
				Console.WriteLine();
				Console.WriteLine("1. Add Task at Beginning");
				Console.WriteLine("2. Add Task at End");
				Console.WriteLine("3. Add Task at Position");
				Console.WriteLine("4. Remove Task by Task ID");
				Console.WriteLine("5. View Current Task & Move to Next");
				Console.WriteLine("6. Display All Tasks");
				Console.WriteLine("7. Search Task by Priority");
				Console.WriteLine("0. Exit");
				Console.Write("Enter your choice: ");

				choice = Convert.ToInt32(Console.ReadLine());

				switch (choice)
				{
					case 1:
						list.AddAtBeginning(ReadTask());
						break;

					case 2:
						list.AddAtEnd(ReadTask());
						break;

					case 3:
						Console.Write("Enter Position: ");
						int pos = Convert.ToInt32(Console.ReadLine());
						list.AddAtPosition(pos, ReadTask());
						break;

					case 4:
						Console.Write("Enter Task ID to Remove: ");
						int removeId = Convert.ToInt32(Console.ReadLine());
						list.RemoveByTaskId(removeId);
						break;

					case 5:
						list.ViewCurrentAndMoveNext();
						break;

					case 6:
						list.DisplayAll();
						break;

					case 7:
						Console.Write("Enter Priority to Search: ");
						string priority = Console.ReadLine();
						list.SearchByPriority(priority);
						break;

					case 0:
						Console.WriteLine("Exiting program...");
						break;

					default:
						Console.WriteLine("Invalid choice");
						break;
				}
			} while (choice != 0);
		}

		// Helper method to read task details
		private static TaskNode ReadTask()
		{
			Console.Write("Task ID: ");
			int id = Convert.ToInt32(Console.ReadLine());

			Console.Write("Task Name: ");
			string name = Console.ReadLine();

			Console.Write("Priority (High/Medium/Low): ");
			string priority = Console.ReadLine();

			Console.Write("Due Date (DD-MM-YYYY): ");
			string dueDate = Console.ReadLine();

			return new TaskNode(id, name, priority, dueDate);
		}
	}

	// Node class representing a task
	internal class TaskNode
	{
		public int TaskId;
		public string TaskName;
		public string Priority;
		public string DueDate;
		public TaskNode Next;

		public TaskNode(int id, string name, string priority, string dueDate)
		{
			TaskId = id;
			TaskName = name;
			Priority = priority;
			DueDate = dueDate;
			Next = null;
		}
	}

	// Circular Linked List implementation
	internal class CircularTaskList
	{
		private TaskNode head;
		private TaskNode current;

		public void AddAtBeginning(TaskNode newNode)
		{
			if (head == null)
			{
				head = newNode;
				newNode.Next = head;
				current = head;
				return;
			}

			TaskNode temp = head;
			while (temp.Next != head)
				temp = temp.Next;

			newNode.Next = head;
			temp.Next = newNode;
			head = newNode;
		}

		public void AddAtEnd(TaskNode newNode)
		{
			if (head == null)
			{
				head = newNode;
				newNode.Next = head;
				current = head;
				return;
			}

			TaskNode temp = head;
			while (temp.Next != head)
				temp = temp.Next;

			temp.Next = newNode;
			newNode.Next = head;
		}

		public void AddAtPosition(int position, TaskNode newNode)
		{
			if (position <= 1)
			{
				AddAtBeginning(newNode);
				return;
			}

			TaskNode temp = head;
			for (int i = 1; i < position - 1 && temp.Next != head; i++)
				temp = temp.Next;

			newNode.Next = temp.Next;
			temp.Next = newNode;
		}

		public void RemoveByTaskId(int taskId)
		{
			if (head == null)
			{
				Console.WriteLine("No tasks available");
				return;
			}

			TaskNode temp = head;
			TaskNode prev = null;

			do
			{
				if (temp.TaskId == taskId)
				{
					if (prev != null)
						prev.Next = temp.Next;
					else
					{
						TaskNode last = head;
						while (last.Next != head)
							last = last.Next;

						head = head.Next;
						last.Next = head;
					}

					Console.WriteLine("Task removed successfully");
					return;
				}

				prev = temp;
				temp = temp.Next;
			} while (temp != head);

			Console.WriteLine("Task not found");
		}

		public void ViewCurrentAndMoveNext()
		{
			if (current == null)
			{
				Console.WriteLine("No tasks available");
				return;
			}

			Console.WriteLine($"Current Task: {current.TaskId} | {current.TaskName} | {current.Priority} | {current.DueDate}");
			current = current.Next;
		}

		public void DisplayAll()
		{
			if (head == null)
			{
				Console.WriteLine("No tasks available");
				return;
			}

			TaskNode temp = head;
			do
			{
				Console.WriteLine($"{temp.TaskId} | {temp.TaskName} | {temp.Priority} | {temp.DueDate}");
				temp = temp.Next;
			} while (temp != head);
		}

		public void SearchByPriority(string priority)
		{
			if (head == null)
			{
				Console.WriteLine("No tasks available");
				return;
			}

			TaskNode temp = head;
			bool found = false;

			do
			{
				if (temp.Priority.Equals(priority, StringComparison.OrdinalIgnoreCase))
				{
					Console.WriteLine($"{temp.TaskId} | {temp.TaskName} | {temp.Priority} | {temp.DueDate}");
					found = true;
				}
				temp = temp.Next;
			} while (temp != head);

			if (!found)
				Console.WriteLine("No tasks found with the given priority");
		}
	}
}