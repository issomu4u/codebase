using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SellerVendor.Areas.Seller.Models
{
    [Table("Item")]
    public class ItemEntity
    {
        [Key]
        public int Id { get; set; }
        public int? SellerId { get; set; }
        public short? MarketPlaceId { get; set; }
        public string ItemName { get; set; }
        public string SellerSku { get; set; }
        public string SellerProductId { get; set; }
        public string MarketPlaceSku { get; set; }
        public string MarketPlaceProductId { get; set; }
        public string MarketPlaceHsnCode { get; set; }
        public decimal? CurrentMrp { get; set; }
        public decimal? CurrentItemPrice { get; set; }
        public short? IsActive { get; set; }
        public DateTime? CreatedDateTimeUtc { get; set; }
        public DateTime? LastUpdateDateTimeUtc { get; set; }
        
    }
}