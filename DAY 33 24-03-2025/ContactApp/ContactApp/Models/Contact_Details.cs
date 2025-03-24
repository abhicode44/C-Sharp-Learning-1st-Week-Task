using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ContactApp.Models
{
    internal class Contact_Details
    {
        [Key]
        public string Contact_Details_Id { get; set; }
        public string Type { get; set; }

        public string Values { get; set; }

    }
}
