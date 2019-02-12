using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SellerVendor.Areas.Seller.Models
{
    [Table("MarketPlaceTransactionType")]
    public class MarketPlaceTransactionTypeEntity
    {
        [Key]
        public short Id { get; set; }
        public string MarketPlaceDescription { get; set; }
        public string RainTreeDescription { get; set; }
        public short? IsActive { get; set; }      
    }
}