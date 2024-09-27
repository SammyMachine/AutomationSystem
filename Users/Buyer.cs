using AutomationSystemForSalesRepresentatives.Models;
using AutomationSystemForSalesRepresentatives.System;
using System;
using System.Collections.Generic;

namespace AutomationSystemForSalesRepresentatives.Users
{
    public class Buyer : User
    {
        public string OrderID { get; set; }

        public Buyer(string name)
        {
            UserID = Guid.NewGuid().ToString();
            Name = name;
        }

        public void CreateOrder()
        {
            Order order = new Order(UserID,
                new List<Product>() { }
                );
            OrderID = order.OrderID;
            SystemServiceController.Instance.GetOrder(order);
        }

        public void CreatePayment(Order order, bool flag)
        {
            double cost = SystemServiceController.Instance.SendOrder(OrderID).Cost;
            Payment payment = new Payment(OrderID, cost);
            if (flag)
            {
                payment.Status = "оплачено наличными";
            }
            else
            {
                payment.Status = "оплачено онлайн";
            }
            SystemServiceController.Instance.GetPayment(payment, OrderID, flag);
        }

        public override List<List<Product>> CheckStorage()
        {
            Console.WriteLine($"Buyer {Name} is checking storage.");
            return null;
        }
    }
}