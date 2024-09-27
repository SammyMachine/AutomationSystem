using AutomationSystemForSalesRepresentatives.Models;
using System.Collections.Generic;

namespace AutomationSystemForSalesRepresentatives.Users
{
    public abstract class User
    {
        public string UserID { get; set; }
        public string Name { get; set; }

        public abstract List<List<Product>> CheckStorage();
    }
}