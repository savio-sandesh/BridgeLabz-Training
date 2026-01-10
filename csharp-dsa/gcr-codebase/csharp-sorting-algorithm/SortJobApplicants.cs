namespace BridgeLabzTraining.csharp_sorting_algorithm
{
	internal class SortJobApplicants
	{
		// This program sorts job applicants' expected salary demands stored
		// in an array using the Heap Sort algorithm. It builds a max heap,
		// repeatedly extracts the largest element, and reheapifies the
		// remaining elements to arrange salaries in ascending order.

		private static void HeapSort(int[] salaries)
		{
			int n = salaries.Length;

			for (int i = n / 2 - 1; i >= 0; i--)
			{
				Heapify(salaries, n, i);
			}

			for (int i = n - 1; i > 0; i--)
			{
				int temp = salaries[0];
				salaries[0] = salaries[i];
				salaries[i] = temp;

				Heapify(salaries, i, 0);
			}
		}

		private static void Heapify(int[] salaries, int n, int i)
		{
			int largest = i;
			int left = 2 * i + 1;
			int right = 2 * i + 2;

			if (left < n && salaries[left] > salaries[largest])
			{
				largest = left;
			}

			if (right < n && salaries[right] > salaries[largest])
			{
				largest = right;
			}

			if (largest != i)
			{
				int swap = salaries[i];
				salaries[i] = salaries[largest];
				salaries[largest] = swap;

				Heapify(salaries, n, largest);
			}
		}

		private static void DisplayArray(int[] salaries)
		{
			foreach (int salary in salaries)
			{
				Console.Write(salary + " ");
			}
			Console.WriteLine();
		}

		private static void Main(string[] args)
		{
			int[] salaries = null;
			bool exit = false;

			while (!exit)
			{
				Console.WriteLine("\n-: Job Applicant Salary Sorting Menu :-");
				Console.WriteLine("1. Enter Salary Demands");
				Console.WriteLine("2. Sort Salaries using Heap Sort");
				Console.WriteLine("3. Display Salary Demands");
				Console.WriteLine("4. Exit");
				Console.Write("Enter your choice: ");

				int choice = Convert.ToInt32(Console.ReadLine());

				switch (choice)
				{
					case 1:
						Console.Write("Enter number of applicants: ");
						int size = Convert.ToInt32(Console.ReadLine());
						salaries = new int[size];

						for (int i = 0; i < size; i++)
						{
							Console.Write($"Enter expected salary of applicant {i + 1}: ");
							salaries[i] = Convert.ToInt32(Console.ReadLine());
						}
						break;

					case 2:
						if (salaries != null)
						{
							HeapSort(salaries);
							Console.WriteLine("Salary demands sorted successfully.");
						}
						else
						{
							Console.WriteLine("Please enter salary demands first.");
						}
						break;

					case 3:
						if (salaries != null)
						{
							Console.WriteLine("Salary Demands:");
							DisplayArray(salaries);
						}
						else
						{
							Console.WriteLine("No salary data available to display.");
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