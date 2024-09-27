using AutomationSystemForSalesRepresentatives.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystemForSalesRepresentatives.System
{
    // Новый адаптер
    public interface IReportAdapter
    {
        string GetFormattedReport(Report report);
    }

    public class TextReportAdapter : IReportAdapter
    {
        public string GetFormattedReport(Report report)
        {
            return report.ToString();
        }
    }

    public class JsonReportAdapter : IReportAdapter
    {
        public string GetFormattedReport(Report report)
        {
            return ConvertReportToJson(report);
        }

        private string ConvertReportToJson(Report report)
        {
            var reportJson = new StringBuilder();
            reportJson.Append("{\n");
            reportJson.Append($"\t\"ReportID\": \"{report.ReportID}\",\n");
            reportJson.Append($"\t\"Date\": \"{report.Date.ToString("yyyy-MM-dd HH:mm:ss")}\",\n");
            reportJson.Append("\t\"Receipts\": [\n");

            for (int i = 0; i < report.ReceiptList.Count; i++)
            {
                var receipt = report.ReceiptList[i];
                reportJson.Append("\t\t{\n");
                reportJson.Append($"\t\t\t\"ReceiptID\": \"{receipt.ReceiptID}\",\n");
                reportJson.Append($"\t\t\t\"BuyerID\": \"{receipt.BuyerID}\",\n");
                reportJson.Append($"\t\t\t\"PaymentID\": \"{receipt.PaymentID}\",\n");
                reportJson.Append($"\t\t\t\"Cost\": {receipt.Cost}\n");
                reportJson.Append("\t\t}");

                if (i < report.ReceiptList.Count - 1)
                    reportJson.Append(",\n");
                else
                    reportJson.Append("\n");
            }

            reportJson.Append("\t]\n");
            reportJson.Append("}\n");

            return reportJson.ToString();
        }
    }

    // Использование адаптера
    public class ReportService
    {
        public string GenerateReport(List<Receipt> receipts, IReportAdapter adapter)
        {
            Report report = new Report(receipts);
            return adapter.GetFormattedReport(report);
        }
    }
}