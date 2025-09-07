using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BankCustomerManagement.Entities
{
    // LSP (Liskov Substitution): SavingsAccount/CheckingAccount can replace Account safely.
    public abstract class Account
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}

