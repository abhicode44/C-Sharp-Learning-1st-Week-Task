using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactApp
{
    internal class MyContext : DbContext
    {
        string connectingstring ;

        public DbSet<User> User { get; set; }
        public DbSet<Contact> Contact { get; set; }

        public DbSet<Contact_Details> Contact_Details { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public MyContext()
        {
            connectingstring = "Data Source=.;Initial Catalog=ContactApp;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectingstring);
        }
    }
}
