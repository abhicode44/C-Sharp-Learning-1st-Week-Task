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

       
        public   Task<string> AddCompany(AddCompanyDto addCompanyDto);

        public Task<Benificiary> AddInBoundBenificiary(AddInBoundBenificiaryDto addInBoundBenificiaryDto);

        public Task<Benificiary> AddOutBoundBenificiary(AddOutBoundBenificiaryDto addOutBoundBenificiary);
       
        public Task<Transactionn> AddTransaction(AddTransactionDto addTransactionDto);
        
        public Task<List<Employee>> AddEmploye(IFormFile csvFile);

        public Task<List<Employee>> GetAllEmployees();

        public Task<SalaryDistribution> AddSalaryDistribution(AddSalaryDistributionDto addSalaryDistributionDto);

        public Task<List<Benificiary>> GetAllInboundBenificiary();

        public Task<List<Benificiary>> GetAllOutboundBenificiary();

        public Task<List<Benificiary>> GetAllApprovedBenificiary();

    }
}
