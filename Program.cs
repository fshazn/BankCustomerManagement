using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BankCustomerManagement.Data;
using BankCustomerManagement.Repositories;
using BankCustomerManagement.Services;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((ctx, services) =>
    {
        // DIP: Register abstractions with implementations.
        services.AddDbContext<BankingDbContext>(opts =>
            opts.UseSqlite("Data Source=banking.db")
            );

        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();

        services.AddScoped<CustomerService>();
        services.AddScoped<AccountService>();
    }).Build();

using var scope = host.Services.CreateScope();
var provider = scope.ServiceProvider;
var db = provider.GetRequiredService<BankingDbContext>();
db.Database.EnsureCreated();

var customerService = provider.GetRequiredService<CustomerService>();
var accountService = provider.GetRequiredService<AccountService>();

bool running = true;
while (running)
{
    Console.WriteLine("\n=== Bank Menu ===");
    Console.WriteLine("1. Add Customer");
    Console.WriteLine("2. Show All Customers");
    Console.WriteLine("3. Add Account for Customer");
    Console.WriteLine("4. Show Accounts for Customer");
    Console.WriteLine("5. Exit");
    Console.Write("Choose an option: ");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Enter customer name: ");
            var name = Console.ReadLine();
            await customerService.RegisterCustomerAsync(name);
            break;

        case "2":
            await customerService.ShowAllAsync();
            break;

        case "3":
            Console.Write("Enter Customer ID: ");
            int custId = int.Parse(Console.ReadLine());

            Console.WriteLine("Choose Account Type: 1) Savings 2) Checking");
            var accType = Console.ReadLine();

            Console.Write("Enter balance: ");
            decimal balance = decimal.Parse(Console.ReadLine());

            if (accType == "1")
            {
                Console.Write("Enter interest rate: ");
                decimal rate = decimal.Parse(Console.ReadLine());
                await accountService.AddSavingsAccountAsync(custId, balance, rate);
            }
            else
            {
                Console.Write("Enter overdraft limit: ");
                decimal overdraft = decimal.Parse(Console.ReadLine());
                await accountService.AddCheckingAccountAsync(custId, balance, overdraft);
            }
            break;

        case "4":
            Console.Write("Enter Customer ID: ");
            int cid = int.Parse(Console.ReadLine());
            await accountService.ShowAccountsForCustomerAsync(cid);
            break;

        case "5":
            running = false;
            break;

        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
}
