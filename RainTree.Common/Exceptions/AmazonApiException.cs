using System;
using System.Xml.Serialization;

namespace RainTree.Common.Exceptions
{
    [XmlTypeAttribute(Namespace = "http://mws.amazonaws.com/doc/2009-01-01/")]
    [XmlRootAttribute(Namespace = "http://mws.amazonaws.com/doc/2009-01-01/", IsNullable = false)]
    public class AmazonError
    {
        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "Code")]
        public string Code { get; set; }
        [XmlElement(ElementName = "Message")]
        public string Message { get; set; }
        [XmlElementAttribute(ElementName = "Detail")]
        public Object Detail { get; set; }
    }

    [XmlTypeAttribute(Namespace = "http://mws.amazonaws.com/doc/2009-01-01/")]
    [XmlRootAttribute(Namespace = "http://mws.amazonaws.com/doc/2009-01-01/", IsNullable = false)]
    public class AmazonErrorResponse
    {
        [XmlElement(ElementName = "Error")]
        public AmazonError Error { get; set; }
        [XmlElement(ElementName = "RequestID")]
        public string RequestID { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }
}
