using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Threading.Tasks;
using BankCustomerManagement.Entities;
using BankCustomerManagement.Repositories;

namespace BankCustomerManagement.Services
{
    // SRP: Business logic for Customers only.
    // DIP: Depends on abstraction ICustomerRepository.
    public class CustomerService
    {
        private readonly ICustomerRepository _repo;
        public CustomerService(ICustomerRepository repo) => _repo = repo;

        public async Task RegisterCustomerAsync(string name)
        {
            var customer = new Customer { Name = name };
            await _repo.AddAsync(customer);
            Console.WriteLine($"Customer added: {name}");
        }

        public async Task ShowAllAsync()
        {
            var customers = await _repo.GetAllAsync();
            foreach (var c in customers)
            {
                Console.WriteLine($"Id: {c.Id} | Name: {c.Name} | Accounts: {c.Accounts.Count}");
            }
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }
    }
}
