using System.ComponentModel.DataAnnotations;

namespace Bank_Application.Model
{
    public class SalaryDistribution
    {
        [Key]
        public int SalaryDisbutionId { get; set; }

        [Required]
        public string EmployeeEmail { get; set; }


        [Required]
        public int EmpSalary { get; set; }

        [Required]
        public DateTime SalaryTransactionDate { get; set; } 

        public string SalaryDescription { get; set; }
       
        public bool IsSalaryCredit { get; set; }


        [Required]
        public string CompanyEmail { get; set; }


    }
}
