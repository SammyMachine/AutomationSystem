using AutomationSystemForSalesRepresentatives.Models;
using AutomationSystemForSalesRepresentatives.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystemForSalesRepresentatives.System
{
    public class SystemServiceController
    {
        private static SystemServiceController instance;

        private readonly List<Order> orderList = new List<Order>();
        private readonly List<Payment> paymentList = new List<Payment>();
        private List<Receipt> receiptList = new List<Receipt>();
        private readonly List<Notification> notificationList = new List<Notification>();
        private List<User> userList = new List<User>();

        public Storage Storage { get; set; }

        private readonly PaymentService paymentService = new PaymentService();
        private readonly NotificationService notificationService = new NotificationService();
        private readonly ReportService reportService = new ReportService();

        private SystemServiceController()
        { }

        public static SystemServiceController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SystemServiceController();
                }
                return instance;
            }
        }

        public void GetOrder(Order order)
        {
            order.Status = "Принят в обработку";
            orderList.Add(order);
            Console.WriteLine($"Order {order.OrderID} from Buyer {order.BuyerID} received.");
        }

        public Order SendOrder(string orderID)
        {
            return orderList.Find(order => order.OrderID == orderID);
        }

        public Order SendOrder()
        {
            Order order = orderList[0];
            orderList.RemoveAt(0);
            return order;
        }

        public void GetPayment(Payment payment, string orderID)
        {
            payment.Status = "Принят в обработку";
            paymentList.Add(payment);
            paymentService.ProcessPayment(payment);
            Console.WriteLine($"Payment {payment.PaymentID} for Order {orderID} received.");
        }

        public List<List<Product>> CheckStorage()
        {
            return Storage.Check();
        }

        public void GetBasket(Basket basket)
        {
            basket.Status = "Отправлена";
            Console.WriteLine($"Корзина {basket.BasketID} для заказа {basket.OrderID} подтверждена и отправлена покупателю {SendOrder(basket.OrderID).BuyerID}");
        }

        public void GetNotification(string SenderID, string SenderName, List<Product> products)
        {
            Console.WriteLine($"Уведомление от товароведа {SenderID} обрабатывается системой");
            notificationList.Add(notificationService.CreateNotification(SenderID, SenderName, products));
            Console.WriteLine($"Уведомление от товароведа {SenderID} сохранено.");
        }

        public void GetNotification(string SenderID, string SenderName, List<Product> Products, string Supplier)
        {
            Console.WriteLine($"Уведомление от торгового представителя {SenderID} обрабатывается системой");
            notificationList.Add(notificationService.CreateNotification(SenderID, SenderName, Products, Supplier));
            Console.WriteLine($"Уведомление от торгового представителя {SenderID} сохранено.");
        }

        public void GetUserList(List<User> userList)
        {
            this.userList = userList;
            Console.WriteLine($"Список пользователей сохранен.");
        }

        public List<User> SendUserList()
        {
            return userList;
        }

        public Report SendPaymentReport()
        {
            Console.WriteLine($"Отчет сгенерирован.");
            return reportService.GeneratePaymentReport(receiptList);
        }

        public List<Notification> SendNotificationList()
        {
            return notificationList;
        }
    }
}