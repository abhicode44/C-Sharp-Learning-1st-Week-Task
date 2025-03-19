using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management_System.Exceptions;
using Inventory_Management_System.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace Inventory_Management_System.Models
{
    internal class ProductDetails  

    {
        public int ProductId { get;  }
        public string Name { get; set; }
        public string Description { get; set; }
        public int  Quantity { get; set; }
        public int Price { get; set; }
        public int InventoryId { get; set;  }

        public ProductDetails( string name , string description , int quantity , int price , int inventoryid ) 
        {   
            Name = name;
            Description = description;
            Quantity = quantity;
            Price = price;  
            InventoryId = inventoryid;
        }

        string connectionString = ConfigurationManager.AppSettings["connectionStringName"];


        public ProductDetails () 
        {
            using (SqlConnection connection = new SqlConnection(connectionString)) ;
        }



    }
}
