using DemoWebAPI.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace DemoWebAPI.Data
{
    public class MyContext : DbContext 
    {
        public MyContext(DbContextOptions options): base(options) { }

        public DbSet<Employee>Employees { get; set; }

    }
}
