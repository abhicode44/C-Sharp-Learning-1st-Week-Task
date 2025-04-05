using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Many_To_Many_Relation_BookAuthorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Many_To_Many_Relation_BookAuthorApp.DataBase
{
    internal class MyContext : DbContext
    {
        public string ConnectingString;

        public DbSet<Author> Author { get; set; }
        public DbSet<Books> Books { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public MyContext()
        {
            ConnectingString = "Data Source=.;Initial Catalog=ManyToMany;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectingString);
        }



    }
}
