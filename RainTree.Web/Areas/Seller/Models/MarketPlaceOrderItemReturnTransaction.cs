﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SellerVendor.Areas.Seller.Models
{
    [Table("MarketPlaceOrderItemReturnTransaction")]
    public class MarketPlaceOrderItemReturnTransactionEntity
    {
        [Key]
        public int Id { get; set; }
        public long? OrderItemId { get; set; }
        public short? TransactionTypeId { get; set; }
        public short? MarketPlaceTransactionTypeId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? CgstAmount { get; set; }
        public decimal? CgstPercentage { get; set; }
        public decimal? SgstAmount { get; set; }
        public decimal? SgstPercentage { get; set; }
        public decimal? IgstAmount { get; set; }
        public decimal? IgstPercentage { get; set; }      

    }
}