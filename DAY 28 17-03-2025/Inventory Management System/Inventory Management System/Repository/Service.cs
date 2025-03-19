using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Inventory_Management_System.Repository
{
    internal interface Service
    {
        public void ChooseMenu(SqlConnection connection);
        public void Add(SqlConnection connection);
        public void Delete(SqlConnection connection);
        public void Update(SqlConnection connection);
        public void View_Specific_Details(SqlConnection connection);
        public void View_All_Details(SqlConnection connection);

    }
}
