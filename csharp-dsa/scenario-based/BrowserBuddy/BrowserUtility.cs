namespace BrowserBuddy
{
	// Handles browser operations and application logic
	// Implements IBrowser interface
	internal class BrowserUtility : IBrowser
	{
		// Array to store opened tabs (max 10)
		private Tab[] tabs = new Tab[10];

		// Keeps track of number of open tabs
		private int tabCount = 0;

		// Points to the currently active tab
		private Tab currentTab;

		// Used to assign unique tab IDs
		private int tabCounter = 1;

		// Opens a new browser tab
		public void OpenTab()
		{
			if (tabCount >= tabs.Length)
			{
				Console.WriteLine("Maximum tab limit reached.");
				return;
			}

			Tab tab = new Tab
			{
				TabId = tabCounter++,
				HistoryManager = new HistoryManager()
			};

			tabs[tabCount++] = tab;
			currentTab = tab;

			Console.WriteLine($"New tab opened: {tab}");
		}

		// Visits a page in the current tab
		public void VisitPage(string url)
		{
			if (currentTab == null)
			{
				Console.WriteLine("No active tab. Please open a tab first.");
				return;
			}

			currentTab.HistoryManager.Visit(url);
			currentTab.CurrentUrl = url;

			Console.WriteLine($"Visited: {url}");
		}

		// Navigates to the previous page
		public void GoBack()
		{
			if (currentTab == null)
				return;

			string url = currentTab.HistoryManager.GoBack();
			if (url != null)
			{
				currentTab.CurrentUrl = url;
				Console.WriteLine($"Back to: {url}");
			}
			else
			{
				Console.WriteLine("No previous page.");
			}
		}

		// Navigates to the next page
		public void GoForward()
		{
			if (currentTab == null)
				return;

			string url = currentTab.HistoryManager.GoForward();
			if (url != null)
			{
				currentTab.CurrentUrl = url;
				Console.WriteLine($"Forward to: {url}");
			}
			else
			{
				Console.WriteLine("No next page.");
			}
		}

		// Closes the current tab
		public void CloseTab()
		{
			if (currentTab == null)
				return;

			Console.WriteLine($"Tab closed: {currentTab}");

			tabCount--;
			tabs[tabCount] = null;
			currentTab = tabCount > 0 ? tabs[tabCount - 1] : null;
		}

		// Displays browsing history of the current tab
		public void ShowHistory()
		{
			if (currentTab == null)
			{
				Console.WriteLine("No active tab.");
				return;
			}

			currentTab.HistoryManager.ShowHistory();
		}

		// Displays the current tab and page information
		public void ShowCurrentStatus()
		{
			if (currentTab == null)
			{
				Console.WriteLine("No active tab.");
				return;
			}

			Console.WriteLine("=== Current Status ===");
			Console.WriteLine($"Tab ID     : {currentTab.TabId}");
			Console.WriteLine($"Current URL: {currentTab.CurrentUrl ?? "No page visited"}");
		}

		// Restore feature placeholder
		public void RestoreTab()
		{
			Console.WriteLine("Restore tab feature is not implemented without collections.");
		}
	}
}