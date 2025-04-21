using Bank_Application.Interface.GernralRepository;
using Bank_Application.Interface.IServices;
using Bank_Application.Model;
using Bank_Application.Model.CompanyDto;

namespace Bank_Application.Services
{
    public class CompanyService  : ICompanyService
    {
        IGenericRepository<Company> repository;

        public CompanyService(IGenericRepository<Company> companyRepository)
        {
            this.repository = companyRepository;
        }

        public Company AddCompany(AddCompanyDto addCompanyDto)
        {
            var companyEntity = new Company
            {
                CompanyName = addCompanyDto.CompanyName,
                CompanyEmail = addCompanyDto.CompanyEmail,
                CompanyAddress = addCompanyDto.CompanyAddress,
                CompanyAccountNumber = addCompanyDto.CompanyAccountNumber,
                CompanyAccount_IFSCCode = addCompanyDto.CompanyAccount_IFSCCode,
                CompanyBalance = addCompanyDto.CompanyBalance,
                CompanyAadharCardFile = addCompanyDto.CompanyAadharCardFile,
                CompanyPanCardFile = addCompanyDto.CompanyPanCardFile,
                RoleId = 3,
                IsOTPVerified = false,
                IsDocumentVerified = false,
                IsCompanyLoginActive = true,
                CreatedAt = DateTime.Now,
            };
            repository.Add(companyEntity);
            return companyEntity;

        }
    }
}
