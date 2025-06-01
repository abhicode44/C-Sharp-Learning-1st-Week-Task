using Demo_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo_API.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<Player> Players { get; set; }
    }
}
