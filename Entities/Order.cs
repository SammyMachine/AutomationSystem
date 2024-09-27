using System;
using System.Collections.Generic;

namespace AutomationSystemForSalesRepresentatives.Models
{
    public class Order
    {
        public string OrderID { get; set; }
        public string BuyerID { get; set; }
        public List<Product> ProductList { get; set; }
        public double Cost { get; set; }
        public string Status { get; set; }

        public Order(string buyerID, List<Product> productList)
        {
            OrderID = Guid.NewGuid().ToString();
            BuyerID = buyerID;
            ProductList = productList;
            CalculateCost();
            Status = "Отправлен";
        }

        public void CalculateCost()
        {
            foreach (var item in ProductList)
            {
                Cost += item.Cost;
            }
        }
    }
}