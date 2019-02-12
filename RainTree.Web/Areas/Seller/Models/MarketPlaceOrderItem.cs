using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SellerVendor.Areas.Seller.Models
{
    [Table("MarketPlaceOrderItem")]
    public class MarketPlaceOrderItemEntity
    {
        [Key]
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public string MarketPlaceOrderItemId { get; set; }
        public int? ItemId { get; set; }
        public int? OrderQuantity { get; set; }
        public int? ShippedQuantity { get; set; }
        public decimal? ItemPriceWithTax { get; set; }
        public decimal? ItemPriceWithoutTax { get; set; }
        public decimal? ItemTaxPercentage { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? ItemCgstAmount { get; set; }
        public decimal? ItemSgstAmount { get; set; }
        public decimal? ItemIgstAmount { get; set; }
        public string MarketPlaceItemStatus { get; set; }
        public DateTime? ShippingDate { get; set; }
        public DateTime? SettlementDate { get; set; }
        public string SettlementReferenceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string InvoiceNumber { get; set; }
        public short? IsReturned { get; set; }
        public string ReturnReferenceNumber { get; set; }
        public DateTime? ReturnDate { get; set; }
        public short? IsPhysicallyRecevied { get; set; }
        public DateTime? PhysicallyReceviedOnUtc { get; set; }
        public string FulfiledBy { get; set; }
        public string CreditNote { get; set; }
        public DateTime? CreditNoteDate { get; set; }
    }
}