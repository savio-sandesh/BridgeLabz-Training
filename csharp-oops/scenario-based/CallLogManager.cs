namespace BridgeLabzTraining.scenario_based
{
	internal class CallLogManager
	{
		private static void Main(string[] args)
		{
			CallLogcontroller controller = new CallLogcontroller(100);

			// Adding sample call logs
			controller.AddCallLog(new CallLog("Meeting at 10 AM", "123-456-7890",
												new DateTime(2024, 6, 1, 9, 0, 0)));
			controller.AddCallLog(new CallLog("Lunch with Sarah", "987-654-3210",
												new DateTime(2024, 6, 1, 12, 30, 0)));
			controller.AddCallLog(new CallLog("Project deadline", "555-555-5555",
												new DateTime(2024, 6, 2, 17, 0, 0)));

			// Searching by keyword
			controller.SearchByKeyword("Lunch");

			// Filtering by time range
			controller.FilterByTimeRange(new DateTime(2024, 6, 1, 0, 0, 0),
										new DateTime(2024, 6, 1, 23, 59, 59));

			Console.ReadLine();
		}
	}

	internal class CallLog
	{
		// private fields
		private string message;

		private string phoneNumber;
		private DateTime callTime;

		// public properties for accessing private fields
		public string Message
		{
			get { return message; }
			set { message = value; }
		}

		public string PhoneNumber
		{
			get { return phoneNumber; }
			set { phoneNumber = value; }
		}

		public DateTime CallTime
		{
			get { return callTime; }
			set { callTime = value; }
		}

		public CallLog(string message, string phoneNumber, DateTime callTime)
		{
			this.message = message;
			this.phoneNumber = phoneNumber;
			this.callTime = callTime;
		}
	}

	// manage call logs
	internal class CallLogcontroller
	{
		// array to store call logs
		private CallLog[] callLogs;

		private int callLogCount;

		// constructor
		public CallLogcontroller(int size)
		{
			callLogs = new CallLog[size];
			callLogCount = 0;
		}

		// add a new call log

		public void AddCallLog(CallLog log)
		{
			if (callLogCount < callLogs.Length)
			{
				callLogs[callLogCount] = log;
				callLogCount++;
			}
			else
			{
				Console.WriteLine("Call log storage is full.");
			}
		}

		// search call logs by keyword in message
		public void SearchByKeyword(string keyword)
		{
			Console.WriteLine($"Search results for keyword '{keyword}':");
			for (int i = 0; i < callLogCount; i++)
			{
				if (callLogs[i].Message.Contains(keyword, StringComparison.OrdinalIgnoreCase))
				{
					DisplayLog(callLogs[i]);
				}
			}
		}

		// filter call logs by time range
		public void FilterByTimeRange(DateTime startTime, DateTime endTime)
		{
			Console.WriteLine($"Call logs from {startTime} to {endTime}:");
			for (int i = 0; i < callLogCount; i++)
			{
				if (callLogs[i].CallTime >= startTime && callLogs[i].CallTime <= endTime)
				{
					DisplayLog(callLogs[i]);
				}
			}
		}

		// method to display call log details
		private void DisplayLog(CallLog log)
		{
			Console.WriteLine(
		$"Time    : {log.CallTime}\n" +
		$"Phone   : {log.PhoneNumber}\n" +
		$"Message : {log.Message}\n"
	);
		}
	}
}