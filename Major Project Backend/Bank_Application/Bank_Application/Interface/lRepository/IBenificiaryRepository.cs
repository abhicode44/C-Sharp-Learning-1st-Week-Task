using Bank_Application.Model;
using Bank_Application.Model.BenificiaryDto;

namespace Bank_Application.Interface.lRepository
{
    public interface IBenificiaryRepository
    {
        public Benificiary AddInBoundBenificary (AddInBoundBenificiaryDto addInBoundBenificiaryDto);


        public Benificiary AddOutBoundBenificary(AddOutBoundBenificiaryDto addOutBoundBenificiary);


        public List<Benificiary> GetAllPendingOutBenificiaryBoundCompany();

        public List<Benificiary> GetAllApprovedOutBenificiaryBoundCompany();

        public Benificiary VerifyOutBoundCompany(int BenificiaryId , VerifyOutBoundCompanyDto verifyOutBoundCompanyDto);

        



    }
}
