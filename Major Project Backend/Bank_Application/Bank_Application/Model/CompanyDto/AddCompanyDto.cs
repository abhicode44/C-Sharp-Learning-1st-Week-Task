using System.ComponentModel.DataAnnotations;

namespace Bank_Application.Model.CompanyDto
{
    public class AddCompanyDto
    {
        public string CompanyName { get; set; }

        [Key]
        public string CompanyEmail { get; set; }

        public string CompanyPassword { get; set; }

        public string CompanyAddress { get; set; }


        public string CompanyAccountNumber { get; set; }

        public string CompanyAccount_IFSCCode { get; set; }

        public  IFormFile CompanyPanCardFile { get; set; }

        public IFormFile CompanyAadharCardFile { get; set; }

        public IFormFile CompanyOfficalDocumnet { get; set; }

        public IFormFile CompanyProfilePhoto { get; set; }

        

        
    }
}
