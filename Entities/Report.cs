using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationSystemForSalesRepresentatives.Models
{
    public class Report
    {
        public string ReportID { get; set; }
        public List<Receipt> ReceiptList { get; set; }
        public DateTime Date { get; set; }

        public Report(List<Receipt> receipts)
        {
            ReportID = Guid.NewGuid().ToString();
            ReceiptList = receipts;
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            StringBuilder reportString = new StringBuilder();
            reportString.AppendLine($"Report ID: {ReportID}");
            reportString.AppendLine($"Date: {Date.ToString("yyyy-MM-dd HH:mm:ss")}");
            reportString.AppendLine("Receipts:");

            foreach (var receipt in ReceiptList)
            {
                reportString.AppendLine(receipt.ToString());
            }

            return reportString.ToString();
        }
    }
}