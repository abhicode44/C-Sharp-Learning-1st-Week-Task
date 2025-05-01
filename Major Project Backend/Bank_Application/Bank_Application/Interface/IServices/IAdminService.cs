using Bank_Application.Model;
using Bank_Application.Model.AdminDto;
using Bank_Application.Model.BankDto;
using Bank_Application.Model.BenificiaryDto;
using Bank_Application.Model.CompanyDto;
using Bank_Application.Model.SalaryDistrubutionDto;
using Bank_Application.Model.TransactionDto;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Application.Interface.IServices
{
    public interface IAdminService
    {
        public Task<List<Admin>> GetAllAdmin();
       
        public Task<string> AddAdmin(AddAdminDto addAdminDto);

        Task<Bank> AddBank(AddBankDto addBankDto);

        Task<List<Bank>> GetAllBank();

        public Task<Admin> updateAdminActivation (int AdminId , AdminActivationDto activationDto);

        public Task<Company> UpdateDocumentVerify(string CompanyEmail, DocumentVerifyDto documentVerifyDto);

        public Task<List<Company>> GetAllApprovedCompanies();

        public Task<List<Company>> GetAllPendingCompanies();

        public Task<List<Benificiary>> GetAllPendingOutBenificiaryBoundCompany();

        public Task<List<Benificiary>> GetAllApprovedOutBenificiaryBoundCompany();

        public Task<Benificiary> VerifyOutBoundCompany(int BenificiaryId, VerifyOutBoundCompanyDto verifyOutBoundCompanyDto);

        public Task<List<Transactionn>> GetAllPendingTransactionRequest();

        public Task<Transactionn> VerifyTransactionRequest(int TransactionId, VerifyTransactionDto verifyTransactionDto);

        public Task<List<Transactionn>> GetAllApprovedTransaction();

        public Task<List<SalaryDistribution>> GetAllPendingSalaryDistributions();

        public Task<List<SalaryDistribution>> GetAllApprovedSalaryDistributions();


        public Task<List<SalaryDistribution>> VerifySalaryDistribution(int salaryDistributionId, VerifySalaryDistributionDto verifySalaryDistributionDto);
    }
}
