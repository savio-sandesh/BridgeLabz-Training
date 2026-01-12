namespace BridgeLabzTraining.CustomFurnitureManufacturing
{
	internal class CustomFurnitureManufacturing
	{
		// This program solves the Rod Cutting problem using Dynamic Programming.
		// A carpenter has a wooden rod of fixed length (12 ft) with predefined prices.
		// The program provides different scenarios to maximize revenue
		// with or without waste constraints.

		// Computes maximum revenue for a given rod length
		// and stores the optimal first cut for each length.
		private static int ComputeDP(int[] price, int rodLength, int[] cut)
		{
			int[] dp = new int[rodLength + 1];
			dp[0] = 0;

			for (int i = 1; i <= rodLength; i++)
			{
				int max = int.MinValue;

				for (int j = 1; j <= i; j++)
				{
					if (price[j] + dp[i - j] > max)
					{
						max = price[j] + dp[i - j];
						cut[i] = j;
					}
				}
				dp[i] = max;
			}
			return dp[rodLength];
		}

		// Displays the sequence of cuts used to obtain the solution.
		private static void PrintCuts(int[] cut, int length)
		{
			Console.Write("Cut combination: ");
			while (length > 0)
			{
				Console.Write(cut[length] + " ft ");
				length -= cut[length];
			}
			Console.WriteLine();
		}

		// Scenario A:
		// Maximizes revenue by fully utilizing the rod length.
		private static void ScenarioA(int[] price, int rodLength)
		{
			int[] cut = new int[rodLength + 1];
			int revenue = ComputeDP(price, rodLength, cut);

			Console.WriteLine($"Maximum Revenue: {revenue}");
			PrintCuts(cut, rodLength);
		}

		// Scenario B:
		// Maximizes revenue while allowing a user-defined waste constraint.
		private static void ScenarioB(int[] price, int rodLength)
		{
			Console.Write("Enter allowed waste (ft): ");
			int wasteLimit = Convert.ToInt32(Console.ReadLine());

			int[] dp = new int[rodLength + 1];
			int[] cut = new int[rodLength + 1];
			dp[0] = 0;

			for (int i = 1; i <= rodLength; i++)
			{
				int max = int.MinValue;
				for (int j = 1; j <= i; j++)
				{
					if (price[j] + dp[i - j] > max)
					{
						max = price[j] + dp[i - j];
						cut[i] = j;
					}
				}
				dp[i] = max;
			}

			int bestRevenue = int.MinValue;
			int usedLength = rodLength;

			for (int i = rodLength; i >= rodLength - wasteLimit; i--)
			{
				if (dp[i] > bestRevenue)
				{
					bestRevenue = dp[i];
					usedLength = i;
				}
			}

			Console.WriteLine($"Maximum Revenue: {bestRevenue}");
			Console.WriteLine($"Waste: {rodLength - usedLength} ft");
			PrintCuts(cut, usedLength);
		}

		// Scenario C:
		// Maximizes revenue and, in case of ties,
		// selects the solution with minimum waste.
		private static void ScenarioC(int[] price, int rodLength)
		{
			int[] dp = new int[rodLength + 1];
			int[] cut = new int[rodLength + 1];
			dp[0] = 0;

			for (int i = 1; i <= rodLength; i++)
			{
				int max = int.MinValue;
				for (int j = 1; j <= i; j++)
				{
					if (price[j] + dp[i - j] > max)
					{
						max = price[j] + dp[i - j];
						cut[i] = j;
					}
				}
				dp[i] = max;
			}

			int maxRevenue = int.MinValue;
			int usedLength = 0;

			for (int i = 0; i <= rodLength; i++)
			{
				if (dp[i] > maxRevenue || (dp[i] == maxRevenue && i > usedLength))
				{
					maxRevenue = dp[i];
					usedLength = i;
				}
			}

			Console.WriteLine($"Maximum Revenue: {maxRevenue}");
			Console.WriteLine($"Waste: {rodLength - usedLength} ft");
			PrintCuts(cut, usedLength);
		}

		// Entry point with menu-driven interaction
		// to choose between different scenarios.
		private static void Main(string[] args)
		{
			int rodLength = 12;

			// Price list where index represents rod length
			int[] price =
			{
				0,
				2, 5, 7, 8, 10, 17,
				17, 20, 24, 30, 31, 33
			};

			bool exit = false;

			while (!exit)
			{
				Console.WriteLine("\n-: Custom Furniture Manufacturing :-");
				Console.WriteLine("1. Scenario A - Maximize Revenue");
				Console.WriteLine("2. Scenario B - Revenue with Waste Constraint");
				Console.WriteLine("3. Scenario C - Max Revenue with Minimum Waste");
				Console.WriteLine("4. Exit");
				Console.Write("Enter your choice: ");

				int choice = Convert.ToInt32(Console.ReadLine());

				switch (choice)
				{
					case 1:
						ScenarioA(price, rodLength);
						break;

					case 2:
						ScenarioB(price, rodLength);
						break;

					case 3:
						ScenarioC(price, rodLength);
						break;

					case 4:
						exit = true;
						Console.WriteLine("Exiting program.");
						break;

					default:
						Console.WriteLine("Invalid choice.");
						break;
				}
			}
		}
	}
}