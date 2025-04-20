using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Application.Model
{
    public class Benificary
    {
        public int BenificaryID { get; set; }

        public string BenificiaryType { get; set; }

        public string BenificiaryCompanyName { get; set; }

        public string BenificiaryCompanyAccountNumber { get; set; }

        public string BenificiaryCompanyIFSCcode { get; set; }


        public string CompanyEmail { get; set; }

        [ForeignKey("CompanyEmail")]
        public Company Company { get; set; }



    }
}
