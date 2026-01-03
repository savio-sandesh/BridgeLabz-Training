namespace BridgeLabzTraining.scenario_based
{
	// Festival Lucky Draw 🎉
	// Scenario-based program that simulates a festival lucky draw where each visitor
	// enters a number. If the number is divisible by both 3 and 5, the visitor wins a gift.
	// The program processes multiple visitors using a loop, skips invalid input, and
	// continues until no further visitor wants to participate.

	internal class FestivalLuckyDraw
	{
		// controls the lucky draw process
		private void LuckyDraw()
		{
			bool continueDrawing = true;

			while (continueDrawing)
			{
				int visitorNumber = GetVisitorNumber();

				if (visitorNumber == -1)
				{
					continue;
				}
				AnnounceWinner(visitorNumber);

				Console.WriteLine("Another visitor wants to try their luck? (yes/no):");
				string response = Console.ReadLine()!.Trim().ToLower();
				if (response != "yes")
				{
					continueDrawing = false;
				}
			}
		}

		// read and return the lucky number entered by the visitor
		private int GetVisitorNumber()
		{
			Console.WriteLine("Enter your Lucky Number:");

			//int number = int.Parse(Console.ReadLine()!);
			//if(number<=0){
			//	Console.WriteLine("Please enter a valid positive number.");
			//	return -1;
			//}

			// for safe input
			// we are using TryParse method
			// non - numeric → handled
			// negative / zero → handled
			// program never crashes

			string input = Console.ReadLine()!;

			if (!int.TryParse(input, out int number) || number <= 0)
			{
				Console.WriteLine("Please enter a valid positive number.");
				return -1;
			}

			return number;
		}

		// announces whether the visitor has won or not
		private void AnnounceWinner(int number)
		{
			if (number % 3 == 0 && number % 5 == 0)
			{
				Console.WriteLine("Hurrah! You Win");
			}
			else
			{
				Console.WriteLine("Better Luck Next Time");
			}
		}

		private static void Main(string[] args)
		{
			FestivalLuckyDraw luckyDraw = new FestivalLuckyDraw();
			luckyDraw.LuckyDraw();
		}
	}
}