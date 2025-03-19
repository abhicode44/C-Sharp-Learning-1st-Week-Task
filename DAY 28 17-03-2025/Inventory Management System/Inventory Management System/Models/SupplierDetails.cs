using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management_System.Exceptions;
using Inventory_Management_System.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;

namespace Inventory_Management_System.Models
{
    internal class SupplierDetails 
    {
        public int SupplierId { get; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Information { get; set; }
        public int InventoryId { get; set; }


        public SupplierDetails( string name , string contact , string information , int inventoryid) 
        {
            Name = name;
            Contact = contact;
            Information = information;
            InventoryId = inventoryid;
        }

        string connectionString = ConfigurationManager.AppSettings["connectionStringName"];

        public SupplierDetails() 
        {
            using (SqlConnection connection = new SqlConnection(connectionString)) ;
        }


    }
}
