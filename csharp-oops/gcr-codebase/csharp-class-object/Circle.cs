namespace BridgeLabzTraining.csharp_class_object
{
	internal class Circle
	{
		// field to store radius of circle
		double radius;

		// Constructor to initialize circle object at creation time
		public Circle(double radius)
		{
			this.radius = radius;

		}

		// method to calculate area of circle
		double CalculateArea()
		{
			return Math.PI * radius * radius;
		}

		// method to calculate circumference of circle
		double CalculateCircumference()
		{
			return 2 * Math.PI * radius;
		}

		// method to display circle details
		void DisplayDetails()
		{
			Console.WriteLine("Radius of the circle is " + radius);
			Console.WriteLine("Area of the circle is " + CalculateArea());
			Console.WriteLine("Circumference of the circle is " + CalculateCircumference());
		}

		// entry point of the program
		static void Main(string[] args)
		{
			// read radius of circle from the user
			Console.WriteLine("Enter the radius of the circle:");
			double radiusOfCircle = double.Parse(Console.ReadLine()!);

			// creating circle object using user provided data 
			Circle circle = new Circle(radiusOfCircle);
			circle.DisplayDetails();
		}
	}
}
