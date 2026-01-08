namespace BridgeLabzTraining.csharp_linkedlist
{
	// Singly Linked List – Student Record Management System
	// This program uses a custom singly linked list to manage student records dynamically.
	// Each node stores student details such as roll number, name, age, and grade.
	// The system supports insertion at different positions, deletion, searching,
	// updating student grades, and displaying all records.

	internal class StudentRecordManagement
	{
		public static void Main()
		{
			StudentLinkedList list = new StudentLinkedList();
			int choice;

			do
			{
				Console.WriteLine();
				Console.WriteLine("1. Add Student at Beginning");
				Console.WriteLine("2. Add Student at End");
				Console.WriteLine("3. Add Student at Position");
				Console.WriteLine("4. Delete Student by Roll Number");
				Console.WriteLine("5. Search Student by Roll Number");
				Console.WriteLine("6. Update Student Grade");
				Console.WriteLine("7. Display All Students");
				Console.WriteLine("0. Exit");
				Console.Write("Enter your choice: ");

				choice = Convert.ToInt32(Console.ReadLine());

				switch (choice)
				{
					case 1:
						Console.Write("Roll Number: ");
						long r1 = Convert.ToInt64(Console.ReadLine());
						Console.Write("Name: ");
						string n1 = Console.ReadLine();
						Console.Write("Age: ");
						int a1 = Convert.ToInt32(Console.ReadLine());
						Console.Write("Grade: ");
						string g1 = Console.ReadLine();
						list.AddAtBeginning(r1, n1, a1, g1);
						break;

					case 2:
						Console.Write("Roll Number: ");
						long r2 = Convert.ToInt64(Console.ReadLine());
						Console.Write("Name: ");
						string n2 = Console.ReadLine();
						Console.Write("Age: ");
						int a2 = Convert.ToInt32(Console.ReadLine());
						Console.Write("Grade: ");
						string g2 = Console.ReadLine();
						list.AddAtEnd(r2, n2, a2, g2);
						break;

					case 3:
						Console.Write("Position: ");
						int pos = Convert.ToInt32(Console.ReadLine());
						Console.Write("Roll Number: ");
						long r3 = Convert.ToInt64(Console.ReadLine());
						Console.Write("Name: ");
						string n3 = Console.ReadLine();
						Console.Write("Age: ");
						int a3 = Convert.ToInt32(Console.ReadLine());
						Console.Write("Grade: ");
						string g3 = Console.ReadLine();
						list.AddAtPosition(pos, r3, n3, a3, g3);
						break;

					case 4:
						Console.Write("Enter Roll Number to Delete: ");
						long del = Convert.ToInt64(Console.ReadLine());
						list.DeleteByRollNumber(del);
						break;

					case 5:
						Console.Write("Enter Roll Number to Search: ");
						long search = Convert.ToInt64(Console.ReadLine());
						list.SearchByRollNumber(search);
						break;

					case 6:
						Console.Write("Enter Roll Number: ");
						long ur = Convert.ToInt64(Console.ReadLine());
						Console.Write("Enter New Grade: ");
						string ug = Console.ReadLine();
						list.UpdateGrade(ur, ug);
						break;

					case 7:
						list.Display();
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
	}

	// Node class representing a student
	internal class StudentNode
	{
		public long RollNumber;
		public string Name;
		public int Age;
		public string Grade;
		public StudentNode Next;

		public StudentNode(long roll, string name, int age, string grade)
		{
			RollNumber = roll;
			Name = name;
			Age = age;
			Grade = grade;
			Next = null;
		}
	}

	// Singly Linked List implementation
	internal class StudentLinkedList
	{
		private StudentNode head;

		public void AddAtBeginning(long roll, string name, int age, string grade)
		{
			StudentNode newNode = new StudentNode(roll, name, age, grade);
			newNode.Next = head;
			head = newNode;
		}

		public void AddAtEnd(long roll, string name, int age, string grade)
		{
			StudentNode newNode = new StudentNode(roll, name, age, grade);

			if (head == null)
			{
				head = newNode;
				return;
			}

			StudentNode temp = head;
			while (temp.Next != null)
			{
				temp = temp.Next;
			}
			temp.Next = newNode;
		}

		public void AddAtPosition(int position, long roll, string name, int age, string grade)
		{
			if (position == 1)
			{
				AddAtBeginning(roll, name, age, grade);
				return;
			}

			StudentNode temp = head;
			for (int i = 1; i < position - 1 && temp != null; i++)
			{
				temp = temp.Next;
			}

			if (temp == null)
			{
				Console.WriteLine("Invalid position");
				return;
			}

			StudentNode newNode = new StudentNode(roll, name, age, grade);
			newNode.Next = temp.Next;
			temp.Next = newNode;
		}

		public void DeleteByRollNumber(long roll)
		{
			if (head == null)
				return;

			if (head.RollNumber == roll)
			{
				head = head.Next;
				return;
			}

			StudentNode temp = head;
			while (temp.Next != null && temp.Next.RollNumber != roll)
			{
				temp = temp.Next;
			}

			if (temp.Next == null)
			{
				Console.WriteLine("Student not found");
				return;
			}

			temp.Next = temp.Next.Next;
		}

		public void SearchByRollNumber(long roll)
		{
			StudentNode temp = head;

			while (temp != null)
			{
				if (temp.RollNumber == roll)
				{
					Console.WriteLine($"Student Found: {temp.RollNumber}, {temp.Name}, {temp.Age}, {temp.Grade}");
					return;
				}
				temp = temp.Next;
			}

			Console.WriteLine("Student not found");
		}

		public void UpdateGrade(long roll, string newGrade)
		{
			StudentNode temp = head;

			while (temp != null)
			{
				if (temp.RollNumber == roll)
				{
					temp.Grade = newGrade;
					Console.WriteLine("Grade updated successfully");
					return;
				}
				temp = temp.Next;
			}

			Console.WriteLine("Student not found");
		}

		public void Display()
		{
			StudentNode temp = head;

			if (temp == null)
			{
				Console.WriteLine("No student records available");
				return;
			}

			while (temp != null)
			{
				Console.WriteLine($"{temp.RollNumber} | {temp.Name} | {temp.Age} | {temp.Grade}");
				temp = temp.Next;
			}
		}
	}
}