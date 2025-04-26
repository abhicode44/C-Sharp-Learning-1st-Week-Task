using Bank_Application.Data;
using Bank_Application.Interface.lRepository;
using Bank_Application.Model;
using Bank_Application.Model.BenificiaryDto;
using Microsoft.EntityFrameworkCore;

namespace Bank_Application.Repository
{
    public class BenificiaryRepository : IBenificiaryRepository 
    {

        private readonly MyContext context;
        DbSet<Benificiary> dbset;

        public BenificiaryRepository(MyContext context)
        {
            this.context = context;
            dbset = context.Set<Benificiary>();
        }

        public Benificiary AddInBoundBenificary(AddInBoundBenificiaryDto addInBoundBenificiaryDto)
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
            dbset.Add(benificiaryEntity);
            context.SaveChanges();
            return benificiaryEntity;
            
        }

        public Benificiary AddOutBoundBenificary(AddOutBoundBenificiaryDto addOutBoundBenificiary)
        {
            var benificiaryEntity = new Benificiary
            {
                BenificiaryCompanyName = addOutBoundBenificiary.BenificiaryCompanyName,
                BenificiaryEmail = addOutBoundBenificiary.BenificiaryEmail,
                BenificiaryCompanyAccountNumber = addOutBoundBenificiary.BenificiaryCompanyAccountNumber,
                BenificiaryCompanyIFSCcode = addOutBoundBenificiary.BenificiaryCompanyIFSCcode,
                CompanyEmail = addOutBoundBenificiary.CompanyEmail,
                BenificiaryType = "OutBound",
                IsBenificiaryApproved = false,
                CreatedAt = DateTime.Now
            };
            dbset.Add(benificiaryEntity);
            context.SaveChanges();
            return benificiaryEntity;

        }

        public List<Benificiary> GetAllApprovedOutBenificiaryBoundCompany()
        {
            return dbset.ToList();
        }

        public List<Benificiary> GetAllPendingOutBenificiaryBoundCompany ()
        {
            return dbset.ToList();
        }

        
           

        public Benificiary VerifyOutBoundCompany(int BenificiaryId, VerifyOutBoundCompanyDto verifyOutBoundCompanyDto)
        {
            var benificiaryEntity = dbset.Find(BenificiaryId);
            if (benificiaryEntity == null)
            {
                throw new KeyNotFoundException($"Benificiary with ID {BenificiaryId} not found.");
            }
            benificiaryEntity.IsBenificiaryApproved = verifyOutBoundCompanyDto.IsBenificiaryApproved;
            context.SaveChanges();
            return benificiaryEntity;
        }
    }

}
