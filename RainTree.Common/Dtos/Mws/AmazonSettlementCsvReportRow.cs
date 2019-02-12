using System;

namespace RainTree.Common.Dtos.Mws
{
    public class AmazonSettlementCsvReportRow
    {
        public string SettlementId { get; set; }
        public DateTime? SettlementStartDate { get; set; }
        public DateTime? SettlementEndDate { get; set; }
        public DateTime? DepositDate { get; set; }
        public float? TotalAmount { get; set; }
        public string Currency { get; set; }
        public string TransactionType { get; set; }
        public string OrderId { get; set; }
        public string OrderItemId { get; set; }
        public string MerchantOrderId { get; set; }
        public string AdjustmentId { get; set; }
        public string ShipmentId { get; set; }
        public string MarketplaceName { get; set; }
        public string ShipmentFeeType { get; set; }
        public float? ShipmentFeeAmount { get; set; }
        public string OrderFeeType { get; set; }
        public float? OrderFeeAmount { get; set; }
        public string FulfillmentId { get; set; }
        public DateTime? PostedDate { get; set; }
        public string OrderItemCode { get; set; }
        public string MerchantOrderItemId { get; set; }
        public string MerchantAdjustmentItemId { get; set; }
        public string Sku { get; set; }
        public string QuantityPurchased { get; set; }
        public string PriceType { get; set; }
        public float? PriceAmount { get; set; }
        public string ItemPriceCredit { get; set; }
        public string ItemTaxCredit { get; set; }
        public string ShippingPriceCredit { get; set; }
        public string ShippingTaxCredit { get; set; }
        public string GiftWrapPriceCredit { get; set; }
        public string GiftWrapTaxCredit { get; set; }
        public string ItemRelatedFeeType { get; set; }
        public float? ItemRelatedFeeAmount { get; set; }
        public string OrderRelatedFees { get; set; }
        public string OtherFees { get; set; }
        public float? MiscFeeAmount { get; set; }
        public float? OtherFeeAmount { get; set; }
        public string OtherFeeReasonDescription { get; set; }
        public string PromotionId { get; set; }
        public string PromotionType { get; set; }
        public float? PromotionAmount { get; set; }
        public string ItemPromotionDiscount { get; set; }
        public string ItemPromotionId { get; set; }
        public string ShippingPromotionDiscount { get; set; }
        public string ShippingPromotionId { get; set; }
        public string DirectPaymentType { get; set; }
        public float? DirectPaymentAmount { get; set; }
        public float? OtherAmount { get; set; }

        public string AmountType { get; set; }
        public string AmountDescription { get; set; }
        public float? Amount { get; set; }
        public DateTime? PostedDateTime { get; set; }

    }
}
