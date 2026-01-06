namespace BridgeLabzTraining.scenario_based
{
	internal class BirdSanctuary
	{
		private static void Main(string[] args)
		{
			// array of bird objects
			Bird[] birds = new Bird[]
				{
					new Eagle("Eagle", "Brown", "Golden Eagle", 5, "Mountains"),
					new Sparrow("Sparrow", "Grey", "House Sparrow", 2, "Urban"),
					new Duck("Duck", "White", "Domestic Duck", 3, "Lake"),
					new Penguin("Penguin", "Black & White", "Emperor Penguin", 6, "Antarctica"),
					new Seagull("Seagull", "White", "Sea Gull", 4, "Coastal Area")
				};

			foreach (Bird bird in birds)
			{
				Console.WriteLine($"Bird Name: {bird.BirdName}, Species: {bird.BirdSpecies}, Age: {bird.BirdAge}, Habitat: {bird.BirdHabitat}");

				// polymorphic behavior based on bird capabilities (polymorphism)
				if (bird is IFly flyingBird)
				{
					flyingBird.Fly();
				}
				if (bird is ISwim swimmingBird)
				{
					swimmingBird.Swim();
				}
				Console.WriteLine();
			}
		}
	}

	internal class Bird
	{
		// private fields
		private string birdName;

		private string birdColor;
		private string birdSpecies;
		private int birdAge;
		private string birdHabitat;

		// public properties for accessing private fields
		public string BirdName
		{
			get { return birdName; }
			set { birdName = value; }
		}

		public string BirdColor
		{
			get { return birdColor; }
			set { birdColor = value; }
		}

		public string BirdSpecies
		{
			get { return birdSpecies; }
			set { birdSpecies = value; }
		}

		public int BirdAge
		{
			get { return birdAge; }
			set { birdAge = value; }
		}

		public string BirdHabitat
		{
			get { return birdHabitat; }
			set { birdHabitat = value; }
		}

		// constructor to initialize bird object
		public Bird(string name, string color, string species, int age, string habitat)
		{
			BirdName = name;
			BirdColor = color;
			BirdSpecies = species;
			BirdAge = age;
			BirdHabitat = habitat;
		}
	}

	// interfaces for bird behaviors
	internal interface IFly
	{
		void Fly();
	}

	internal interface ISwim
	{
		void Swim();
	}

	// inherited bird classes implementing behaviors(inheritance + interfaces)
	internal class Eagle : Bird, IFly
	{
		public Eagle(string name, string color, string species, int age, string habitat)
			: base(name, color, species, age, habitat)
		{
		}

		public void Fly()
		{
			Console.WriteLine($"{BirdName} is flying.");
		}
	}

	internal class Sparrow : Bird, IFly
	{
		public Sparrow(string name, string color, string species, int age, string habitat)
		: base(name, color, species, age, habitat)
		{
		}

		public void Fly()
		{
			Console.WriteLine($"{BirdName} is flying.");
		}
	}

	internal class Penguin : Bird, ISwim
	{
		public Penguin(string name, string color, string species, int age, string habitat)
		: base(name, color, species, age, habitat)
		{
		}

		public void Swim()
		{
			Console.WriteLine($"{BirdName} is swimming.");
		}
	}

	internal class Duck : Bird, ISwim
	{
		public Duck(string name, string color, string species, int age, string habitat)
		: base(name, color, species, age, habitat)
		{
		}

		public void Swim()
		{
			Console.WriteLine($"{BirdName} is swimming.");
		}
	}

	internal class Seagull : Bird, IFly, ISwim
	{
		public Seagull(string name, string color, string species, int age, string habitat)
				: base(name, color, species, age, habitat)
		{
		}

		public void Fly()
		{
			Console.WriteLine($"{BirdName} is flying.");
		}

		public void Swim()
		{
			Console.WriteLine($"{BirdName} is swimming.");
		}
	}
}