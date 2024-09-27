using AutomationSystemForSalesRepresentatives.Models;
using AutomationSystemForSalesRepresentatives.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystemForSalesRepresentatives.Users
{
    public class GuestUser : User
    {
        public string SupplierName { get; set; }

        public GuestUser(string name, string supplier)
        {
            UserID = Guid.NewGuid().ToString();
            Name = name;
            SupplierName = supplier;
        }

        public void Work()
        {
            var lists = CheckStorage();
            SendNotification(lists[1]);
        }

        public override List<List<Product>> CheckStorage()
        {
            Console.WriteLine($"Проверка склада для торгового представите {UserID} завершена");
            return SystemServiceController.Instance.CheckStorage();
        }

        private void SendNotification(List<Product> products)
        {
            Console.WriteLine($"Уведомление от торгового представителя {UserID} отправлено в систему");
            SystemServiceController.Instance.GetNotification(UserID, Name, products, SupplierName);
        }
    }
}