using System;


// FutureLogistics – Billing System

// This application automates billing for a transport company.
// It processes BrickTransport and TimberTransport records,
// selects a vehicle based on rules, applies tax and discounts,
// and calculates the final transport charge.



// Interface forces all transport types to follow same rules
public interface IGoodsTransport
{
    string VehicleSelection();
    float CalculateTotalCharge();
}


// Base class holding common transport details
public abstract class GoodsTransport : IGoodsTransport
{
    protected string transportId;
    protected string transportDate;
    protected int transportRating;

    // Constructor used by child classes
    public GoodsTransport(string transportId, string transportDate, int transportRating)
    {
        this.transportId = transportId;
        this.transportDate = transportDate;
        this.transportRating = transportRating;
    }

    // Returns discount percentage based on rating
    protected float GetDiscountPercentage()
    {
        if (transportRating == 5) return 0.20f;
        if (transportRating == 3 || transportRating == 4) return 0.10f;
        return 0.0f;
    }

    // Must be implemented by child classes
    public abstract string VehicleSelection();
    public abstract float CalculateTotalCharge();
}


// Handles brick-based transport billing
public class BrickTransport : GoodsTransport
{
    private float brickSize;
    private int brickQuantity;
    private float brickPrice;

    // Constructor for BrickTransport
    public BrickTransport(string transportId, string transportDate, int transportRating,
                          float brickSize, int brickQuantity, float brickPrice)
        : base(transportId, transportDate, transportRating)
    {
        this.brickSize = brickSize;
        this.brickQuantity = brickQuantity;
        this.brickPrice = brickPrice;
    }

    // Selects vehicle based on brick quantity
    public override string VehicleSelection()
    {
        if (brickQuantity < 300) return "Truck";
        if (brickQuantity <= 500) return "Lorry";
        return "MonsterLorry";
    }

    // Calculates total charge for brick transport
    public override float CalculateTotalCharge()
    {
        float price = brickPrice * brickQuantity;
        float tax = price * 0.30f;

        float vehiclePrice =
            VehicleSelection() == "Truck" ? 1000 :
            VehicleSelection() == "Lorry" ? 1700 : 3000;

        float discount = price * GetDiscountPercentage();
        return price + tax + vehiclePrice - discount;
    }
}


// Handles timber-based transport billing
public class TimberTransport : GoodsTransport
{
    private float timberLength;
    private float timberRadius;
    private string timberType;
    private float timberPrice;

    // Constructor for TimberTransport
    public TimberTransport(string transportId, string transportDate, int transportRating,
                           float timberLength, float timberRadius,
                           string timberType, float timberPrice)
        : base(transportId, transportDate, transportRating)
    {
        this.timberLength = timberLength;
        this.timberRadius = timberRadius;
        this.timberType = timberType;
        this.timberPrice = timberPrice;
    }

    // Selects vehicle based on timber area
    public override string VehicleSelection()
    {
        float area = 2 * 3.147f * timberRadius * timberLength;
        if (area < 250) return "Truck";
        if (area <= 400) return "Lorry";
        return "MonsterLorry";
    }

    // Calculates total charge for timber transport
    public override float CalculateTotalCharge()
    {
        float volume = 3.147f * timberRadius * timberRadius * timberLength;
        float rate = timberType.Equals("Premium", StringComparison.OrdinalIgnoreCase) ? 0.25f : 0.15f;
        float price = volume * timberPrice * rate;
        float tax = price * 0.30f;

        float vehiclePrice =
            VehicleSelection() == "Truck" ? 1000 :
            VehicleSelection() == "Lorry" ? 1700 : 3000;

        float discount = price * GetDiscountPercentage();
        return price + tax + vehiclePrice - discount;
    }
}


// Utility class for parsing and validation
public static class Utility
{
    // Converts input string into proper transport object
    public static GoodsTransport ParseDetails(string input)
    {
        string[] data = input.Split(':');
        string transportId = data[0];

        if (!ValidateTransportId(transportId))
        {
            Console.WriteLine("Transport id " + transportId + " is invalid");
            Console.WriteLine("Please provide a valid record");
            return null;
        }

        int rating = int.Parse(data[2]);
        string type = data[3];

        if (type.Equals("BrickTransport", StringComparison.OrdinalIgnoreCase))
            return new BrickTransport(transportId, data[1], rating,
                                      float.Parse(data[4]),
                                      int.Parse(data[5]),
                                      float.Parse(data[6]));

        return new TimberTransport(transportId, data[1], rating,
                                   float.Parse(data[4]),
                                   float.Parse(data[5]),
                                   data[6],
                                   float.Parse(data[7]));
    }

    // Checks transport ID format
    public static bool ValidateTransportId(string transportId)
    {
        if (transportId.Length != 7 || !transportId.StartsWith("RTS"))
            return false;

        for (int i = 3; i <= 5; i++)
            if (!char.IsDigit(transportId[i])) return false;

        return char.IsUpper(transportId[6]);
    }

    // Identifies the actual transport type
    public static string FindObjectType(GoodsTransport transport)
    {
        if (transport is BrickTransport) return "BrickTransport";
        if (transport is TimberTransport) return "TimberTransport";
        return "Unknown";
    }
}


// Main class to run the application
public class UserInterface
{
    public static void Main()
    {
        Console.WriteLine("Enter the Goods Transport details");
        string input = Console.ReadLine();

        GoodsTransport transport = Utility.ParseDetails(input);
        if (transport == null) return;

        Console.WriteLine("Transporter id : " + transport.transportId);
        Console.WriteLine("Date of transport : " + transport.transportDate);
        Console.WriteLine("Rating of the transport : " + transport.transportRating);
        Console.WriteLine("Vehicle for transport : " + transport.VehicleSelection());
        Console.WriteLine("Total charge : " + transport.CalculateTotalCharge().ToString("F2"));
    }
}
