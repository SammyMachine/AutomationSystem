using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystemForSalesRepresentatives.Models
{
    public class Receipt
    {
        public string ReceiptID { get; set; }
        public string OrderID { get; set; }
        public string BuyerID { get; set; }
        public string PaymentID { get; set; }
        public List<Product> ProductList { get; set; }
        public double Cost { get; set; }

        public Receipt(string orderID, string buyerID, string paymentID, List<Product> productList, double cost)
        {
            ReceiptID = Guid.NewGuid().ToString();
            OrderID = orderID;
            BuyerID = buyerID;
            PaymentID = paymentID;
            ProductList = productList;
            Cost = cost;
        }

        public override string ToString()
        {
            return $"Receipt ID: {ReceiptID}\n" +
                   $"Order ID: {OrderID}\n" +
                   $"Buyer ID: {BuyerID}\n" +
                   $"Payment ID: {PaymentID}\n" +
                   $"Products: {string.Join(", ", ProductList.Select(p => p.ToString()))}\n" +
                   $"Total Cost: {Cost:C}";
        }
    }
}