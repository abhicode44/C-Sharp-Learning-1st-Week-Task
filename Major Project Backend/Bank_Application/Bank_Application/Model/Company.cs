using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Application.Model
{
    public class Company
    {
       

        public string CompanyName { get; set; }

        [Key]
        public string CompanyEmail { get; set; }

        public string CompanyAddress { get; set; }


        public string CompanyAccountNumber { get; set; }

        public string CompanyAccount_IFSCCode { get; set; }

        public string CompanyPanCardFile { get; set; }
        
        public string CompanyAadharCardFile { get; set; }

        public string CompanyOfficalDocumnet { get; set; }

        public string CompanyProfilePhoto { get; set; }

        public int CompanyBalance { get; set; }
        public bool IsCompanyLoginActive { get; set; }

        public bool IsDocumentVerified { get; set; }

        public bool IsOTPVerified { get; set; }

        public string DocumentStatusDesciption { get; set; }

        public DateTime CreatedAt { get; set; }



        [ForeignKey("Role")]
        public int RoleId { get; set; }

        // Navigation Property
        public Role Role { get; set; }


    }
}
