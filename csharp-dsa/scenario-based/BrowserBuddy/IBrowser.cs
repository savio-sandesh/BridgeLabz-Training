namespace BrowserBuddy
{
	// Interface for browser operations
	// Provides abstraction for browser functionality
	internal interface IBrowser
	{
		// Opens a new browser tab
		void OpenTab();

		// Visits a new page in the current tab
		void VisitPage(string url);

		// Moves to the previous page in history
		void GoBack();

		// Moves to the next page in history
		void GoForward();

		// Closes the current tab
		void CloseTab();

		// Restores the most recently closed page
		void RestoreTab();

		// Displays the current browser status
		// Shows active tab and current page
		void ShowCurrentStatus();

		// Displays the page history of the current tab
		void ShowHistory();
	}
}