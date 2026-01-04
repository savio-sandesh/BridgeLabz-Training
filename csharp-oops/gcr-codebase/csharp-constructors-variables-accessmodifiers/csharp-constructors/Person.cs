namespace BridgeLabzTraining.csharp_constructor
{
	// Person class
	// Shows how a copy constructor creates a duplicate object
	internal class Person
	{
		// Instance variables (encapsulated)
		private string personName;

		private int personAge;

		// Constructor to initialize a new Person object
		public Person(string personName, int personAge)
		{
			this.personName = personName;
			this.personAge = personAge;
		}

		// Copy constructor
		// Copies data from an existing Person object
		public Person(Person existingPerson)
		{
			this.personName = existingPerson.personName;
			this.personAge = existingPerson.personAge;
		}

		// Method to print person details
		public void PrintDetails()
		{
			Console.WriteLine("Person Name : " + personName);
			Console.WriteLine("Person Age  : " + personAge);
		}

		private static void Main(string[] args)
		{
			Console.WriteLine("Original person details:");
			Person firstPerson = new Person("Sandesh", 23);
			firstPerson.PrintDetails();

			Console.WriteLine();

			Console.WriteLine("Copied person details:");
			Person secondPerson = new Person(firstPerson);
			secondPerson.PrintDetails();

			Console.ReadLine();
		}
	}
}