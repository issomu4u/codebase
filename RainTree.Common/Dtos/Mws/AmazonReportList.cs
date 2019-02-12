using System.Collections.Generic;
using System.Xml.Serialization;

namespace RainTree.Common.Dtos.Mws
{
    [XmlRoot(ElementName = "ReportInfo", Namespace = "http://mws.amazonaws.com/doc/2009-01-01/")]
    public class ReportInfo
    {
        [XmlElement(ElementName = "ReportType", Namespace = "http://mws.amazonaws.com/doc/2009-01-01/")]
        public string ReportType { get; set; }
        [XmlElement(ElementName = "Acknowledged", Namespace = "http://mws.amazonaws.com/doc/2009-01-01/")]
        public string Acknowledged { get; set; }
        [XmlElement(ElementName = "ReportId", Namespace = "http://mws.amazonaws.com/doc/2009-01-01/")]
        public string ReportId { get; set; }
        [XmlElement(ElementName = "ReportRequestId", Namespace = "http://mws.amazonaws.com/doc/2009-01-01/")]
        public string ReportRequestId { get; set; }
        [XmlElement(ElementName = "AvailableDate", Namespace = "http://mws.amazonaws.com/doc/2009-01-01/")]
        public string AvailableDate { get; set; }
    }

    [XmlRoot(ElementName = "GetReportListResult", Namespace = "http://mws.amazonaws.com/doc/2009-01-01/")]
    public class GetReportListResult
    {
        [XmlElement(ElementName = "HasNext", Namespace = "http://mws.amazonaws.com/doc/2009-01-01/")]
        public string HasNext { get; set; }
        [XmlElement(ElementName = "NextToken", Namespace = "http://mws.amazonaws.com/doc/2009-01-01/")]
        public string NextToken { get; set; }
        [XmlElement(ElementName = "ReportInfo", Namespace = "http://mws.amazonaws.com/doc/2009-01-01/")]
        public List<ReportInfo> ReportInfo { get; set; }
    }

    [XmlRoot(ElementName = "ResponseMetadata", Namespace = "http://mws.amazonaws.com/doc/2009-01-01/")]
    public class ReportResponseMetadata
    {
        [XmlElement(ElementName = "RequestId", Namespace = "http://mws.amazonaws.com/doc/2009-01-01/")]
        public string RequestId { get; set; }
    }

    [XmlRoot(ElementName = "GetReportListResponse", Namespace = "http://mws.amazonaws.com/doc/2009-01-01/")]
    public class GetReportListResponse
    {
        [XmlElement(ElementName = "GetReportListResult", Namespace = "http://mws.amazonaws.com/doc/2009-01-01/")]
        public GetReportListResult GetReportListResult { get; set; }
        [XmlElement(ElementName = "ResponseMetadata", Namespace = "http://mws.amazonaws.com/doc/2009-01-01/")]
        public ReportResponseMetadata ResponseMetadata { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }

    [XmlRoot(ElementName = "GetReportListByNextTokenResult", Namespace = "http://mws.amazonaws.com/doc/2009-01-01/")]
    public class GetReportListByNextTokenResult
    {
        [XmlElement(ElementName = "HasNext", Namespace = "http://mws.amazonaws.com/doc/2009-01-01/")]
        public string HasNext { get; set; }
        [XmlElement(ElementName = "NextToken", Namespace = "http://mws.amazonaws.com/doc/2009-01-01/")]
        public string NextToken { get; set; }
        [XmlElement(ElementName = "ReportInfo", Namespace = "http://mws.amazonaws.com/doc/2009-01-01/")]
        public List<ReportInfo> ReportInfo { get; set; }
    }


    [XmlRoot(ElementName = "GetReportListByNextTokenResponse", Namespace = "http://mws.amazonaws.com/doc/2009-01-01/")]
    public class GetReportListByNextTokenResponse
    {
        [XmlElement(ElementName = "GetReportListByNextTokenResult", Namespace = "http://mws.amazonaws.com/doc/2009-01-01/")]
        public GetReportListByNextTokenResult GetReportListByNextTokenResult { get; set; }
        [XmlElement(ElementName = "ResponseMetadata", Namespace = "http://mws.amazonaws.com/doc/2009-01-01/")]
        public ReportResponseMetadata ResponseMetadata { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }
}
