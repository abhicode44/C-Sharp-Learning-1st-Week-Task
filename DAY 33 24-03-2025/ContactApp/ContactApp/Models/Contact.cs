using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Models
{
    internal class Contact
    {
        [Key]
        public int Contact_Id { get; set; }

        public string F_Name { get; set; }

        public string L_Name { get; set; }

        public bool IsActive { get; set; }

        public string Contact_Details { get; set; }

    }
}
