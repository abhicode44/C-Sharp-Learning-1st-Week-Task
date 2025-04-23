using Bank_Application.Model;
using Bank_Application.Model.BenificiaryDto;
using Bank_Application.Model.CompanyDto;

namespace Bank_Application.Interface.IServices
{
    public interface ICompanyService
    {
        

        public Company AddCompany(AddCompanyDto addCompanyDto);

        public Benificiary AddInBoundBenificiary(AddInBoundBenificiaryDto addInBoundBenificiaryDto);

        public Benificiary AddOutBoundBenificiary(AddOutBoundBenificiaryDto addOutBoundBenificiary);
       


    }
}
