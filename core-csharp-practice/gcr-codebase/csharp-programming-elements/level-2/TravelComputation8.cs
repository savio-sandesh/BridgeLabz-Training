using System;

class TravelComputation8 {
   public static void Main(string[] args) {

      // Create a variable 'name' to indicate the person traveling
	  // Take passenger name as an input
	  Console.WriteLine("Enter the Name of the passenger: ");
      string name = Console.ReadLine();
      
      // Create variables 'fromCity', 'viaCity', and 'toCity' for the cities
      Console.WriteLine("Enter the Name of the City From which Passenger Start To Travel: ");
	  string fromCity = Console.ReadLine();
	  
	  Console.WriteLine("Enter the Name of the City via Passenger Travel: ");
	  string viaCity = Console.ReadLine();
	  
	  Console.WriteLine("Enter the Name of the Destination City of The Passenger : ");
	  string toCity = Console.ReadLine();

      // Create variables for distances and times
      double distanceFromToVia = 156.6;
      int timeFromToVia = 4 * 60 + 4; // Time in minutes
      double distanceViaToFinalCity = 211.8;
      int timeViaToFinalCity = 4 * 60 + 25; // Time in minutes

      // Compute the total distance and total time
      double totalDistance = distanceFromToVia + distanceViaToFinalCity;
      int totalTime = timeFromToVia + timeViaToFinalCity;

      // Print the travel details
      Console.WriteLine("The Total Distance travelled by "+ name +
	  " from " + fromCity+ 
	  " to  "+toCity + 
	  " via " +viaCity +
	  " is "+ totalDistance +  
	  " km and the Total Time taken is "+ totalTime + " minutes");
   }
}
