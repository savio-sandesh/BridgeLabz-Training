// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

public class JsonToXml
{
    public static void Main(string[] args)
    {
        // Demonstrates conversion of JSON data into XML format

        Console.WriteLine("JSON -> XML Conversion\n");

        // Sample JSON input
        string json = @"{
            ""student"": {
                ""name"": ""Sneha"",
                ""age"": 19,
                ""marks"": [92, 88, 95],
                ""address"": {
                    ""city"": ""Vrindavan"",
                    ""pin"": 281121
                }
            }
        }";

        try
        {
            // Parse JSON into JObject
            JObject jsonObject = JObject.Parse(json);

            // Convert JSON structure into XML recursively
            XElement xml = ConvertJsonToXml(jsonObject, "root");

            Console.WriteLine("Converted XML:");
            Console.WriteLine(xml);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error converting JSON to XML: " + ex.Message);
        }

        Console.ReadKey();
    }

    // Recursively converts JSON tokens into XML elements
    private static XElement ConvertJsonToXml(JToken token, string elementName)
    {
        XElement element = new XElement(elementName);

        if (token is JObject obj)
        {
            foreach (JProperty property in obj.Properties())
            {
                element.Add(ConvertJsonToXml(property.Value, property.Name));
            }
        }
        else if (token is JArray array)
        {
            foreach (JToken item in array)
            {
                element.Add(ConvertJsonToXml(item, "item"));
            }
        }
        else
        {
            element.Value = token.ToString();
        }

        return element;
    }
}

