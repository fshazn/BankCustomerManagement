using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BankCustomerManagement.Entities
{
    // SRP (Single Responsibility): Only represents Customer data.
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property
        public List<Account> Accounts { get; set; } = new();
    }
}
