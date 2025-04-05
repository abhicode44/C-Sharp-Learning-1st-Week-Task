using JWTRoleBasedAccess.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace JWTRoleBasedAccess.Data
{
    public class MyContext : DbContext

    {
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<Users> users { get; set; }
        public DbSet<Role> roles { get; set; }

    }
}
