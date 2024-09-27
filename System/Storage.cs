using AutomationSystemForSalesRepresentatives.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystemForSalesRepresentatives.System
{
    public class Storage
    {
        public string StorageID { get; set; }
        public List<Product> Products { get; set; }

        public Storage()
        {
            StorageID = Guid.NewGuid().ToString();
            Products = new List<Product>() { };
        }

        public List<List<Product>> Check()
        {
            List<Product> unavailableProduts = new List<Product>();
            List<Product> availableProducts = new List<Product>();

            foreach (Product product in Products)
            {
                if (product.Quantity > 0)
                {
                    availableProducts.Add(product);
                    Console.WriteLine($"Товар {product.ProductName} на складе: {product.Quantity}");
                }
                else
                {
                    unavailableProduts.Add(product);
                    Console.WriteLine("Товар отсутствует на складе");
                }
            }
            return new List<List<Product>>() { availableProducts, unavailableProduts };
        }
    }
}