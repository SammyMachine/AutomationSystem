using AutomationSystemForSalesRepresentatives.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystemForSalesRepresentatives.System
{
    public abstract class Notification
    {
        public string NotificationID { get; private set; }
        public string SenderID { get; private set; }
        public string SenderName { get; private set; }
        public List<Product> ProductList { get; private set; }
        public string Supplier { get; protected set; }

        protected Notification(string senderID, string senderName, List<Product> products)
        {
            NotificationID = Guid.NewGuid().ToString();
            SenderID = senderID;
            SenderName = senderName;
            ProductList = products;
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

    // Уведомление от обычного пользователя
    public class OrdinaryUserNotification : Notification
    {
        public OrdinaryUserNotification(string senderID, string senderName, List<Product> products)
            : base(senderID, senderName, products)
        {
            Supplier = null; // У обычного пользователя нет поставщика
        }
    }

    // Уведомление от поставщика
    public class SupplierUserNotification : Notification
    {
        public SupplierUserNotification(string senderID, string senderName, List<Product> products, string supplier)
            : base(senderID, senderName, products)
        {
            Supplier = supplier; // У поставщика есть информация о поставщике
        }
    }

    public class NotificationService
    {
        // Метод создания уведомления для обычного пользователя
        public Notification CreateOrdinaryUserNotification(string senderName, string senderID, List<Product> productList)
        {
            return new OrdinaryUserNotification(senderID, senderName, productList);
        }

        // Метод создания уведомления для поставщика
        public Notification CreateSupplierUserNotification(string senderName, string senderID, List<Product> productList, string supplier)
        {
            return new SupplierUserNotification(senderID, senderName, productList, supplier);
        }
    }
}