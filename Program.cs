using System;
using System.IO;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        // Prompt user for JSON file path
        Console.Write("Please enter the JSON file path: ");
        string jsonFilePath = Console.ReadLine();

        // Read and print "iProvinceID" from "Data"
        string json = File.ReadAllText(jsonFilePath);
        dynamic data = JsonConvert.DeserializeObject(json);
        foreach (var entry in data.Data)
        {
            Console.WriteLine(entry.iProvinceID);
        }

        // Prompt user to convert to AOH2
        Console.Write("Do you wish to convert to AOH2? (y/n): ");
        string convertToAOH2 = Console.ReadLine();
        if (convertToAOH2.ToLower() == "y")
        {
            // Create MAP_POINTS.txt file
            using (StreamWriter file = new StreamWriter("convertMapData.txt"))
            {
                foreach (var entry in data.Data)
                {
                    string lPointsX = string.Join(",", entry.lPointsX);
                    string lPointsY = string.Join(",", entry.lPointsY);
                    file.WriteLine(lPointsX);
                    Console.WriteLine($"Written lPointsX for iProvinceID {entry.iProvinceID}");
                    file.WriteLine(lPointsY);
                    Console.WriteLine($"Written lPointsY for iProvinceID {entry.iProvinceID}");
                }
            }

            Console.WriteLine("MAP_POINTS.txt file has been created and saved in the same directory as the JSON file.");
        }
    }
}