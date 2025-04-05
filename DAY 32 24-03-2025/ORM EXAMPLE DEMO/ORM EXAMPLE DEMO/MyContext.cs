using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ORM_EXAMPLE_DEMO
{
    internal class MyContext : DbContext
    {
        string connectingstring;
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Department { get; set; }


        public MyContext(DbContextOptions <MyContext> options) : base(options) { }

        public MyContext()
        {
            connectingstring = "Data Source=.;Initial Catalog=\"ORM EXAMPLE\";Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectingstring);
        }

    }
}
