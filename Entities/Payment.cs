using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystemForSalesRepresentatives.Models
{
    public class Payment
    {
        public string PaymentID { get; set; }
        public string BuyerID { get; set; }
        public double Cost { get; set; }
        public string Status { get; set; }

        public Payment(string buyerID, double cost)
        {
            PaymentID = Guid.NewGuid().ToString();
            BuyerID = buyerID;
            Cost = cost;
            Status = "Отправлен";
        }
    }
}