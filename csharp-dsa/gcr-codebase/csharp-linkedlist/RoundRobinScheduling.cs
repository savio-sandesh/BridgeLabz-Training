namespace BridgeLabzTraining.csharp_linkedlist
{
	// Circular Linked List – Round Robin Scheduling Algorithm
	// This program simulates CPU scheduling using Round Robin algorithm.
	// Each process node stores Process ID, Burst Time, Remaining Time, and Priority.
	// The system supports adding/removing processes, round-robin execution,
	// displaying the process queue, and calculating average waiting and
	// turnaround times using a menu-driven approach.

	internal class RoundRobinScheduling
	{
		public static void Main()
		{
			CircularLinkedList scheduler = new CircularLinkedList();
			int choice;

			do
			{
				Console.WriteLine("1. Add Process");
				Console.WriteLine("2. Remove Process by Process ID");
				Console.WriteLine("3. Simulate Round Robin Scheduling");
				Console.WriteLine("4. Display Processes");
				Console.WriteLine("5. Display Average Waiting & Turnaround Time");
				Console.WriteLine("0. Exit");
				Console.Write("Enter your choice: ");

				choice = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine();

				switch (choice)
				{
					case 1:
						Console.Write("Process ID: ");
						int pid = Convert.ToInt32(Console.ReadLine());
						Console.Write("Burst Time: ");
						int burst = Convert.ToInt32(Console.ReadLine());
						Console.Write("Priority: ");
						int priority = Convert.ToInt32(Console.ReadLine());

						scheduler.AddProcess(pid, burst, priority);
						break;

					case 2:
						Console.Write("Enter Process ID to remove: ");
						int rid = Convert.ToInt32(Console.ReadLine());
						scheduler.RemoveProcess(rid);
						break;

					case 3:
						Console.Write("Enter Time Quantum: ");
						int quantum = Convert.ToInt32(Console.ReadLine());
						scheduler.SimulateRoundRobin(quantum);
						break;

					case 4:
						scheduler.DisplayProcesses();
						break;

					case 5:
						scheduler.DisplayAverageTimes();
						break;

					case 0:
						Console.WriteLine("Exiting program...");
						break;

					default:
						Console.WriteLine("Invalid choice");
						break;
				}

				Console.WriteLine();
			} while (choice != 0);
		}
	}

	// Process node for circular linked list
	internal class ProcessNode
	{
		public int ProcessId;
		public int BurstTime;
		public int RemainingTime;
		public int Priority;
		public int CompletionTime;
		public ProcessNode Next;

		public ProcessNode(int pid, int burst, int priority)
		{
			ProcessId = pid;
			BurstTime = burst;
			RemainingTime = burst;
			Priority = priority;
			CompletionTime = 0;
			Next = null;
		}
	}

	// Circular linked list implementation
	internal class CircularLinkedList
	{
		private ProcessNode head;
		private ProcessNode tail;
		private int currentTime = 0;
		private int completedCount = 0;
		private int totalWaitingTime = 0;
		private int totalTurnaroundTime = 0;

		public void AddProcess(int pid, int burst, int priority)
		{
			ProcessNode newNode = new ProcessNode(pid, burst, priority);

			if (head == null)
			{
				head = tail = newNode;
				newNode.Next = head;
				return;
			}

			tail.Next = newNode;
			newNode.Next = head;
			tail = newNode;
		}

		public void RemoveProcess(int pid)
		{
			if (head == null)
				return;

			ProcessNode curr = head;
			ProcessNode prev = tail;

			do
			{
				if (curr.ProcessId == pid)
				{
					if (curr == head)
						head = head.Next;

					if (curr == tail)
						tail = prev;

					prev.Next = curr.Next;

					if (curr == head && curr == tail)
						head = tail = null;

					return;
				}

				prev = curr;
				curr = curr.Next;
			} while (curr != head);
		}

		public void SimulateRoundRobin(int quantum)
		{
			if (head == null)
			{
				Console.WriteLine("No processes to schedule");
				return;
			}

			ProcessNode curr = head;

			do
			{
				if (curr.RemainingTime > 0)
				{
					Console.WriteLine($"Executing Process {curr.ProcessId}");

					if (curr.RemainingTime > quantum)
					{
						curr.RemainingTime -= quantum;
						currentTime += quantum;
					}
					else
					{
						currentTime += curr.RemainingTime;
						curr.RemainingTime = 0;
						curr.CompletionTime = currentTime;

						int turnaround = curr.CompletionTime;
						int waiting = turnaround - curr.BurstTime;

						totalTurnaroundTime += turnaround;
						totalWaitingTime += waiting;
						completedCount++;
					}

					DisplayProcesses();
				}

				curr = curr.Next;
			} while (curr != head);
		}

		public void DisplayProcesses()
		{
			if (head == null)
			{
				Console.WriteLine("No processes in queue");
				return;
			}

			ProcessNode temp = head;

			do
			{
				Console.WriteLine($"PID: {temp.ProcessId}, Remaining: {temp.RemainingTime}, Priority: {temp.Priority}");
				temp = temp.Next;
			} while (temp != head);
		}

		public void DisplayAverageTimes()
		{
			if (completedCount == 0)
			{
				Console.WriteLine("No completed processes");
				return;
			}

			Console.WriteLine("Average Waiting Time: " +
				(double)totalWaitingTime / completedCount);
			Console.WriteLine("Average Turnaround Time: " +
				(double)totalTurnaroundTime / completedCount);
		}
	}
}