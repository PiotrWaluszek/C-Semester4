namespace lab3
{
    using System.Xml.Serialization;

    public class Tweet
    {
        [XmlElement(ElementName = "Text")]
        public string? Text { get; set; }

        [XmlElement(ElementName = "UserName")]
        public string? UserName { get; set; }

        [XmlElement(ElementName = "LinkToTweet")]
        public string? LinkToTweet { get; set; }

        [XmlElement(ElementName = "FirstLinkUrl")]
        public string? FirstLinkUrl { get; set; }

        [XmlElement(ElementName = "CreatedAt")]
        public string? CreatedAt { get; set; }

        [XmlElement(ElementName = "TweetEmbedCode")]
        public string? TweetEmbedCode { get; set; }
    }
}
