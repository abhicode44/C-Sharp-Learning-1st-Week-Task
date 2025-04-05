using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_EXAMPLE_DEMO
{
    internal class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeDesignation { get; set; }

        public int EmployeeContatc{ get; set; }

        public int EmployeeSalary { get; set; }

        public Department Department { get; set; }

    }
}
