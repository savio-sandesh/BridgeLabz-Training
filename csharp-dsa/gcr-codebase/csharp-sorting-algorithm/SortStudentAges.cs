namespace BridgeLabzTraining.csharp_sorting_algorithm
{
	internal class SortStudentAges
	{
		// This program sorts students' ages stored in an array using
		// the Counting Sort algorithm. It counts the frequency of each
		// age within a fixed range and reconstructs the array to
		// arrange the ages in ascending order.

		private static void CountingSort(int[] ages, int minAge, int maxAge)
		{
			int range = maxAge - minAge + 1;
			int[] count = new int[range];
			int[] output = new int[ages.Length];

			for (int i = 0; i < ages.Length; i++)
			{
				count[ages[i] - minAge]++;
			}

			for (int i = 1; i < count.Length; i++)
			{
				count[i] += count[i - 1];
			}

			for (int i = ages.Length - 1; i >= 0; i--)
			{
				output[count[ages[i] - minAge] - 1] = ages[i];
				count[ages[i] - minAge]--;
			}

			for (int i = 0; i < ages.Length; i++)
			{
				ages[i] = output[i];
			}
		}

		private static bool IsValidAgeRange(int[] ages, int minAge, int maxAge)
		{
			foreach (int age in ages)
			{
				if (age < minAge || age > maxAge)
				{
					return false;
				}
			}
			return true;
		}

		private static void DisplayArray(int[] ages)
		{
			foreach (int age in ages)
			{
				Console.Write(age + " ");
			}
			Console.WriteLine();
		}

		private static void Main(string[] args)
		{
			int[] ages = null;
			bool exit = false;
			int minAge = 10;
			int maxAge = 18;

			while (!exit)
			{
				Console.WriteLine("\n-: Student Age Sorting Menu :-");
				Console.WriteLine("1. Enter Student Ages");
				Console.WriteLine("2. Sort Ages using Counting Sort");
				Console.WriteLine("3. Display Student Ages");
				Console.WriteLine("4. Exit");
				Console.Write("Enter your choice: ");

				int choice = Convert.ToInt32(Console.ReadLine());

				switch (choice)
				{
					case 1:
						Console.Write("Enter number of students: ");
						int size = Convert.ToInt32(Console.ReadLine());
						ages = new int[size];

						for (int i = 0; i < size; i++)
						{
							Console.Write($"Enter age of student {i + 1} (10-18): ");
							ages[i] = Convert.ToInt32(Console.ReadLine());
						}
						break;

					case 2:
						if (ages != null)
						{
							if (IsValidAgeRange(ages, minAge, maxAge))
							{
								CountingSort(ages, minAge, maxAge);
								Console.WriteLine("Student ages sorted successfully.");
							}
							else
							{
								Console.WriteLine("Invalid input detected. Student ages must be between 10 and 18.");
							}
						}
						else
						{
							Console.WriteLine("Please enter student ages first.");
						}
						break;

					case 3:
						if (ages != null)
						{
							Console.WriteLine("Student Ages:");
							DisplayArray(ages);
						}
						else
						{
							Console.WriteLine("No student ages available to display.");
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