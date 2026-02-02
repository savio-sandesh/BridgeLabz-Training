// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Collections.Generic;

public class JsonValidate
{
    public static void Main(string[] args)
    {
        // Validate JSON structure using Newtonsoft.Json.Schema

        Console.WriteLine("JSON Schema Validation\n");

        string json = @"{
            ""name"": ""Sneha"",
            ""age"": 19,
            ""email"": ""sneha@gmail.com""
        }";

        string schemaJson = @"{
            ""type"": ""object"",
            ""properties"": {
                ""name"": { ""type"": ""string"" },
                ""age"": { ""type"": ""integer"", ""minimum"": 18 },
                ""email"": { ""type"": ""string"", ""format"": ""email"" }
            },
            ""required"": [""name"", ""age"", ""email""]
        }";

        try
        {
            JSchema schema = JSchema.Parse(schemaJson);
            JObject jsonObject = JObject.Parse(json);

            bool isValid = jsonObject.IsValid(schema, out IList<string> errors);

            if (isValid)
            {
                Console.WriteLine("JSON is VALID");
            }
            else
            {
                Console.WriteLine("JSON is INVALID");
                foreach (string error in errors)
                {
                    Console.WriteLine("- " + error);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error validating JSON: " + ex.Message);
        }

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
