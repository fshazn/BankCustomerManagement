using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BankCustomerManagement.Data;
using BankCustomerManagement.Entities;

namespace BankCustomerManagement.Repositories
{
    // SRP: Handles only DB operations for Customer.
    // DIP: Implements interface, used via abstraction.
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BankingDbContext _db;
        public CustomerRepository(BankingDbContext db) => _db = db;

        public async Task AddAsync(Customer customer)
        {
            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _db.Customers.Include(c => c.Accounts).ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _db.Customers.Include(c => c.Accounts)
                                      .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
