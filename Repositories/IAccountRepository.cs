using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankCustomerManagement.Entities;

namespace BankCustomerManagement.Repositories
{
    // ISP: Account-related operations only.
    public interface IAccountRepository
    {
        Task AddAsync(Account account);
        Task<List<Account>> GetByCustomerIdAsync(int customerId);
    }
}

