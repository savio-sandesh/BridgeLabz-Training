namespace BridgeLabzTraining.csharp_sorting_algorithm
{
	internal class SortProductPrices
	{
		// This program sorts product prices stored in an array using
		// the Quick Sort algorithm. It selects a pivot element,
		// partitions the array around the pivot, and recursively
		// sorts the subarrays to arrange prices in ascending order.

		private static void QuickSort(int[] prices, int low, int high)
		{
			if (low < high)
			{
				int pivotIndex = Partition(prices, low, high);

				QuickSort(prices, low, pivotIndex - 1);
				QuickSort(prices, pivotIndex + 1, high);
			}
		}

		private static int Partition(int[] prices, int low, int high)
		{
			int pivot = prices[high];
			int i = low - 1;

			for (int j = low; j < high; j++)
			{
				if (prices[j] < pivot)
				{
					i++;
					int temp = prices[i];
					prices[i] = prices[j];
					prices[j] = temp;
				}
			}

			int swapTemp = prices[i + 1];
			prices[i + 1] = prices[high];
			prices[high] = swapTemp;

			return i + 1;
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
				Console.WriteLine("\n-: Product Price Sorting Menu :-");
				Console.WriteLine("1. Enter Product Prices");
				Console.WriteLine("2. Sort Prices using Quick Sort");
				Console.WriteLine("3. Display Product Prices");
				Console.WriteLine("4. Exit");
				Console.Write("Enter your choice: ");

				int choice = Convert.ToInt32(Console.ReadLine());

				switch (choice)
				{
					case 1:
						Console.Write("Enter number of products: ");
						int size = Convert.ToInt32(Console.ReadLine());
						prices = new int[size];

						for (int i = 0; i < size; i++)
						{
							Console.Write($"Enter price of product {i + 1}: ");
							prices[i] = Convert.ToInt32(Console.ReadLine());
						}
						break;

					case 2:
						if (prices != null)
						{
							QuickSort(prices, 0, prices.Length - 1);
							Console.WriteLine("Product prices sorted successfully.");
						}
						else
						{
							Console.WriteLine("Please enter product prices first.");
						}
						break;

					case 3:
						if (prices != null)
						{
							Console.WriteLine("Product Prices:");
							DisplayArray(prices);
						}
						else
						{
							Console.WriteLine("No product prices available to display.");
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