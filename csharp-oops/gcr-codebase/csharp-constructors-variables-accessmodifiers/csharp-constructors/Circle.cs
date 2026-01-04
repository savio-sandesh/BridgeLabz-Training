using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_constructor
{
	internal class Circle
	{
		// Circle Class
		// Demonstrates constructor chaining
		// Default and user-defined radius initialization

		private double radius;

		// Default constructor
		// Sets the default radius value to 1.0
		public Circle() : this(1.0)
		{
		}

		// Parameterized constructor
		public Circle(double radius)
		{
			this.radius = radius;
		}

		// Displays circle details
		public void DisplayDetails()
		{
			Console.WriteLine("Radius of circle: " + radius);
			Console.WriteLine("Area of circle: " + (3.14 * radius * radius));
		}

		private static void Main(string[] args)
		{
			Circle c1 = new Circle();
			c1.DisplayDetails();

			Console.WriteLine();

			Console.WriteLine("Enter radius for second circle:");
			double value = double.Parse(Console.ReadLine()!);

			Circle c2 = new Circle(value);
			c2.DisplayDetails();
		}
	}
}