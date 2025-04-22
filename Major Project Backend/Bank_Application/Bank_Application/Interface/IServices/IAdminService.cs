using Bank_Application.Model;
using Bank_Application.Model.AdminDto;
using Bank_Application.Model.CompanyDto;

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
    }
}
