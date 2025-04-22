using Bank_Application.Interface.GernralRepository;
using Bank_Application.Interface.IServices;
using Bank_Application.Model;
using Bank_Application.Model.AdminDto;
using Bank_Application.Model.CompanyDto;

namespace Bank_Application.Services
{
    public class AdminService : IAdminService
    {   
        IGenericRepository<Admin> repository;
        IGenericRepository<Company> companyRepository;

        public AdminService(IGenericRepository <Admin> adminRepository , IGenericRepository <Company> companyRepository)
        {
            this.repository = adminRepository;
            this.companyRepository = companyRepository;
        }
        public Admin AddAdmin(AddAdminDto addAdminDto)
        {
            var adminEntity = new Admin
            {
                AdminFirstName = addAdminDto.AdminFirstName,
                AdminLastName = addAdminDto.AdminLastName,
                AdminEmail = addAdminDto.AdminEmail,
                AdminPassword = addAdminDto.AdminPassword,
                IsAdminActive = true,
                RoleId =  1 
            };
            repository.Add(adminEntity);
            return adminEntity;
        }



        public Admin updateAdminActivation(int AdminId, AdminActivationDto activationDto)
        {
            var adminEntity = repository.GetById(AdminId);
            if (adminEntity == null)
            {
                throw new KeyNotFoundException($"Admin with ID {AdminId} not found!");
            }

            adminEntity.IsAdminActive = activationDto.IsAdminActive;
            repository.Update(adminEntity);
            return adminEntity;
        }


        public List<Admin> GetAllAdmin()
        {
            return repository.GetAll();
        }


        public Company UpdateDocumentVerify(string CompanyEmail, DocumentVerifyDto documentVerifyDto) {
            var companyEntity = companyRepository.GetByEmail(CompanyEmail);
            if (companyEntity == null)
            {
                throw new Exception($" This Company Email Id  {CompanyEmail} not found.");
            }
            companyEntity.IsDocumentVerified = documentVerifyDto.IsDocumentVerified;
            companyEntity.DocumentStatusDesciption = documentVerifyDto.DocumentStatusDesciption;
            companyRepository.Update(companyEntity);
            return companyEntity;
        }

        public List<Company> GetAllApprovedCompanies()
        {
            return companyRepository.GetAll().Where(c => c.IsDocumentVerified == true).ToList();
        }

        public List<Company> GetAllPendingCompanies()
        {
            return companyRepository.GetAll().Where(c => c.IsDocumentVerified == false).ToList();
        }

    }
}
