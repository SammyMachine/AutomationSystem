using AutomationSystemForSalesRepresentatives.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystemForSalesRepresentatives.System
{
    public class PaymentService
    {
        public void ProcessPayment(Payment payment)
        {
            payment.Status = "подтвержден";
            Console.WriteLine($"Payment {payment.PaymentID} has been processed.");
        }
    }
}