using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Models
{
    internal class User
    {
        [Key]

        public int User_ID { get; set; }


        public string F_Name { get; set; }
        public string L_Name { get; set; }

        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        
    }
}
