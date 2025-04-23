using Bank_Application.Model;
using Microsoft.EntityFrameworkCore;

namespace Bank_Application.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<Admin> Admin  { get ; set ; }

        public DbSet<Role> Roles { get ; set ; }
        public DbSet<Company> Companies { get ; set ; } 

        public DbSet<Bank> Banks { get ; set ; }

        public DbSet<Benificiary> Benificiaries { get ; set ; }

        public DbSet<Employee> Employees { get ; set ; }

        public DbSet<Transaction> Transactions { get ; set ; }

    }
}
