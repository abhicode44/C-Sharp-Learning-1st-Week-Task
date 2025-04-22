using Bank_Application.Model;
using Bank_Application.Model.CompanyDto;

namespace Bank_Application.Interface.lRepository
{
    public interface ICompanyRepository
    {
        public Company AddCompany(AddCompanyDto addCompanyDto);

        public Company UpdateDocumentVerify(string CompanyEmail , DocumentVerifyDto documentVerifyDto);

        public List<Company> GetAllApprovedCompanies();

        public List<Company> GetAllPendingCompanies();

    }
}
