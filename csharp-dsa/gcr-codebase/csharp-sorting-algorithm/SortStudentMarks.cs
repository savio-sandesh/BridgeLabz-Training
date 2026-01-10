namespace BridgeLabzTraining.csharp_sorting_algorithm
{
	internal class SortStudentMarks
	{
		// This program sorts student marks stored in an array using
		// the Bubble Sort algorithm. It compares adjacent elements
		// and swaps them when necessary to arrange the marks in ascending order.

		private static void BubbleSort(int[] marks)
		{
			int n = marks.Length;
			bool swapped;

			for (int i = 0; i < n - 1; i++)
			{
				swapped = false;

				for (int j = 0; j < n - i - 1; j++)
				{
					if (marks[j] > marks[j + 1])
					{
						int temp = marks[j];
						marks[j] = marks[j + 1];
						marks[j + 1] = temp;
						swapped = true;
					}
				}

				if (!swapped)
					break;
			}
		}

		private static void DisplayArray(int[] marks)
		{
			foreach (int mark in marks)
			{
				Console.Write(mark + " ");
			}
			Console.WriteLine();
		}

		private static void Main(string[] args)
		{
			int[] marks = null;
			bool exit = false;

			while (!exit)
			{
				Console.WriteLine("\n-:Student Marks Sorting:- ");
				Console.WriteLine("1. Enter Student Marks");
				Console.WriteLine("2. Sort Marks using Bubble Sort");
				Console.WriteLine("3. Display Marks");
				Console.WriteLine("4. Exit");
				Console.Write("Enter your choice: ");

				int choice = Convert.ToInt32(Console.ReadLine());

				switch (choice)
				{
					case 1:
						Console.Write("Enter number of students: ");
						int size = Convert.ToInt32(Console.ReadLine());
						marks = new int[size];

						for (int i = 0; i < size; i++)
						{
							Console.Write($"Enter marks for student {i + 1}: ");
							marks[i] = Convert.ToInt32(Console.ReadLine());
						}
						break;

					case 2:
						if (marks != null)
						{
							BubbleSort(marks);
							Console.WriteLine("Marks sorted successfully.");
						}
						else
						{
							Console.WriteLine("Please enter marks first.");
						}
						break;

					case 3:
						if (marks != null)
						{
							Console.WriteLine("Student Marks:");
							DisplayArray(marks);
						}
						else
						{
							Console.WriteLine("No marks available to display.");
						}
						break;

					case 4:
						exit = true;
						Console.WriteLine("Exiting program.");
						break;

					default:
						Console.WriteLine("Invalid choice. Please try again.");
						break;
				}
			}
		}
	}
}