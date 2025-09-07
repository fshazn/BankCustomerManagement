using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BankCustomerManagement.Entities;

namespace BankCustomerManagement.Data
{
    // SRP: Only responsible for database access config.
    public class BankingDbContext : DbContext
    {
        public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // OCP (Open-Closed): Add new account types here without modifying core logic.
            modelBuilder.Entity<Account>()
                .HasDiscriminator<string>("AccountType")
                .HasValue<SavingsAccount>("Savings")
                .HasValue<CheckingAccount>("Checking");
        }
    }
}

