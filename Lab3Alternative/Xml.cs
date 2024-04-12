using System.Xml.Serialization;
public class XmlHandler {

    public void WriteToXml(string filePath, Tweets tweets) {
        XmlSerializer serializer = new XmlSerializer(typeof(Tweets));
        using (StreamWriter writer = File.CreateText(filePath))
        {
            serializer.Serialize(writer, tweets);
        }
    }

    public Tweets ReadFromXml(string filePath) {
        Tweets ?tweets = null;
        XmlSerializer serializer = new XmlSerializer(typeof(Tweets));
        
        using (StreamReader reader = new StreamReader(filePath)) {
            tweets = (Tweets)serializer.Deserialize(reader);
        }
        return tweets;
    }
}
