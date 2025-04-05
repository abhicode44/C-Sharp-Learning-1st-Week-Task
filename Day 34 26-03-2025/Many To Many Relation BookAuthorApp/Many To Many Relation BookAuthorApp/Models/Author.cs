using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Many_To_Many_Relation_BookAuthorApp.Models
{
    internal class Author
    {
        [Key] 
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        public List<Books> Books { get; set; }

    }
}
