using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Inventory_Management_System.Exceptions;
using Inventory_Management_System.Repository;
using Microsoft.Data.SqlClient;

namespace Inventory_Management_System.Models
{
    internal class TransactionDetails 
    {
        public int TransactionId { get; }
        public int ProductId { get; set; }

        public string Type { get; set; }    

        public int Quantity { get; set; }
        public DateTime TransactionDate { get;  }
        public int InventoryId {  get;  }

        public TransactionDetails(int productid , string type , int quantity )
        {
            ProductId = productid;
            Type = type ;
            Quantity = quantity ;
        }

        string connectionString = ConfigurationManager.AppSettings["connectionStringName"];

        public TransactionDetails() 
        {
            using (SqlConnection connection = new SqlConnection(connectionString)) ;
            TransactionDate = DateTime.Now;
        }

        



    }
}
