using AutomationSystemForSalesRepresentatives.Models;
using AutomationSystemForSalesRepresentatives.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystemForSalesRepresentatives.Users
{
    public class Administrator : User
    {
        public Administrator(string name)
        {
            UserID = Guid.NewGuid().ToString();
            Name = name;
        }

        public void RegisterSystemUser(bool flag)
        {
            string name = RandomStringGenerator.GenerateRandomString(6);

            List<User> userList = SystemServiceController.Instance.SendUserList();
            if (flag)
            {
                userList.Add(new OrdinaryUser(name));
                Console.WriteLine($"Товаровед {name} зарегистрирован");
            }
            else
            {
                userList.Add(new GuestUser(name, RandomStringGenerator.GenerateRandomString(10)));
                Console.WriteLine($"Торговый представитель {name} зарегистрирован");
            }
            Console.WriteLine($"Список пользователей изменен.");
            SystemServiceController.Instance.GetUserList(userList);
        }

        public void DeleteSystemUser(string userID)
        {
            List<User> userList = SystemServiceController.Instance.SendUserList();
            userList.RemoveAll(user => user.UserID == userID);
            Console.WriteLine($"Пользователь {userID} удален из системы");
            SystemServiceController.Instance.GetUserList(userList);
        }

        public override List<List<Product>> CheckStorage()
        {
            Console.WriteLine($"Проверка склада для администратора завершена");
            return SystemServiceController.Instance.CheckStorage();
        }

        public void GetPaymentReport()
        {
            Console.WriteLine($"Отчет\n--------------\n{SystemServiceController.Instance.SendPaymentReport()}");
        }

        public void GetNotificationList()
        {
            Console.WriteLine($"Список уведомлений\n--------------\n{SystemServiceController.Instance.SendNotificationList()}");
        }

        private sealed class RandomStringGenerator
        {
            private static Random random = new Random();
            private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            public static string GenerateRandomString(int length) => new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}