namespace BridgeLabzTraining.scenario_based
{
	internal class MetalFactory
	{
		private static void Main(string[] args)
		{
			int rodLength = 8;

			// Initialize price chart
			PriceChart chart = new PriceChart(rodLength);
			chart.SetPrice(1, 1);
			chart.SetPrice(2, 5);
			chart.SetPrice(3, 8);
			chart.SetPrice(4, 9);
			chart.SetPrice(5, 10);
			chart.SetPrice(6, 17);
			chart.SetPrice(7, 17);
			chart.SetPrice(8, 20);

			RodCutter cutter = new RodCutter(chart);

			int choice;
			do
			{
				Console.WriteLine("\n--- Metal Factory Pipe Cutting Menu ---");
				Console.WriteLine("1. Scenario A: Best Revenue (Simple Cuts)");
				Console.WriteLine("2. Scenario B: Custom Length Order");
				Console.WriteLine("3. Scenario C: No Cut (Non-Optimized)");
				Console.WriteLine("0. Exit");
				Console.Write("Enter your choice: ");

				choice = Convert.ToInt32(Console.ReadLine());

				switch (choice)
				{
					case 1:
						Console.WriteLine("Best Revenue: " +
							cutter.CalculateBestRevenue(rodLength));
						break;

					case 2:
						Console.Write("Enter custom length: ");
						int length = Convert.ToInt32(Console.ReadLine());

						Console.Write("Enter new price: ");
						int price = Convert.ToInt32(Console.ReadLine());

						chart.SetPrice(length, price);
						Console.WriteLine("Revenue After Custom Order: " +
							cutter.CalculateBestRevenue(rodLength));
						break;

					case 3:
						Console.WriteLine("Revenue Without Cut: " +
							chart.GetPrice(rodLength));
						break;

					case 0:
						Console.WriteLine("Exiting program...");
						break;

					default:
						Console.WriteLine("Invalid choice!");
						break;
				}
			} while (choice != 0);
		}
	}

	// Encapsulation: Price storage using array
	internal class PriceChart
	{
		private int[] prices;

		public PriceChart(int size)
		{
			prices = new int[size + 1];
		}

		public void SetPrice(int length, int value)
		{
			prices[length] = value;
		}

		public int GetPrice(int length)
		{
			return prices[length];
		}
	}

	// Simple iterative logic (NO DP)
	internal class RodCutter
	{
		private PriceChart chart;

		public RodCutter(PriceChart chart)
		{
			this.chart = chart;
		}

		public int CalculateBestRevenue(int rodLength)
		{
			int maxRevenue = chart.GetPrice(rodLength); // no cut case

			// Try all single-cut combinations
			for (int i = 1; i < rodLength; i++)
			{
				int revenue = chart.GetPrice(i) +
							  chart.GetPrice(rodLength - i);

				if (revenue > maxRevenue)
					maxRevenue = revenue;
			}

			return maxRevenue;
		}
	}
}