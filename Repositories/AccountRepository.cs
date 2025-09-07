using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BankCustomerManagement.Data;
using BankCustomerManagement.Entities;

namespace BankCustomerManagement.Repositories
{
    // SRP: Handles DB operations for Accounts only.
    // DIP: Implements IAccountRepository, injected where needed.
    public class AccountRepository : IAccountRepository
    {
        private readonly BankingDbContext _db;
        public AccountRepository(BankingDbContext db) => _db = db;

        public async Task AddAsync(Account account)
        {
            _db.Accounts.Add(account);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Account>> GetByCustomerIdAsync(int customerId)
        {
            return await _db.Accounts.Where(a => a.CustomerId == customerId).ToListAsync();
        }
    }
}

