using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Application.Model
{
    public class Benificiary
    {
        [Key]
        public int BenificaryID { get; set; }

        public string BenificiaryType { get; set; }

        public string BenificiaryCompanyName { get; set; }

        public string BenificiaryEmail { get; set; }

        public string BenificiaryCompanyAccountNumber { get; set; }

        public string BenificiaryCompanyIFSCcode { get; set; }

        public bool IsBenificiaryApproved {  get; set; }    

        public DateTime CreatedAt { get; set; }

        public string CompanyEmail { get; set; }

        

        
    }
}
