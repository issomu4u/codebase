using CsvHelper.Configuration;

namespace RainTree.Common.Dtos.Mws
{
    public sealed class AmazonSettlementReportCsvMap : ClassMap<AmazonSettlementCsvReportRow>
    {
        public AmazonSettlementReportCsvMap()
        {
            Map(m => m.SettlementId).Name("settlement-id");
            Map(m => m.SettlementStartDate).Name("settlement-start-date");
            Map(m => m.SettlementEndDate).Name("settlement-end-date");
            Map(m => m.DepositDate).Name("deposit-date");
            Map(m => m.TotalAmount).Name("total-amount");
            Map(m => m.Currency).Name("currency");
            Map(m => m.TransactionType).Name("transaction-type");
            Map(m => m.OrderId).Name("order-id");
            Map(m => m.MerchantOrderId).Name("merchant-order-id");
            Map(m => m.AdjustmentId).Name("adjustment-id");
            Map(m => m.ShipmentId).Name("shipment-id");
            Map(m => m.MarketplaceName).Name("marketplace-name");
            Map(m => m.ShipmentFeeType).Name("shipment-fee-type");
            Map(m => m.ShipmentFeeType).Name("shipment-fee-type");
            Map(m => m.ShipmentFeeAmount).Name("shipment-fee-amount");
            Map(m => m.OrderFeeType).Name("order-fee-type");
            Map(m => m.OrderFeeAmount).Name("order-fee-amount");
            Map(m => m.FulfillmentId).Name("fulfillment-id");
            Map(m => m.PostedDate).Name("posted-date");
            Map(m => m.OrderItemCode).Name("order-item-code");
            Map(m => m.MerchantOrderItemId).Name("merchant-order-item-id");
            Map(m => m.MerchantAdjustmentItemId).Name("merchant-adjustment-item-id");
            Map(m => m.Sku).Name("sku");
            Map(m => m.QuantityPurchased).Name("quantity-purchased");
            Map(m => m.PriceType).Name("price-type");
            Map(m => m.PriceAmount).Name("price-amount");
            Map(m => m.ItemPriceCredit).Name("item-price-credit");
            Map(m => m.ItemTaxCredit).Name("item-tax-credit");
            Map(m => m.ShippingPriceCredit).Name("shipping-price-credit");
            Map(m => m.ShippingTaxCredit).Name("shipping-tax-credit");
            Map(m => m.GiftWrapPriceCredit).Name("gift-wrap-price-credit");
            Map(m => m.GiftWrapTaxCredit).Name("gift-wrap-tax-credit");
            Map(m => m.ItemRelatedFeeType).Name("item-related-fee-type");
            Map(m => m.ItemRelatedFeeAmount).Name("item-related-fee-amount");
            Map(m => m.OrderRelatedFees).Name("order-related-fees");
            Map(m => m.OtherFees).Name("other-fees");
            Map(m => m.MiscFeeAmount).Name("misc-fee-amount");
            Map(m => m.OtherFeeAmount).Name("other-fee-amount");
            Map(m => m.OtherFeeReasonDescription).Name("other-fee-reason-description");
            Map(m => m.PromotionId).Name("promotion-id");
            Map(m => m.PromotionType).Name("promotion-type");
            Map(m => m.PromotionAmount).Name("promotion-amount");
            Map(m => m.ItemPromotionDiscount).Name("item-promotion-discount");
            Map(m => m.ItemPromotionId).Name("item-promotion-id");
            Map(m => m.ShippingPromotionDiscount).Name("shipping-promotion-discount");
            Map(m => m.ShippingPromotionId).Name("shipping-promotion-id");
            Map(m => m.DirectPaymentType).Name("direct-payment-type");
            Map(m => m.DirectPaymentAmount).Name("direct-payment-amount");
            Map(m => m.OtherAmount).Name("other-amount");

            Map(m => m.AmountType).Name("amount-type");
            Map(m => m.AmountDescription).Name("amount-description");
            Map(m => m.Amount).Name("amount");
            Map(m => m.PostedDateTime).Name("posted-date-time");

        }


    }
}
