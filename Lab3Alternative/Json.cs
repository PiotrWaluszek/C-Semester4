using System.Text.Json;
public class JsonHandler {

    public Tweets ReadFromJson(string filePath) {
        string jsonString = File.ReadAllText(filePath);

        Tweets ?tweets = JsonSerializer.Deserialize<Tweets>(jsonString);

        return tweets;
    }    
}
