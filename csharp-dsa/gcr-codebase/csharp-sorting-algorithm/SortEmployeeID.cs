namespace BridgeLabzTraining.csharp_sorting_algorithm
{
	internal class SortEmployeeID
	{
		//This program sorts employee IDs stored in an array using
		//the Insertion Sort algorithm. The array is divided into
		//sorted and unsorted parts, and each element from the
		//unsorted part is inserted into its correct position
		//in the sorted part to achieve ascending order.

		private static void InsertionSort(int[] empIds)
		{
			int n = empIds.Length;

			for (int i = 1; i < n; i++)
			{
				int key = empIds[i];
				int j = i - 1;

				while (j >= 0 && empIds[j] > key)
				{
					empIds[j + 1] = empIds[j];
					j--;
				}

				empIds[j + 1] = key;
			}
		}

		private static void DisplayArray(int[] empIds)
		{
			foreach (int id in empIds)
			{
				Console.Write(id + " ");
			}
			Console.WriteLine();
		}

		private static void Main(string[] args)
		{
			int[] empIds = null;
			bool exit = false;

			while (!exit)
			{
				Console.WriteLine("\n--- Employee ID Sorting Menu ---");
				Console.WriteLine("1. Enter Employee IDs");
				Console.WriteLine("2. Sort Employee IDs using Insertion Sort");
				Console.WriteLine("3. Display Employee IDs");
				Console.WriteLine("4. Exit");
				Console.Write("Enter your choice: ");

				int choice = Convert.ToInt32(Console.ReadLine());

				switch (choice)
				{
					case 1:
						Console.Write("Enter number of employees: ");
						int size = Convert.ToInt32(Console.ReadLine());
						empIds = new int[size];

						for (int i = 0; i < size; i++)
						{
							Console.Write($"Enter Employee ID {i + 1}: ");
							empIds[i] = Convert.ToInt32(Console.ReadLine());
						}
						break;

					case 2:
						if (empIds != null)
						{
							InsertionSort(empIds);
							Console.WriteLine("Employee IDs sorted successfully.");
						}
						else
						{
							Console.WriteLine("Please enter employee IDs first.");
						}
						break;

					case 3:
						if (empIds != null)
						{
							Console.WriteLine("Employee IDs:");
							DisplayArray(empIds);
						}
						else
						{
							Console.WriteLine("No employee IDs available to display.");
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