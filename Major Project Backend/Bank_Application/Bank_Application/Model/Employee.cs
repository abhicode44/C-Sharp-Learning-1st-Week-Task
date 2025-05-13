using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Application.Model
{
    public class Employee
    {
        [Key]
       public string EmpEmail { get; set; }

        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        

        public string EmpPhone { get; set; }

        public string EmpAddress { get; set; }

        public string EmpAccountNumber { get; set; }

        public string EmpIFSCCode { get; set; }

        public string EmpDepartment { get; set; }
        public string EmpDesignation  { get; set; }
        public int EmployeeSalary { get; set; }

        public string CompanyEmail { get; set; }

      






    }
}
