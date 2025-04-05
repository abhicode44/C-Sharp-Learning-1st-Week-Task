using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        
        public int User_ID { get; set; }  // Reference to Contact table

        // Navigation Property
        [ForeignKey("User_ID")]
        public  User User { get; set; }
        


    }
}
