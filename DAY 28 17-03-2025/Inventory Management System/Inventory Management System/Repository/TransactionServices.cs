using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Inventory_Management_System.Repository
{
    internal interface TransactionServices
    { 
        public void ChooseMenu(SqlConnection connection);
        public void Add_Stock(SqlConnection connection);
        public void Remove_Stock(SqlConnection connection);
        public void View_All_Details(SqlConnection connection);


    }

}
