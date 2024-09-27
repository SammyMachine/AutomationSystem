using AutomationSystemForSalesRepresentatives.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystemForSalesRepresentatives.Users
{
    public abstract class User
    {
        public string UserID { get; set; }
        public string Name { get; set; }

        public abstract List<List<Product>> CheckStorage();
    }
}