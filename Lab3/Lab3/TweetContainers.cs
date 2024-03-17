namespace lab3
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "TweetsContainer")]
    public class TweetsContainer
    {
        [XmlElement(ElementName = "Tweet")]
        public List<Tweet> Data { get; set; } = new List<Tweet>();
    }
}
