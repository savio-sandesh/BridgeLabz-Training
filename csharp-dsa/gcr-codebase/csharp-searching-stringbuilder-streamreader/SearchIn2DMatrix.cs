namespace BridgeLabzTraining.csharp_searching_stringbuilder_streamreader
{
	internal class SearchIn2DMatrix
	{
		private static void Main(string[] args)
		{
			Console.Write("Enter number of rows: ");
			int rows = Convert.ToInt32(Console.ReadLine());

			Console.Write("Enter number of columns: ");
			int cols = Convert.ToInt32(Console.ReadLine());

			int[,] matrix = new int[rows, cols];

			// Taking matrix input
			Console.WriteLine("Enter matrix elements:");
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					Console.Write($"Element [{i},{j}]: ");
					matrix[i, j] = Convert.ToInt32(Console.ReadLine());
				}
			}

			Console.Write("\nEnter target value to search: ");
			int target = Convert.ToInt32(Console.ReadLine());

			int low = 0;
			int high = (rows * cols) - 1;
			bool found = false;

			// Binary Search
			while (low <= high)
			{
				int mid = (low + high) / 2;
				int row = mid / cols;
				int col = mid % cols;

				if (matrix[row, col] == target)
				{
					Console.WriteLine($"\nTarget found at row {row}, column {col}");
					found = true;
					break;
				}
				else if (matrix[row, col] < target)
				{
					low = mid + 1;
				}
				else
				{
					high = mid - 1;
				}
			}

			if (!found)
			{
				Console.WriteLine("\nTarget value not found in the matrix.");
			}
		}
	}
}