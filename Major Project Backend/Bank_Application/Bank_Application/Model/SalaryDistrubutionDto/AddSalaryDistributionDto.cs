using System.ComponentModel.DataAnnotations;

namespace Bank_Application.Model.SalaryDistrubutionDto
{
    public class AddSalaryDistributionDto
    {

        public List<string>? EmployeeEmails { get; set; } // List of employee emails for batch processing
        public List<int> EmpSalaries { get; set; }        // List of corresponding salaries
        public List<string> CompanyEmails { get; set; }  // List of company emails corresponding to each employee

        public bool IsValid()
        {
            return EmployeeEmails.Count == CompanyEmails.Count && EmployeeEmails.Count == EmpSalaries.Count;
        }
    }
}
