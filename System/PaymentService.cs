using AutomationSystemForSalesRepresentatives.Models;
using System;

namespace AutomationSystemForSalesRepresentatives.System
{
    public interface IPaymentStrategy
    {
        void ProcessPayment(Payment payment);
    }

    public class OnlinePaymentStrategy : IPaymentStrategy
    {
        public void ProcessPayment(Payment payment)
        {
            payment.Status = "оплачено онлайн";
            Console.WriteLine($"Оплата {payment.PaymentID} прошла онлайн.");
        }
    }

    public class CashPaymentStrategy : IPaymentStrategy
    {
        public void ProcessPayment(Payment payment)
        {
            payment.Status = "оплачено наличными";
            Console.WriteLine($"Оплата {payment.PaymentID} прошла наличными.");
        }
    }

    // Модифицированный PaymentService
    public class PaymentService
    {
        private IPaymentStrategy _paymentStrategy;

        public PaymentService(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public Receipt ProcessPayment(Payment payment)
        {
            _paymentStrategy.ProcessPayment(payment);
            return new Receipt(payment.BuyerID, payment.PaymentID, payment.Cost);
        }
    }
}