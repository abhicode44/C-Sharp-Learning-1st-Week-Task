using Bank_Application.Interface.GernralRepository;
using Bank_Application.Interface.IServices;
using Bank_Application.Model;
using Bank_Application.Model.BenificiaryDto;
using Bank_Application.Model.CompanyDto;

namespace Bank_Application.Services
{
    public class CompanyService  : ICompanyService
    {
        IGenericRepository<Company> repository;
        IGenericRepository<Benificiary> benificaryRepository;

        public CompanyService(IGenericRepository<Company> companyRepository , IGenericRepository<Benificiary> benificaryRepository)
        {
            this.repository = companyRepository;
            this.benificaryRepository = benificaryRepository;
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
                CompanyOfficalDocumnet = addCompanyDto.CompanyOfficalDocumnet,
                CompanyProfilePhoto = addCompanyDto.CompanyProfilePhoto,
                RoleId = 3,
                IsOTPVerified = false,
                IsDocumentVerified = false,
                IsCompanyLoginActive = true,
                DocumentStatusDesciption = "",
                CreatedAt = DateTime.Now,
            };
            repository.Add(companyEntity);
            return companyEntity;

        }

       public Benificiary AddInBoundBenificiary (AddInBoundBenificiaryDto addInBoundBenificiaryDto) 
        {
            var benificiaryEntity = new Benificiary
            {
                BenificiaryCompanyName = addInBoundBenificiaryDto.BenificiaryCompanyName,
                BenificiaryEmail = addInBoundBenificiaryDto.BenificiaryEmail,
                BenificiaryCompanyAccountNumber = addInBoundBenificiaryDto.BenificiaryCompanyAccountNumber,
                BenificiaryCompanyIFSCcode = addInBoundBenificiaryDto.BenificiaryCompanyIFSCcode,
                CompanyEmail = addInBoundBenificiaryDto.CompanyEmail,
                BenificiaryType = "Inbound",
                IsBenificiaryApproved = true,
                CreatedAt = DateTime.Now
            };
            benificaryRepository.Add(benificiaryEntity);
            return benificiaryEntity;

        }

        public Benificiary AddOutBoundBenificiary(AddOutBoundBenificiaryDto addOutBoundBenificiary)
        {
            var benificiaryEntity = new Benificiary
            {
                BenificiaryCompanyName = addOutBoundBenificiary.BenificiaryCompanyName,
                BenificiaryEmail = addOutBoundBenificiary.BenificiaryEmail,
                BenificiaryCompanyAccountNumber = addOutBoundBenificiary.BenificiaryCompanyAccountNumber,
                BenificiaryCompanyIFSCcode = addOutBoundBenificiary.BenificiaryCompanyIFSCcode,
                CompanyEmail = addOutBoundBenificiary.CompanyEmail,
                BenificiaryType = "Outbound",
                IsBenificiaryApproved = false,
                CreatedAt = DateTime.Now
            };
            benificaryRepository.Add(benificiaryEntity) ;
            return benificiaryEntity ;
        }



    }
}
