using System.Collections.Generic;
using System.Xml.Serialization;

namespace RainTree.Common.Dtos.Mws
{

    [XmlRoot(ElementName = "Header")]
    public class Header
    {
        [XmlElement(ElementName = "DocumentVersion")]
        public string DocumentVersion { get; set; }
        [XmlElement(ElementName = "MerchantIdentifier")]
        public string MerchantIdentifier { get; set; }
    }

    [XmlRoot(ElementName = "TotalAmount")]
    public class TotalAmount
    {
        [XmlAttribute(AttributeName = "currency")]
        public string Currency { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SettlementData")]
    public class SettlementData
    {
        [XmlElement(ElementName = "AmazonSettlementID")]
        public string AmazonSettlementID { get; set; }
        [XmlElement(ElementName = "TotalAmount")]
        public TotalAmount TotalAmount { get; set; }
        [XmlElement(ElementName = "StartDate")]
        public string StartDate { get; set; }
        [XmlElement(ElementName = "EndDate")]
        public string EndDate { get; set; }
        [XmlElement(ElementName = "DepositDate")]
        public string DepositDate { get; set; }
    }

    [XmlRoot(ElementName = "Amount")]
    public class Amount
    {
        [XmlAttribute(AttributeName = "currency")]
        public string Currency { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Component")]
    public class Component
    {
        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "Amount")]
        public Amount Amount { get; set; }
    }

    [XmlRoot(ElementName = "ItemPrice")]
    public class SettlementItemPrice
    {
        [XmlElement(ElementName = "Component")]
        public List<Component> Component { get; set; }
    }

    [XmlRoot(ElementName = "Fee")]
    public class Fee
    {
        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "Amount")]
        public Amount Amount { get; set; }
    }

    [XmlRoot(ElementName = "ItemFees")]
    public class ItemFees
    {
        [XmlElement(ElementName = "Fee")]
        public List<Fee> Fee { get; set; }
    }

    [XmlRoot(ElementName = "Item")]
    public class Item
    {
        [XmlElement(ElementName = "AmazonOrderItemCode")]
        public string AmazonOrderItemCode { get; set; }
        [XmlElement(ElementName = "SKU")]
        public string SKU { get; set; }
        [XmlElement(ElementName = "Quantity")]
        public string Quantity { get; set; }
        [XmlElement(ElementName = "ItemPrice")]
        public SettlementItemPrice ItemPrice { get; set; }
        [XmlElement(ElementName = "ItemFees")]
        public ItemFees ItemFees { get; set; }
        [XmlElement(ElementName = "OrderItemCode")]
        public string OrderItemCode { get; set; }
        [XmlElement(ElementName = "ItemPriceAdjustments")]
        public ItemPriceAdjustments ItemPriceAdjustments { get; set; }
        [XmlElement(ElementName = "Promotion")]
        public List<Promotion> Promotion { get; set; }
    }

    [XmlRoot(ElementName = "Fulfillment")]
    public class Fulfillment
    {
        [XmlElement(ElementName = "MerchantFulfillmentID")]
        public string MerchantFulfillmentID { get; set; }
        [XmlElement(ElementName = "PostedDate")]
        public string PostedDate { get; set; }
        [XmlElement(ElementName = "Item")]
        public List<Item> Item { get; set; }
        [XmlElement(ElementName = "AdjustedItem")]
        //public AdjustedItem AdjustedItem { get; set; }
        public List<AdjustedItem> AdjustedItem { get; set; } //Get in case of refund

    }

    [XmlRoot(ElementName = "Order")]
    public class SettlementOrder
    {
        [XmlElement(ElementName = "AmazonOrderID")]
        public string AmazonOrderID { get; set; }
        [XmlElement(ElementName = "MerchantOrderID")]
        public string MerchantOrderID { get; set; }
        [XmlElement(ElementName = "ShipmentID")]
        public string ShipmentID { get; set; }
        [XmlElement(ElementName = "MarketplaceName")]
        public string MarketplaceName { get; set; }
        [XmlElement(ElementName = "Fulfillment")]
        public Fulfillment Fulfillment { get; set; }
    }

    [XmlRoot(ElementName = "ItemPriceAdjustments")]
    public class ItemPriceAdjustments
    {
        [XmlElement(ElementName = "Component")]
        public List<Component> Component { get; set; }
        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "Amount")]
        public Amount Amount { get; set; }
    }

    [XmlRoot(ElementName = "ItemFeeAdjustments")]
    public class ItemFeeAdjustments
    {
        [XmlElement(ElementName = "Fee")]
        public List<Fee> Fee { get; set; }
    }

    [XmlRoot(ElementName = "AdjustedItem")]
    public class AdjustedItem
    {
        [XmlElement(ElementName = "AmazonOrderItemCode")]
        public string AmazonOrderItemCode { get; set; }
        [XmlElement(ElementName = "MerchantAdjustmentItemID")]
        public string MerchantAdjustmentItemID { get; set; }
        [XmlElement(ElementName = "SKU")]
        public string SKU { get; set; }
        [XmlElement(ElementName = "ItemPriceAdjustments")]
        public ItemPriceAdjustments ItemPriceAdjustments { get; set; }
        [XmlElement(ElementName = "ItemFeeAdjustments")]
        public ItemFeeAdjustments ItemFeeAdjustments { get; set; }
    }

    [XmlRoot(ElementName = "Promotion")]
    public class Promotion
    {
        [XmlElement(ElementName = "MerchantPromotionID")]
        public string MerchantPromotionID { get; set; }
        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "Amount")]
        public Amount Amount { get; set; }
    }

    [XmlRoot(ElementName = "Refund")]
    public class Refund
    {
        [XmlElement(ElementName = "AmazonOrderID")]
        public string AmazonOrderID { get; set; }
        [XmlElement(ElementName = "MerchantOrderID")]
        public string MerchantOrderID { get; set; }
        [XmlElement(ElementName = "AdjustmentID")]
        public string AdjustmentID { get; set; }
        [XmlElement(ElementName = "MarketplaceName")]
        public string MarketplaceName { get; set; }
        [XmlElement(ElementName = "Fulfillment")]
        public Fulfillment Fulfillment { get; set; }
    }

    [XmlRoot(ElementName = "OtherTransaction")]
    public class OtherTransaction
    {
        [XmlElement(ElementName = "TransactionType")]
        public string TransactionType { get; set; }
        [XmlElement(ElementName = "TransactionID")]
        public string TransactionID { get; set; }
        [XmlElement(ElementName = "PostedDate")]
        public string PostedDate { get; set; }
        [XmlElement(ElementName = "Amount")]
        public Amount Amount { get; set; }
        [XmlElement(ElementName = "MarketplaceName")]
        public string MarketplaceName { get; set; }
        [XmlElement(ElementName = "AmazonOrderID")]
        public string AmazonOrderID { get; set; }
        [XmlElement(ElementName = "AdjustmentID")]
        public string AdjustmentID { get; set; }
        [XmlElement(ElementName = "Item")]
        public List<Item> Item { get; set; }
        [XmlElement(ElementName = "ShipmentID")]
        public string ShipmentID { get; set; }
        [XmlElement(ElementName = "MerchantFulfillmentID")]
        public string MerchantFulfillmentID { get; set; }
    }

    [XmlRoot(ElementName = "AdvertisingTransactionDetails")]
    public class AdvertisingTransactionDetails
    {
        [XmlElement(ElementName = "TransactionType")]
        public string TransactionType { get; set; }
        [XmlElement(ElementName = "PostedDate")]
        public string PostedDate { get; set; }
        [XmlElement(ElementName = "InvoiceId")]
        public string InvoiceId { get; set; }
        [XmlElement(ElementName = "BaseAmount")]
        public BaseAmount BaseAmount { get; set; }
        [XmlElement(ElementName = "TaxAmount")]
        public TaxAmount TaxAmount { get; set; }
        [XmlElement(ElementName = "TransactionAmount")]
        public TransactionAmount TransactionAmount { get; set; }
    }

    [XmlRoot(ElementName = "BaseAmount")]
    public class BaseAmount
    {
        [XmlAttribute(AttributeName = "currency")]
        public string Currency { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "TaxAmount")]
    public class TaxAmount
    {
        [XmlAttribute(AttributeName = "currency")]
        public string Currency { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "TransactionAmount")]
    public class TransactionAmount
    {
        [XmlAttribute(AttributeName = "currency")]
        public string Currency { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
    [XmlRoot(ElementName = "SettlementReport")]
    public class SettlementReport
    {
        [XmlElement(ElementName = "SettlementData")]
        public SettlementData SettlementData { get; set; }
        [XmlElement(ElementName = "Order")]
        public List<SettlementOrder> Order { get; set; }
        [XmlElement(ElementName = "Refund")]
        public List<Refund> Refund { get; set; }
        [XmlElement(ElementName = "OtherTransaction")]
        public List<OtherTransaction> OtherTransaction { get; set; }
        [XmlElement(ElementName = "AdvertisingTransactionDetails")]
        public List<AdvertisingTransactionDetails> AdvertisingTransactionDetails { get; set; }
    }

    [XmlRoot(ElementName = "Message")]
    public class Message
    {
        [XmlElement(ElementName = "MessageID")]
        public string MessageID { get; set; }
        [XmlElement(ElementName = "SettlementReport")]
        public SettlementReport SettlementReport { get; set; }
    }

    [XmlRoot(ElementName = "AmazonEnvelope")]
    public class SettlementEnvelope
    {
        [XmlElement(ElementName = "Header")]
        public Header Header { get; set; }
        [XmlElement(ElementName = "MessageType")]
        public string MessageType { get; set; }
        [XmlElement(ElementName = "Message")]
        public Message Message { get; set; }
        [XmlAttribute(AttributeName = "java", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Java { get; set; }
        [XmlAttribute(AttributeName = "amzn", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Amzn { get; set; }
        [XmlAttribute(AttributeName = "xalan", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xalan { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "noNamespaceSchemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string NoNamespaceSchemaLocation { get; set; }
    }

}
