using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCustomerManagement.Entities
{
    // Extension of Account (LSP applies here).
    public class CheckingAccount : Account
    {
        public decimal OverdraftLimit { get; set; }
    }
}

