using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystemForSalesRepresentatives.Models
{
    public class Notification
    {
        public string NotificationID { get; set; }
        public string SenderID { get; set; }
        public string SenderName { get; set; }
        public List<Product> ProductList { get; set; }
        public string Supplier { get; set; }

        public Notification(string senderID, string senderName, List<Product> products)
        {
            NotificationID = Guid.NewGuid().ToString();
            SenderID = senderID;
            SenderName = senderName;
            ProductList = products;
            Supplier = null;
        }

        public Notification(string senderID, string senderName, List<Product> products, string supplier)
        {
            NotificationID = Guid.NewGuid().ToString();
            SenderID = senderID;
            SenderName = senderName;
            ProductList = products;
            Supplier = supplier;
        }

        public override string ToString()
        {
            StringBuilder notificationString = new StringBuilder();
            notificationString.AppendLine($"Новое уведомление!");
            notificationString.AppendLine($"Notification ID: {NotificationID}");
            notificationString.AppendLine($"Sender ID: {SenderID}");
            notificationString.AppendLine($"Sender Name: {SenderName}");
            notificationString.AppendLine($"Supplier: {(Supplier != null ? Supplier : "N/A")}");
            notificationString.AppendLine("Products:");

            foreach (var product in ProductList)
            {
                notificationString.AppendLine(product.ToString());
            }

            return notificationString.ToString();
        }
    }
}