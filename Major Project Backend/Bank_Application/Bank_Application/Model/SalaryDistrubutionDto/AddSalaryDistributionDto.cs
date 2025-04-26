using System.ComponentModel.DataAnnotations;

namespace Bank_Application.Model.SalaryDistrubutionDto
{
    public class AddSalaryDistributionDto
    {
        [Required]
        public string EmployeeEmail { get; set; }


        [Required]
        public int EmpSalary { get; set; }

        [Required]
        public string CompanyEmail { get; set; }
    }
}
