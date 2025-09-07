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
    // SRP: Handles only account-related business logic.
    // DIP: Depends on abstraction IAccountRepository.
    public class AccountService
    {
        private readonly IAccountRepository _repo;
        public AccountService(IAccountRepository repo) => _repo = repo;

        public async Task AddSavingsAccountAsync(int customerId, decimal balance, decimal interestRate)
        {
            var account = new SavingsAccount
            {
                CustomerId = customerId,
                Balance = balance,
                InterestRate = interestRate
            };
            await _repo.AddAsync(account);
            Console.WriteLine($"Savings account added with balance {balance}");
        }

        public async Task AddCheckingAccountAsync(int customerId, decimal balance, decimal overdraft)
        {
            var account = new CheckingAccount
            {
                CustomerId = customerId,
                Balance = balance,
                OverdraftLimit = overdraft
            };
            await _repo.AddAsync(account);
            Console.WriteLine($"Checking account added with balance {balance}");
        }

        public async Task ShowAccountsForCustomerAsync(int customerId)
        {
            var accounts = await _repo.GetByCustomerIdAsync(customerId);
            Console.WriteLine($"\nAccounts for Customer {customerId}:");
            foreach (var acc in accounts)
            {
                Console.WriteLine($"- {acc.GetType().Name} | Balance: {acc.Balance}");
            }
        }
    }
}
