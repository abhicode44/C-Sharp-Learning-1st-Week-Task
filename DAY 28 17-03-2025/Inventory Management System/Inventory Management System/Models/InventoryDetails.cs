using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management_System.Repository;
using Microsoft.Data.SqlClient;

namespace Inventory_Management_System.Models
{
    internal class InventoryDetails
    {
        public int InventoryId { get; set; }
        public string Location { get; set; }



        public InventoryDetails(string location)
        {
            Location = location;
        }

        public InventoryDetails() { }

        
    }

}
