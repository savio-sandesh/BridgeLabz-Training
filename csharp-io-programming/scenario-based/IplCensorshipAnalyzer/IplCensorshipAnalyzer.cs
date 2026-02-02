// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IPL_Censorship_Analyzer
{
    class Program
    {
        // Application entry point
        static void Main(string[] args)
        {
            Console.WriteLine("IPL and Censorship Analyzer");

            // Process JSON input
            Console.WriteLine("Processing JSON input...");
            string jsonInputPath = "ipl_matches.json";
            CreateDummyJsonFile(jsonInputPath);

            string censoredJson = ProcessJsonFile(jsonInputPath);
            string censoredJsonPath = "censored_ipl_matches.json";
            File.WriteAllText(censoredJsonPath, censoredJson);

            Console.WriteLine($"Censored JSON saved to: {censoredJsonPath}\n");

            // Process CSV input
            Console.WriteLine("Processing CSV input...");
            string csvInputPath = "ipl_matches.csv";
            CreateDummyCsvFile(csvInputPath);

            string censoredCsv = ProcessCsvFile(csvInputPath);
            string censoredCsvPath = "censored_ipl_matches.csv";
            File.WriteAllText(censoredCsvPath, censoredCsv);

            Console.WriteLine($"Censored CSV saved to: {censoredCsvPath}\n");

            Console.WriteLine("Processing complete. Press any key to exit...");
            Console.ReadKey();
        }

        // Masks the team name by replacing the last word with ***
        static string MaskTeamName(string teamName)
        {
            if (string.IsNullOrWhiteSpace(teamName))
                return teamName;

            string[] parts = teamName.Split(' ');
            if (parts.Length <= 1)
                return teamName;

            parts[parts.Length - 1] = "***";
            return string.Join(" ", parts);
        }

        // Replaces player name with a redacted value
        static string RedactPlayerName(string name)
        {
            return "REDACTED";
        }

        // Reads and processes IPL match data from a JSON file
        static string ProcessJsonFile(string inputPath)
        {
            string json = File.ReadAllText(inputPath);
            JArray matches = JArray.Parse(json);

            foreach (JObject match in matches)
            {
                // Mask team names
                match["team1"] = MaskTeamName((string)match["team1"]);
                match["team2"] = MaskTeamName((string)match["team2"]);

                // Mask winner name
                match["winner"] = MaskTeamName((string)match["winner"]);

                // Redact player of the match
                match["player_of_match"] = RedactPlayerName((string)match["player_of_match"]);

                // Mask team names inside score object keys
                JObject score = (JObject)match["score"];
                if (score != null)
                {
                    JObject maskedScore = new JObject();
                    foreach (JProperty prop in score.Properties())
                    {
                        maskedScore[MaskTeamName(prop.Name)] = prop.Value;
                    }
                    match["score"] = maskedScore;
                }
            }

            return matches.ToString(Formatting.Indented);
        }

        // Reads and processes IPL match data from a CSV file
        static string ProcessCsvFile(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);
            StringBuilder output = new StringBuilder();

            // Preserve CSV header
            output.AppendLine(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] columns = lines[i].Split(',');

                if (columns.Length < 7)
                    continue;

                // Apply censorship rules
                columns[1] = MaskTeamName(columns[1]);
                columns[2] = MaskTeamName(columns[2]);
                columns[5] = MaskTeamName(columns[5]);
                columns[6] = RedactPlayerName(columns[6]);

                output.AppendLine(string.Join(",", columns));
            }

            return output.ToString();
        }

        // Creates a dummy JSON file for testing
        static void CreateDummyJsonFile(string path)
        {
            var data = new[]
            {
                new
                {
                    match_id = 101,
                    team1 = "Mumbai Indians",
                    team2 = "Chennai Super Kings",
                    score = new Dictionary<string, int>
                    {
                        { "Mumbai Indians", 178 },
                        { "Chennai Super Kings", 182 }
                    },
                    winner = "Chennai Super Kings",
                    player_of_match = "MS Dhoni"
                },
                new
                {
                    match_id = 102,
                    team1 = "Royal Challengers Bangalore",
                    team2 = "Delhi Capitals",
                    score = new Dictionary<string, int>
                    {
                        { "Royal Challengers Bangalore", 200 },
                        { "Delhi Capitals", 190 }
                    },
                    winner = "Royal Challengers Bangalore",
                    player_of_match = "Virat Kohli"
                }
            };

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(path, json);

            Console.WriteLine("Dummy JSON file created: " + path);
        }

        // Creates a dummy CSV file for testing
        static void CreateDummyCsvFile(string path)
        {
            string[] lines =
            {
                "match_id,team1,team2,score_team1,score_team2,winner,player_of_match",
                "101,Mumbai Indians,Chennai Super Kings,178,182,Chennai Super Kings,MS Dhoni",
                "102,Royal Challengers Bangalore,Delhi Capitals,200,190,Royal Challengers Bangalore,Virat Kohli"
            };

            File.WriteAllLines(path, lines);
            Console.WriteLine("Dummy CSV file created: " + path);
        }
    }
}
