using AutomationSystemForSalesRepresentatives.Models;
using AutomationSystemForSalesRepresentatives.System;
using AutomationSystemForSalesRepresentatives.Users;
using System;

using System.Collections.Generic;

namespace AutomationSystemForSalesRepresentatives
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SystemServiceController system = SystemServiceController.Instance;
            Storage storage = new Storage();
            system.Storage = storage;

            FillStorage(storage);

            Administrator admin = new Administrator("Admin");

            admin.RegisterSystemUser(true);
            admin.RegisterSystemUser(false);

            var ordinaryUser = system.userList[0] as OrdinaryUser;
            var guestUser = system.userList[1] as GuestUser;
            guestUser.Work();

            Buyer buyer1 = new Buyer("Buyer1");
            Buyer buyer2 = new Buyer("Buyer2");

            buyer1.CreateOrder();
            buyer2.CreateOrder();

            List<List<Product>> storageStatus = system.CheckStorage();
            List<Product> availableProducts = storageStatus[0];
            List<Product> unavailableProducts = storageStatus[1];

            AddProductsToOrder(buyer1, availableProducts); // Все товары доступны
            AddProductsToOrder(buyer2, unavailableProducts); // Частично доступны

            buyer1.CreatePayment(system.SendOrder(buyer1.OrderID), true);
            buyer2.CreatePayment(system.SendOrder(buyer2.OrderID), false);

            ordinaryUser.Work();

            admin.GetPaymentReport(true);

            ordinaryUser.Work();

            admin.GetPaymentReport(false);
            admin.GetNotificationList();

            Console.ReadLine();
        }

        private static void FillStorage(Storage storage)
        {
            storage.Products.Add(new Product("Product1", 10, 100.0));
            storage.Products.Add(new Product("Product2", 0, 50.0));  // Продукт отсутствует на складе
            storage.Products.Add(new Product("Product3", 5, 75.0));
        }

        private static void AddProductsToOrder(Buyer buyer, List<Product> products)
        {
            // Добавляем все доступные продукты в корзину
            foreach (var product in products)
            {
                var order = SystemServiceController.Instance.SendOrder(buyer.OrderID);
                order.ProductList.Add(product);
                order.CalculateCost();
            }
        }
    }
}