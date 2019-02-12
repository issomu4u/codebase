using CsvHelper.Configuration;
using RainTree.Common.Dtos.Mws;
using RainTree.Common.Extentions;
using RainTree.Common.ServiceClient;
using System.Collections.Generic;
using System.Net;

namespace RainTree.ServiceBroker.Services.Amazon
{
    public interface IAmazonReportService : IAmazonBaseService
    {
        GetReportListResponse GetReportList(string[] marketplaceIds, string availableFromDate = null, string availableToDate = null, string[] reportTypes = null);
        GetReportListResponse GetReportListByNextToken(string token);
        SettlementEnvelope GetSettlementsByReportId(string reportId);
        IEnumerable<T> GetSettlementFromCsvReport<T>(Configuration csvConfiguraiton, string reportId);
        string GetReportDataByReportId(string reportId);

    }

    public class AmazonReportService : AmazonBaseService, IAmazonReportService
    {
        public override string URI { get { return "/"; } }
        public override string VERSION { get { return "2009-01-01"; } }
        public override string NS { get { return "{http://mws.amazonaws.com/doc/2009-01-01}"; } }

        //public AmazonReportService() : base("", "", "")
        //{

        //}
        public AmazonReportService(string accessKey, string secretKey, string accountId,
            string domain = null, string uri = null, string version = null)
            : base(accessKey, secretKey, accountId, domain, uri, version)
        { }

        public GetReportListResponse GetReportList(string[] marketplaceIds, string availableFromDate = null, string availableToDate = null, string[] reportTypes = null)
        {
            var data = new Dictionary<string, string>() {
                {"Action", "GetReportList"},
                {"AvailableFromDate", availableFromDate},
                {"AvailableToDate", availableToDate}
            };
            data.Update(EnumerateParam("ReportTypeList.Type.", reportTypes));
            return GetResponseFromXml<GetReportListResponse>(data, WebRequestMethods.Http.Post);
        }

        public GetReportListResponse GetReportListByNextToken(string token)
        {
            var data = new Dictionary<string, string>() {
                {"Action", "GetReportListByNextToken"},
                {"NextToken", token},
            };
            var result = GetResponseFromXml<GetReportListByNextTokenResponse>(data, WebRequestMethods.Http.Post);

            if (result == null)
                return null;

            var castedResult = new GetReportListResponse
            {
                GetReportListResult = new GetReportListResult
                {
                    HasNext = result.GetReportListByNextTokenResult.HasNext,
                    NextToken = result.GetReportListByNextTokenResult.NextToken,
                    ReportInfo = result.GetReportListByNextTokenResult.ReportInfo
                },
                ResponseMetadata = result.ResponseMetadata,
                Xmlns = result.Xmlns
            };
            return castedResult;
        }

        public SettlementEnvelope GetSettlementsByReportId(string reportId)
        {
            var data = new Dictionary<string, string>() {
                {"Action", "GetReport"},
                {"ReportId", reportId},
            };
            return GetResponseFromXml<SettlementEnvelope>(data, WebRequestMethods.Http.Post);
        }
        public string GetReportDataByReportId(string reportId)
        {
            var data = new Dictionary<string, string>() {
                {"Action", "GetReport"},
                {"ReportId", reportId},
            };
            return GetReportData(data, WebRequestMethods.Http.Post);
        }

        public IEnumerable<T> GetSettlementFromCsvReport<T>(Configuration configuation, string reportId)
        {
            var data = new Dictionary<string, string>() {
                {"Action", "GetReport"},
                {"ReportId", reportId},
            };
            return GetResponseFromCsv<T>(data, WebRequestMethods.Http.Post, configuation);
        }

    }
}
