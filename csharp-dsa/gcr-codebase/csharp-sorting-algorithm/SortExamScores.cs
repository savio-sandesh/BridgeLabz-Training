namespace BridgeLabzTraining.csharp_sorting_algorithm
{
	internal class SortExamScores
	{
		// This program sorts students' exam scores stored in an array using
		// the Selection Sort algorithm. It repeatedly finds the minimum
		// element from the unsorted portion and places it at the correct
		// position to arrange scores in ascending order.

		private static void SelectionSort(int[] scores)
		{
			int n = scores.Length;

			for (int i = 0; i < n - 1; i++)
			{
				int minIndex = i;

				for (int j = i + 1; j < n; j++)
				{
					if (scores[j] < scores[minIndex])
					{
						minIndex = j;
					}
				}

				if (minIndex != i)
				{
					int temp = scores[i];
					scores[i] = scores[minIndex];
					scores[minIndex] = temp;
				}
			}
		}

		private static void DisplayArray(int[] scores)
		{
			foreach (int score in scores)
			{
				Console.Write(score + " ");
			}
			Console.WriteLine();
		}

		private static void Main(string[] args)
		{
			int[] scores = null;
			bool exit = false;

			while (!exit)
			{
				Console.WriteLine("\n-: Exam Scores Sorting Menu :-");
				Console.WriteLine("1. Enter Exam Scores");
				Console.WriteLine("2. Sort Scores using Selection Sort");
				Console.WriteLine("3. Display Exam Scores");
				Console.WriteLine("4. Exit");
				Console.Write("Enter your choice: ");

				int choice = Convert.ToInt32(Console.ReadLine());

				switch (choice)
				{
					case 1:
						Console.Write("Enter number of students: ");
						int size = Convert.ToInt32(Console.ReadLine());
						scores = new int[size];

						for (int i = 0; i < size; i++)
						{
							Console.Write($"Enter score of student {i + 1}: ");
							scores[i] = Convert.ToInt32(Console.ReadLine());
						}
						break;

					case 2:
						if (scores != null)
						{
							SelectionSort(scores);
							Console.WriteLine("Exam scores sorted successfully.");
						}
						else
						{
							Console.WriteLine("Please enter exam scores first.");
						}
						break;

					case 3:
						if (scores != null)
						{
							Console.WriteLine("Exam Scores:");
							DisplayArray(scores);
						}
						else
						{
							Console.WriteLine("No exam scores available to display.");
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