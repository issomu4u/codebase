using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SellerVendor.Areas.Seller.Models
{
    [Table("MarketPlaceSettlementItem")]
    public class MarketPlaceSettlementItemEntity
    {
        [Key]
        public long Id { get; set; }
        public long? SettlementId { get; set; }
        public string MarketPlaceOrderId { get; set; }
        public string MarketPlaceOrderItemId { get; set; }
        public DateTime? MarketPlaceOrderDate { get; set; }
        public string MarketPlaceOrderStatus { get; set; }
        public decimal? OrderItemPrice { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? ReturnAmount { get; set; }
        public decimal? ItemTaxPercentage { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? ItemCgstAmount { get; set; }
        public decimal? ItemSgstAmount { get; set; }
        public decimal? ItemIgstAmount { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime? CreatedDateTimeUtc { get; set; }
        public DateTime? LastUpdateDateTimeUtc { get; set; }
    }
}