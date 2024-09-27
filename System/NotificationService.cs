using AutomationSystemForSalesRepresentatives.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystemForSalesRepresentatives.System
{
    public class NotificationService
    {
        public Notification CreateNotification(string senderName, string senderID, List<Product> productList)
        {
            return new Notification(senderID, senderName, productList);
        }

        public Notification CreateNotification(string senderName, string senderID, List<Product> productList, string supplier)
        {
            return new Notification(senderID, senderName, productList, supplier);
        }
    }
}