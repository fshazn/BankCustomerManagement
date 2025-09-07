using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankCustomerManagement.Entities;

namespace BankCustomerManagement.Repositories
{
    // ISP (Interface Segregation): Only customer-specific operations here.
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
    }
}
