using System;
using System.Collections.Generic;
using System.Linq;

/// Represents engagement statistics of a content creator on StreamBuzz.
/// Stores creator name and weekly like counts.
public class CreatorStats
{
    /// Name of the content creator.
    public string CreatorName { get; set; }

    /// Stores weekly like counts for exactly four weeks.
    public double[] WeeklyLikes { get; set; }

    /// Central list that stores all registered creators.
    /// Shared across the application.
    public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();
}

/// Main program class that handles business logic and user interaction.
public class Program
{
    /// Registers a creator record into the engagement board.
    public void RegisterCreator(CreatorStats record)
    {
        CreatorStats.EngagementBoard.Add(record);
    }

    /// Returns creators whose weekly likes meet or exceed the given threshold.
    /// The value represents the number of weeks meeting the threshold.
    public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();

        foreach (CreatorStats creator in records)
        {
            int count = creator.WeeklyLikes.Count(like => like >= likeThreshold);

            if (count > 0)
            {
                result.Add(creator.CreatorName, count);
            }
        }

        return result;
    }

    /// Calculates the overall average weekly likes across all creators.
    public double CalculateAverageLikes()
    {
        double totalLikes = 0;
        int totalWeeks = 0;

        foreach (CreatorStats creator in CreatorStats.EngagementBoard)
        {
            totalLikes += creator.WeeklyLikes.Sum();
            totalWeeks += creator.WeeklyLikes.Length;
        }

        return totalWeeks == 0 ? 0 : totalLikes / totalWeeks;
    }

    /// Entry point of the StreamBuzz application.
    /// Displays a menu-driven console interface.
    public static void Main(string[] args)
    {
        Program program = new Program();

        while (true)
        {
            Console.WriteLine("1. Register Creator");
            Console.WriteLine("2. Show Top Posts");
            Console.WriteLine("3. Calculate Average Likes");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice:");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 4)
            {
                Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                break;
            }

            if (choice == 1)
            {
                Console.WriteLine("Enter Creator Name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter weekly likes (Week 1 to 4):");
                double[] likes = new double[4];

                for (int i = 0; i < 4; i++)
                {
                    likes[i] = double.Parse(Console.ReadLine());
                }

                CreatorStats creator = new CreatorStats
                {
                    CreatorName = name,
                    WeeklyLikes = likes
                };

                program.RegisterCreator(creator);
                Console.WriteLine("Creator registered successfully");
            }
            else if (choice == 2)
            {
                Console.WriteLine("Enter like threshold:");
                double threshold = double.Parse(Console.ReadLine());

                Dictionary<string, int> topCreators =
                    program.GetTopPostCounts(CreatorStats.EngagementBoard, threshold);

                if (topCreators.Count == 0)
                {
                    Console.WriteLine("No top-performing posts this week");
                }
                else
                {
                    foreach (var entry in topCreators)
                    {
                        Console.WriteLine($"{entry.Key} - {entry.Value}");
                    }
                }
            }
            else if (choice == 3)
            {
                double average = program.CalculateAverageLikes();
                Console.WriteLine($"Overall average weekly likes: {average}");
            }
        }
    }
}
