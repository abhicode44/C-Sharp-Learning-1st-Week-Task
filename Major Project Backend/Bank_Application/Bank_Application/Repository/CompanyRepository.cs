using Bank_Application.Data;
using Bank_Application.Interface.lRepository;
using Bank_Application.Model;
using Bank_Application.Model.BankDto;
using Bank_Application.Model.CompanyDto;
using Microsoft.EntityFrameworkCore;

namespace Bank_Application.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly MyContext context;
        DbSet<Company> dbset;

        public CompanyRepository(MyContext context)
        {
            this.context = context;
            dbset = context.Set<Company>();
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
                IsOTPVerified = false ,
                IsDocumentVerified = false ,
                IsCompanyLoginActive = true ,
                CreatedAt = DateTime.Now,

            };

            dbset.Add(companyEntity);
            context.SaveChanges();
            return companyEntity;
        }
    }
}
