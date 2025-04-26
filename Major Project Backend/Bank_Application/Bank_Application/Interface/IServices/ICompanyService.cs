using Bank_Application.Model;
using Bank_Application.Model.BenificiaryDto;
using Bank_Application.Model.CompanyDto;
using Bank_Application.Model.SalaryDistrubutionDto;
using Bank_Application.Model.TransactionDto;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Bank_Application.Interface.IServices
{
    public interface ICompanyService
    {
        

        public Company AddCompany(AddCompanyDto addCompanyDto);

        public Benificiary AddInBoundBenificiary(AddInBoundBenificiaryDto addInBoundBenificiaryDto);

        public Benificiary AddOutBoundBenificiary(AddOutBoundBenificiaryDto addOutBoundBenificiary);
       
        public Transactionn AddTransaction(AddTransactionDto addTransactionDto);
        
        public List<Employee> AddEmploye(IFormFile csvFile);

        public List<Employee> GetAllEmployees();

        public SalaryDistribution AddSalaryDistribution(AddSalaryDistributionDto addSalaryDistributionDto);

    }
}
