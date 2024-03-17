namespace lab3
{
    using System.IO;
    using System.Xml.Serialization;

    public class XmlDataHandler
    {
        public static void SaveTweetsToXml(string filePath, TweetsContainer tweets)
        {
            var serializer = new XmlSerializer(typeof(TweetsContainer));
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, tweets);
            }
        }

        public static TweetsContainer LoadTweetsFromXml(string filePath)
        {
            var serializer = new XmlSerializer(typeof(TweetsContainer));
            using (var reader = new StreamReader(filePath))
            {
                return (TweetsContainer)serializer.Deserialize(reader);
            }
        }
    }
}
