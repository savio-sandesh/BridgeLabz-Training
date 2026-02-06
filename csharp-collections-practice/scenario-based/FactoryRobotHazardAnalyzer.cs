using System;


// Factory Robot Hazard Analyzer

// This program evaluates the hazard risk of a factory robot
// based on arm precision, worker density, and machinery state.
// It validates inputs, calculates risk, and handles errors
// using a custom exception.



// Custom exception used for robot safety validation errors
public class RobotSafetyException : Exception
{
    public RobotSafetyException(string message) : base(message)
    {
        // Message is passed to base Exception
    }
}


// Auditor class that performs hazard risk calculation
public class RobotHazardAuditor
{
    // Calculates and returns the robot hazard risk score
    public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
    {
        // Validate arm precision range
        if (armPrecision < 0.0 || armPrecision > 1.0)
        {
            throw new RobotSafetyException("Error: Arm precision must be 0.0-1.0");
        }

        // Validate worker density range
        if (workerDensity < 1 || workerDensity > 20)
        {
            throw new RobotSafetyException("Error: Worker density must be 1-20");
        }

        // Determine machine risk factor
        double machineRiskFactor;
        if (machineryState == "Worn")
        {
            machineRiskFactor = 1.3;
        }
        else if (machineryState == "Faulty")
        {
            machineRiskFactor = 2.0;
        }
        else if (machineryState == "Critical")
        {
            machineRiskFactor = 3.0;
        }
        else
        {
            throw new RobotSafetyException("Error: Unsupported machinery state");
        }

        // Apply hazard risk formula
        double hazardRisk = ((1.0 - armPrecision) * 15.0)
                            + (workerDensity * machineRiskFactor);

        return hazardRisk;
    }
}


// User interface class with Main method
public class UserInterface
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Factory Robot Hazard Analyzer");

        RobotHazardAuditor auditor = new RobotHazardAuditor();

        try
        {
            // Read arm precision input
            Console.Write("Enter Arm Precision (0.0 - 1.0): ");
            double armPrecision = double.Parse(Console.ReadLine().Trim());

            // Read worker density input
            Console.Write("Enter Worker Density (1 - 20): ");
            int workerDensity = int.Parse(Console.ReadLine().Trim());

            // Read machinery state input
            Console.Write("Enter Machinery State (Worn/Faulty/Critical): ");
            string machineryState = Console.ReadLine().Trim();

            // Calculate hazard risk
            double risk = auditor.CalculateHazardRisk(
                armPrecision, workerDensity, machineryState);

            // Display result
            Console.WriteLine($"\nRobot Hazard Risk Score: {risk}");
        }
        catch (RobotSafetyException ex)
        {
            // Displays validation error messages
            Console.WriteLine(ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input format. Please enter valid numbers.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
