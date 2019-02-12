using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SellerVendor.Areas.Seller.Models
{
    [Table("MarketPlaceSettlement")]
    public class MarketPlaceSettlementEntity
    {
        [Key]
        public long Id { get; set; }

        public int? SellerId { get; set; }

        public short? MarketPlaceId { get; set; }

        public int? VoucherNumber { get; set; }

        public DateTime? SettlementDate { get; set; }

        public string SettlementReferenceNumber { get; set; }

        public decimal? TotalOrderAmount { get; set; }

        public decimal? TotalCreditAmount { get; set; }

        public decimal? TotalDebitAmount { get; set; }

        public DateTime? CreatedDateTimeUtc { get; set; }

        public DateTime? LastUpdateDateTimeUtc { get; set; }
    }
}