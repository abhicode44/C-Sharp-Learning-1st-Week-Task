using Bank_Application.Model;
using Bank_Application.Model.AdminDto;
using Bank_Application.Model.BenificiaryDto;
using Bank_Application.Model.CompanyDto;
using Bank_Application.Model.SalaryDistrubutionDto;
using Bank_Application.Model.TransactionDto;

namespace Bank_Application.Interface.IServices
{
    public interface IAdminService
    {
        public List<Admin> GetAllAdmin();
        public Admin AddAdmin(AddAdminDto addAdminDto);
        public Admin updateAdminActivation (int AdminId , AdminActivationDto activationDto);

        public Company UpdateDocumentVerify(string CompanyEmail, DocumentVerifyDto documentVerifyDto);

        public List<Company> GetAllApprovedCompanies();

        public List<Company> GetAllPendingCompanies();

        public List<Benificiary> GetAllPendingOutBenificiaryBoundCompany();

        public List<Benificiary> GetAllApprovedOutBenificiaryBoundCompany();

        public Benificiary VerifyOutBoundCompany(int BenificiaryId, VerifyOutBoundCompanyDto verifyOutBoundCompanyDto);

        public List<Transactionn> GetAllPendingTransactionRequest();

        public Transactionn VerifyTransactionRequest(int TransactionId, VerifyTransactionDto verifyTransactionDto);

        public List<Transactionn> GetAllApprovedTransaction();

        public List<SalaryDistribution> GetAllPendingSalaryDistributions();

        public List<SalaryDistribution> GetAllApprovedSalaryDistributions();


        public List<SalaryDistribution> VerifySalaryDistribution(int salaryDistributionId, VerifySalaryDistributionDto verifySalaryDistributionDto);
    }
}
