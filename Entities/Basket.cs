using System;
using System.Collections.Generic;

namespace AutomationSystemForSalesRepresentatives.Models
{
    public class Basket
    {
        public string BasketID { get; set; } = Guid.NewGuid().ToString();
        public string OrderID { get; set; }
        public List<Product> ProductList { get; set; }
        public double Cost { get; set; }
        public string Status { get; set; }

        public Basket(Order order)
        {
            BasketID = Guid.NewGuid().ToString();
            OrderID = order.OrderID;
            ProductList = order.ProductList;
            Cost = order.Cost;
            Status = "В сборке";
        }
    }
}