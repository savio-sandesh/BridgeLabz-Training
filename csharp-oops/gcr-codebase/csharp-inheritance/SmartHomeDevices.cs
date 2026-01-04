namespace BridgeLabzTraining.csharp_inheritance
{
	// device class
	// acts as the superclass
	internal class Device
	{
		public string DeviceId;
		public string Status;
	}

	// thermostat class
	// inherits from device (single inheritance)
	internal class Thermostat : Device
	{
		public int TemperatureSetting;

		// displays device status
		public void DisplayStatus()
		{
			Console.WriteLine("Device Id          : " + DeviceId);
			Console.WriteLine("Device Status      : " + Status);
			Console.WriteLine("Temperature Setting: " + TemperatureSetting);
		}
	}

	internal class SmartHomeDevices
	{
		private static void Main()
		{
			// creating thermostat object
			Thermostat thermostat = new Thermostat();

			thermostat.DeviceId = "TH-101";
			thermostat.Status = "On";
			thermostat.TemperatureSetting = 24;

			thermostat.DisplayStatus();

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();
		}
	}
}