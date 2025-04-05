using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ContactApp.Models
{
    internal class Contact_Details
    {
        [Key]
        public int  Contact_Details_Id { get; set; }
        public string Type { get; set; }

        public string Values { get; set; }

        public int Contact_Id { get; set; }  // Reference to Contact table


        // Navigation Property
        [ForeignKey("Contact_Id")]
        public  Contact Contact { get; set; }

    }
}
