using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Many_To_Many_Relation_BookAuthorApp.Models
{
    internal class Books
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }

        public List<Author> Authors { get; set; }

    }
}
