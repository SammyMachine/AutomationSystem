using System;

namespace AutomationSystemForSalesRepresentatives.Models
{
    public class Receipt
    {
        public string ReceiptID { get; set; }
        public string BuyerID { get; set; }
        public string PaymentID { get; set; }
        public double Cost { get; set; }

        public Receipt(string buyerID, string paymentID, double cost)
        {
            ReceiptID = Guid.NewGuid().ToString();
            BuyerID = buyerID;
            PaymentID = paymentID;
            Cost = cost;
        }

        public override string ToString()
        {
            return $"Receipt ID: {ReceiptID}\n" +
                   $"Buyer ID: {BuyerID}\n" +
                   $"Payment ID: {PaymentID}\n" +
                   $"Total Cost: {Cost:C}";
        }
    }
}