namespace ATMDispenser
{
	// Context: ATM dispenses minimum number of notes.
	// ●  Scenario A: Given ₹1, ₹2, ₹5, ₹10, ₹20, ₹50, ₹100, ₹200, ₹500 notes, find optimal combo for ₹880.
	// ●  Scenario B: Remove ₹500 temporarily and update strategy.
	// ●  Scenario C: Display fallback combo if exact change isn’t possible.
	internal class Program
	{
		private static void Main(string[] args)
		{
			int amount = 880;

			Console.WriteLine("ATM Dispenser Logic\n");

			// ●  Scenario A: Given ₹1, ₹2, ₹5, ₹10, ₹20, ₹50, ₹100, ₹200, ₹500 notes, find optimal combo for ₹880.
			Console.WriteLine("Scenario A: With INR 500 available");
			int[] denominationsA = { 500, 200, 100, 50, 20, 10, 5, 2, 1 };
			DispenseAmount(amount, denominationsA);

			// ●  Scenario B: Remove ₹500 temporarily and update strategy.
			Console.WriteLine("\nScenario B: INR 500 removed");
			int[] denominationsB = { 200, 100, 50, 20, 10, 5, 2, 1 };
			DispenseAmount(amount, denominationsB);

			// ●  Scenario C: Display fallback combo if exact change isn’t possible.
			Console.WriteLine("\nScenario C: Fallback when exact change not possible");
			int[] denominationsC = { 200, 50 };
			DispenseAmountWithFallback(180, denominationsC);

			Console.ReadLine();
		}

		// greedy logic using arrays only
		private static void DispenseAmount(int amount, int[] denominations)
		{
			int remainingAmount = amount;
			int[] noteCount = new int[denominations.Length];

			for (int i = 0; i < denominations.Length; i++)
			{
				if (remainingAmount >= denominations[i])
				{
					noteCount[i] = remainingAmount / denominations[i];
					remainingAmount %= denominations[i];
				}
			}

			if (remainingAmount == 0)
			{
				PrintNotes(denominations, noteCount);
			}
			else
			{
				Console.WriteLine("Exact change not possible.");
			}
		}

		// fallback logic using arrays only
		private static void DispenseAmountWithFallback(int amount, int[] denominations)
		{
			int remainingAmount = amount;
			int dispensedAmount = 0;
			int[] noteCount = new int[denominations.Length];

			for (int i = 0; i < denominations.Length; i++)
			{
				if (remainingAmount >= denominations[i])
				{
					noteCount[i] = remainingAmount / denominations[i];
					remainingAmount %= denominations[i];
					dispensedAmount += noteCount[i] * denominations[i];
				}
			}

			if (dispensedAmount > 0)
			{
				Console.WriteLine($"Requested Amount: {amount}");
				Console.WriteLine($"Dispensed Amount: {dispensedAmount}");
				PrintNotes(denominations, noteCount);
				Console.WriteLine("Exact change not available. Dispensed nearest possible amount.");
			}
			else
			{
				Console.WriteLine("Unable to dispense any amount.");
			}
		}

		// helper method to print result
		private static void PrintNotes(int[] denominations, int[] noteCount)
		{
			for (int i = 0; i < denominations.Length; i++)
			{
				if (noteCount[i] > 0)
				{
					Console.WriteLine($"INR {denominations[i]} x {noteCount[i]}");
				}
			}
		}
	}
}