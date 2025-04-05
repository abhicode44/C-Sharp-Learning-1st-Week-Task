using ContactApp_WebAPI.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace ContactApp_WebAPI.Data
{

    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<ContactDetails> Contact_Details { get; set; }


    }
}
