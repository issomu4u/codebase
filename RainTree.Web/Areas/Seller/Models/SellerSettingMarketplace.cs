using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SellerVendor.Areas.Seller.Models
{
    [Table("SellerSettingMarketplace")]
    public class SellerSettingMarketplaceEntity
    {
        [Key]
        public int ID { get; set; }
        public int? SellerID { get; set; }
        public string MarketPlaceName { get; set; }
        public int? MarketplaceID { get; set; }
        public DateTime? Createdon { get; set; }
        public short? IsActive { get; set; }
        public string AccessKeyId { get; set; }
        public string SecretKey { get; set; }
        public string AmazonMarketPlaceID { get; set; }
        public string AmazonSellerID { get; set; }
        public string SettlementReportType { get; set; }
        public string OrderReportType { get; set; }
        public string TaxReportType { get; set; }
        public string GSTNNo { get; set; }
    }
}