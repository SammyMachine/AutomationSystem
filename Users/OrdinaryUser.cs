using AutomationSystemForSalesRepresentatives.Models;
using AutomationSystemForSalesRepresentatives.System;
using System;
using System.Collections.Generic;

namespace AutomationSystemForSalesRepresentatives.Users
{
    public class OrdinaryUser : User
    {
        public string CurrentOrderID { get; set; }

        public OrdinaryUser(string name)
        {
            UserID = Guid.NewGuid().ToString();
            Name = name;
        }

        public void Work()
        {
            Order order = GetNewOrder();
            var lists = CheckStorage();
            var flag = true;
            foreach (Product availableProduct in lists[0])
            {
                if (!order.ProductList.Contains(availableProduct))
                {
                    flag = false;
                }
            }
            if (!flag)
            {
                SendNotification(lists[1]);
            }
            else
            {
                Basket basket = CollectProductsForOrder(order);
            }
        }

        private Order GetNewOrder()
        {
            Order order = SystemServiceController.Instance.SendOrder();
            CurrentOrderID = order.OrderID;
            Console.WriteLine($"Товаровед {UserID} принял заказ {CurrentOrderID} в работу");
            order.Status = "В работе";
            return order;
        }

        private void SendNotification(List<Product> products)
        {
            Console.WriteLine($"Уведомление от товароведа {UserID} отправлено в систему");
            SystemServiceController.Instance.GetNotification(UserID, Name, products);
        }

        public override List<List<Product>> CheckStorage()
        {
            Console.WriteLine($"Проверка склада для товароведа {UserID} завершена");
            return SystemServiceController.Instance.CheckStorage();
        }

        private Basket CollectProductsForOrder(Order order)
        {
            Basket basket = new Basket(order);
            Console.WriteLine($"Товары для заказа {order.OrderID} собраны в корзину {basket.BasketID}");
            return basket;
        }

        private void ConfirmBasket(Basket basket)
        {
            Console.WriteLine($"Отправка корзины в систему {basket.BasketID} для подтверждения");
            SystemServiceController.Instance.GetBasket(basket);
        }
    }
}