🏦 BANK CUSTOMER MANAGEMENT

A simple C# console application demonstrating SOLID principles and Entity Framework Core using SQLite.
The application simulates a small banking system where you can manage Customers and their Accounts (Savings / Checking).

FEATURES

  * Add a new customer.
  * View all customers along with their accounts.
  * Add Savings or Checking accounts for a customer.
  * View accounts for a specific customer.
  * All data is stored persistently in a SQLite database (banking.db).

FOLDER STRUCTURE
  
    BankCustomerManagement/
    │   Program.cs
    │   BankCustomerManagement.csproj
    │
    ├── Entities/          # Represents domain entities (Customer, Account, etc.)
    ├── Data/              # EF Core DbContext configuration
    ├── Repositories/      # Interfaces + EF implementations
    └── Services/          # Business logic using repositories

SOLID Principle	How It’s Applied in This Project

S – Single Responsibility	Each class has a single responsibility:
    • CustomerService → business logic for customers only.
    • AccountService → business logic for accounts only.
    • CustomerRepository → database operations for Customer only.
    • AccountRepository → database operations for Account only.

O – Open/Closed	The system is open for extension but closed for modification:
    • Account is an abstract class.
    • You can create SavingsAccount, CheckingAccount, or any new account type without changing existing service code.
    • OnModelCreating uses EF Core discriminator to handle new account types automatically.
    
L – Liskov Substitution	Subtypes can replace their base types without breaking functionality:
    • Anywhere Account is expected, SavingsAccount or CheckingAccount can be used.
    • For example, AccountService methods accept Account-derived objects.
    
I – Interface Segregation	Clients depend only on methods they use:
    • ICustomerRepository contains only customer-related operations.
    • IAccountRepository contains only account-related operations.
    • Services depend on these small interfaces, not a large, all-encompassing interface.
    
D – Dependency Inversion	High-level modules depend on abstractions, not concrete implementations:
    • CustomerService depends on ICustomerRepository.
    • AccountService depends on IAccountRepository.
    • Dependency Injection (DI) container injects concrete implementations (CustomerRepository / AccountRepository) at runtime.

    
PREREQUISITES

required NuGet packages:

    dotnet add package Microsoft.EntityFrameworkCore --version 8.*
    dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 8.*
    dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.*
    dotnet add package Microsoft.Extensions.Hosting --version 8.*
