using System.ComponentModel.DataAnnotations;

namespace Bank_Application.Model.CompanyDto
{
    public class AddCompanyDto
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
        

        
    }
}
