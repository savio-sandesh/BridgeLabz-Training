namespace BrowserBuddy
{
	// Represents a browser tab
	// Holds basic information related to a tab
	internal class Tab
	{
		// Unique identifier for the tab
		public int TabId { get; set; }

		// Stores the current page URL of the tab
		public string CurrentUrl { get; set; }

		// Manages browsing history for this tab
		public HistoryManager HistoryManager { get; set; }

		// Returns a readable representation of the tab
		public override string ToString()
		{
			return $"TabId: {TabId}, CurrentUrl: {CurrentUrl}";
		}
	}
}