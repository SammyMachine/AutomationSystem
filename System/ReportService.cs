using AutomationSystemForSalesRepresentatives.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystemForSalesRepresentatives.System
{
    public class ReportService
    {
        public Report GeneratePaymentReport(List<Receipt> receipts)
        {
            return new Report(receipts);
        }
    }
}