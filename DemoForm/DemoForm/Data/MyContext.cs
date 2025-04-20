using DemoForm.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoForm.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<Form> Form { get; set; }   
    }
}
