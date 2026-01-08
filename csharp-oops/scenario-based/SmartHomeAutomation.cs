namespace BridgeLabzTraining.scenario_based
{
	// Smart Home Automation System demonstrating OOP concepts
	// Uses abstraction, interface, inheritance, and polymorphism

	internal class SmartHomeAutomation
	{
		public static void Main(string[] args)
		{
			List<IControllable> devices = new List<IControllable>();

			devices.Add(new Light("Study Room Light"));
			devices.Add(new AC("Living Room AC"));
			devices.Add(new Fan("Drawing Room Fan"));

			foreach (IControllable device in devices)
			{
				device.TurnOn();
				device.TurnOff();
				Console.WriteLine();
			}
		}
	}

	// Abstract base class for all appliances
	internal abstract class Appliance
	{
		protected string ElectricApplianceName { get; private set; }
		protected string ApplianceType { get; set; }

		public Appliance(string name)
		{
			ElectricApplianceName = name;
		}
	}

	// Interface defining controllable behavior
	internal interface IControllable
	{
		void TurnOn();

		void TurnOff();
	}

	// Light appliance
	internal class Light : Appliance, IControllable
	{
		private bool isOn = false;

		public Light(string name) : base(name)
		{
			ApplianceType = "Light";
		}

		public void TurnOn()
		{
			if (!isOn)
			{
				isOn = true;
				Console.WriteLine("Light is glowing.");
			}
			else
			{
				Console.WriteLine("Light is already ON.");
			}
		}

		public void TurnOff()
		{
			if (isOn)
			{
				isOn = false;
				Console.WriteLine("Light is turned OFF.");
			}
			else
			{
				Console.WriteLine("Light is already OFF.");
			}
		}
	}

	// Fan appliance
	internal class Fan : Appliance, IControllable
	{
		private bool isOn = false;

		public Fan(string name) : base(name)
		{
			ApplianceType = "Fan";
		}

		public void TurnOn()
		{
			if (!isOn)
			{
				isOn = true;
				Console.WriteLine("Fan is rotating.");
			}
			else
			{
				Console.WriteLine("Fan is already ON.");
			}
		}

		public void TurnOff()
		{
			if (isOn)
			{
				isOn = false;
				Console.WriteLine("Fan is turned OFF.");
			}
			else
			{
				Console.WriteLine("Fan is already OFF.");
			}
		}
	}

	// AC appliance
	internal class AC : Appliance, IControllable
	{
		private bool isOn = false;

		public AC(string name) : base(name)
		{
			ApplianceType = "AC";
		}

		public void TurnOn()
		{
			if (!isOn)
			{
				isOn = true;
				Console.WriteLine("AC is cooling.");
			}
			else
			{
				Console.WriteLine("AC is already ON.");
			}
		}

		public void TurnOff()
		{
			if (isOn)
			{
				isOn = false;
				Console.WriteLine("AC is turned OFF.");
			}
			else
			{
				Console.WriteLine("AC is already OFF.");
			}
		}
	}
}