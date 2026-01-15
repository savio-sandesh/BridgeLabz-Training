namespace BrowserBuddy
{
	// Displays menu options to the user
	// Handles only menu presentation
	internal class BrowserMenu
	{
		// Shows the browser menu on the console
		public void ShowMenu()
		{
			Console.WriteLine("\nBrowserBuddy Menu:");
			Console.WriteLine("1. Open New Tab");
			Console.WriteLine("2. Visit Page");
			Console.WriteLine("3. Back");
			Console.WriteLine("4. Forward");
			Console.WriteLine("5. Close Tab");
			Console.WriteLine("6. Restore Page");
			Console.WriteLine("7. Show Current Status");
			Console.WriteLine("8. Show Page History");
			Console.WriteLine("0. Exit");
		}
	}
}