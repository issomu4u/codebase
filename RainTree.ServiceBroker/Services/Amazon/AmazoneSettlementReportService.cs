using CsvHelper.Configuration;
using RainTree.Common.Dtos.Mws;
using System;
using System.Collections.Generic;

namespace RainTree.ServiceBroker.Services.Amazon
{
    public class AmazoneSettlementReportService
    {
        public GetReportListResponse GetSettlementReports(AmzaonParamDto paramDto, string nextToken, DateTime avaliableFromDate, DateTime availableToDate)
        {
            var amazonReportService = new AmazonReportService(paramDto.AWSAccessKeyId, paramDto.SecretKey, paramDto.SellerId, paramDto.Domain);

            if (availableToDate > DateTime.Now)
                availableToDate = DateTime.Now.AddMinutes(-15);

            //Log.Debug($"Amazon report request with NextToken : {nextToken}, marketPlaceId : {paramDto.MarketPlaceId}, avaliableFromDate :{avaliableFromDate} , availableToDate :{availableToDate} ");

            var replortList = string.IsNullOrWhiteSpace(nextToken) ?
                    amazonReportService.GetReportList(new string[] { paramDto.MarketPlaceId },
                     //  createdAfter: createdAfter == null ? "" : createdAfter.Value.ToString("yyyy'-'MM'-'ddTHH':'mm':'ssZ"),
                     availableFromDate: avaliableFromDate.ToString("yyyy'-'MM'-'ddTHH':'mm':'ssZ"),
                     availableToDate: availableToDate.ToString("yyyy'-'MM'-'ddTHH':'mm':'ssZ"),
                     reportTypes: new string[] { "_GET_V2_SETTLEMENT_REPORT_DATA_FLAT_FILE_" })
                    : amazonReportService.GetReportListByNextToken(nextToken);

            return replortList;
        }

        public IEnumerable<AmazonSettlementCsvReportRow> GetSettlementsFromCsvReport(AmzaonParamDto paramDto, string reportId)
        {

            var amazonReportService = new AmazonReportService(paramDto.AWSAccessKeyId, paramDto.SecretKey, paramDto.SellerId, paramDto.Domain);

            //Log.Debug($"Amazon settlement data for report Id : {reportId}, sellerId : {paramDto.SellerId} , marketPlaceId : {paramDto.MarketPlaceId}");

            var csvConfig = new Configuration();
            csvConfig.RegisterClassMap<AmazonSettlementReportCsvMap>();
            csvConfig.HasHeaderRecord = true;
            csvConfig.Delimiter = "\t";
            //csvConfig.MissingFieldFound = (headerNames, index, context) =>
            //{
            //    Log.Debug($"Field with names ['{string.Join("', '", headerNames)}'] at index '{index}' was not found. ");
            //};

            var reportData = amazonReportService.GetSettlementFromCsvReport<AmazonSettlementCsvReportRow>(csvConfig, reportId);

            return reportData;

        }

        public string GetSettlementDataFromCsvReport(AmzaonParamDto paramDto, string reportId)
        {

            var amazonReportService = new AmazonReportService(paramDto.AWSAccessKeyId, paramDto.SecretKey, paramDto.SellerId, paramDto.Domain);
            //Log.Debug($"Amazon settlement data for report Id : {reportId}, sellerId : {paramDto.SellerId} , marketPlaceId : {paramDto.MarketPlaceId}");

            var reportData = amazonReportService.GetReportDataByReportId(reportId);
            return reportData;

        }

    }
}
