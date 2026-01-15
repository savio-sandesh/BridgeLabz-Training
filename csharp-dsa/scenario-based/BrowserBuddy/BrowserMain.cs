namespace BrowserBuddy
{
	// Controls the application flow
	// Connects menu with browser operations
	internal class BrowserMain
	{
		// Starts the browser application
		public void Start()
		{
			IBrowser browser = new BrowserUtility();
			BrowserMenu menu = new BrowserMenu();
			int choice;

			do
			{
				// Display menu options
				menu.ShowMenu();

				// Read user choice
				Console.Write("Enter your choice: ");
				choice = Convert.ToInt32(Console.ReadLine());

				// Perform action based on user choice
				switch (choice)
				{
					case 1:
						browser.OpenTab();
						break;

					case 2:
						Console.Write("Enter URL: ");
						string url = Console.ReadLine();
						browser.VisitPage(url);
						break;

					case 3:
						browser.GoBack();
						break;

					case 4:
						browser.GoForward();
						break;

					case 5:
						browser.CloseTab();
						break;

					case 6:
						browser.RestoreTab();
						break;

					case 7:
						browser.ShowCurrentStatus();
						break;

					case 8:
						browser.ShowHistory();
						break;

					case 0:
						Console.WriteLine("Exiting BrowserBuddy...");
						break;

					default:
						Console.WriteLine("Invalid choice. Try again.");
						break;
				}
			} while (choice != 0);
		}
	}
}