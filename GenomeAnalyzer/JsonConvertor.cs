using System.Text.Json;
using System.Text.Json.Nodes;

namespace GenomeAnalyzer;

public class JsonConvertor
{
    public static JsonArray ToJsonArray(Genome genome)
    {
        var jsonArray = new JsonArray();

        foreach (var gene in genome)
        {
            jsonArray.Add(JsonObject.Parse(JsonSerializer.Serialize(gene)));
        }

        return jsonArray;
    }
}