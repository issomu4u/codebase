using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SellerVendor.Areas.Seller.Models
{
    [Table("MarketPlaceOrder")]
    public class MarketPlaceOrderEntity
    {
        [Key]
        public int Id { get; set; }
        public int? SellerId { get; set; }
        public short? MarketPlaceId { get; set; }
        public int? CustomerId { get; set; }

        public int? VoucherNumber { get; set; }
        public string MarketPlaceOrderId { get; set; }
        public DateTime? MarketPlaceOrderDate { get; set; }

        public string MarketPlaceOrderStatus { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentMode { get; set; }
        public string CurrencyCode { get; set; }
        public int? DispatchPinCode { get; set; }
        public decimal? TotalOrderAmountWithTax { get; set; }
        public decimal? TotalOrderAmountWithoutTax { get; set; }
        public decimal? TotalOrderTax { get; set; }

        public short? IsReplacementOrder { get; set; }
        public short? HasSettled { get; set; }
        public short? SourceProcessTypeId { get; set; }
        public DateTime? CreatedDateTimeUtc { get; set; }
        public DateTime? LastUpdateDateTimeUtc { get; set; }
        public short? IsCompleted { get; set; }
    }
}