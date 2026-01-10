namespace BridgeLabzTraining.csharp_sorting_algorithm
{
	internal class SortingArrayOfBookPrice
	{
		// This program sorts book prices stored in an array using
		// the Merge Sort algorithm. It recursively divides the array
		// into smaller parts and merges them to arrange the prices
		// in ascending order.

		private static void MergeSort(int[] prices, int left, int right)
		{
			if (left < right)
			{
				int mid = left + (right - left) / 2;

				MergeSort(prices, left, mid);
				MergeSort(prices, mid + 1, right);

				Merge(prices, left, mid, right);
			}
		}

		private static void Merge(int[] prices, int left, int mid, int right)
		{
			int n1 = mid - left + 1;
			int n2 = right - mid;

			int[] leftArray = new int[n1];
			int[] rightArray = new int[n2];

			for (int i = 0; i < n1; i++)
				leftArray[i] = prices[left + i];

			for (int j = 0; j < n2; j++)
				rightArray[j] = prices[mid + 1 + j];

			int iIndex = 0, jIndex = 0, k = left;

			while (iIndex < n1 && jIndex < n2)
			{
				if (leftArray[iIndex] <= rightArray[jIndex])
				{
					prices[k] = leftArray[iIndex];
					iIndex++;
				}
				else
				{
					prices[k] = rightArray[jIndex];
					jIndex++;
				}
				k++;
			}

			while (iIndex < n1)
			{
				prices[k] = leftArray[iIndex];
				iIndex++;
				k++;
			}

			while (jIndex < n2)
			{
				prices[k] = rightArray[jIndex];
				jIndex++;
				k++;
			}
		}

		private static void DisplayArray(int[] prices)
		{
			foreach (int price in prices)
			{
				Console.Write(price + " ");
			}
			Console.WriteLine();
		}

		private static void Main(string[] args)
		{
			int[] prices = null;
			bool exit = false;

			while (!exit)
			{
				Console.WriteLine("\n-: Book Price Sorting Menu :-");
				Console.WriteLine("1. Enter Book Prices");
				Console.WriteLine("2. Sort Prices using Merge Sort");
				Console.WriteLine("3. Display Book Prices");
				Console.WriteLine("4. Exit");
				Console.Write("Enter your choice: ");

				int choice = Convert.ToInt32(Console.ReadLine());

				switch (choice)
				{
					case 1:
						Console.Write("Enter number of books: ");
						int size = Convert.ToInt32(Console.ReadLine());
						prices = new int[size];

						for (int i = 0; i < size; i++)
						{
							Console.Write($"Enter price of book {i + 1}: ");
							prices[i] = Convert.ToInt32(Console.ReadLine());
						}
						break;

					case 2:
						if (prices != null)
						{
							MergeSort(prices, 0, prices.Length - 1);
							Console.WriteLine("Book prices sorted successfully.");
						}
						else
						{
							Console.WriteLine("Please enter book prices first.");
						}
						break;

					case 3:
						if (prices != null)
						{
							Console.WriteLine("Book Prices:");
							DisplayArray(prices);
						}
						else
						{
							Console.WriteLine("No book prices available to display.");
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