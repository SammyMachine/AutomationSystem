using System;

namespace AutomationSystemForSalesRepresentatives.Models
{
    public class Product
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }

        public Product(string name, int quantity, double cost)
        {
            ProductID = Guid.NewGuid().ToString();
            ProductName = name;
            Quantity = quantity;
            Cost = cost;
        }

        public override string ToString()
        {
            return $"{ProductName} (ID: {ProductID}), Quantity: {Quantity}, Cost: {Cost}";
        }
    }
}