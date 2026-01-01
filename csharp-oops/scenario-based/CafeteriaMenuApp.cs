namespace BridgeLabzTraining.scenario_based
{
	// CafeteriaMenuApp – Food Item Selector
	// The campus cafeteria offers 10 fixed items daily.
	// You need to build a system to display menu items and
	// take orders based on user input.
	internal class CafeteriaMenuApp
	{
		static void Main(string[] args)
		{
			// array used to store food items in cafeteria
			string[] foodList = { "Sandwich", "Pasta", "Pizza", "Burger", "Salad", "Cappuccino", "Latte", "Herbal Tea", "Soft Drink", "Shakes" };

			// welcome message to the user
			Console.WriteLine("Welcome to the Cafeteria Menu App!");

			// creating object of CafeteriaMenuApp class to access non static methods
			CafeteriaMenuApp app = new CafeteriaMenuApp();
			app.DisplayMenu(foodList);

			// asking user to enter item number
			Console.WriteLine("Please enter the item number to select your food:");
			// reading user input and validating it
			bool isValidInput = int.TryParse(Console.ReadLine()!, out int index);

			// if user input is not valid then exit the program
			if (!isValidInput)
			{
				Console.WriteLine("Invalid input. Please enter a valid item number.");
				return;
			}

			// display food item based on user input
			app.ReturnItemByIndex(foodList, index);

		}

		// method to display the cafeteria menu with item numbers
		void DisplayMenu(string[] foodList)
		{
			Console.WriteLine("Cafeteria Menu:");
			for (int i = 0; i < foodList.Length; i++)
			{
				Console.WriteLine($"{i + 1}. {foodList[i]}");
			}
		}

		// method validate the index and displays the selected food item
		void ReturnItemByIndex(string[] foodList, int index)
		{
			if (index < 1 || index > foodList.Length)
			{
				Console.WriteLine("Invalid index. Please select a valid item number.");
			}
			else
			{
				Console.WriteLine($"You selected: {foodList[index - 1]}");
			}
		}
	}
}
