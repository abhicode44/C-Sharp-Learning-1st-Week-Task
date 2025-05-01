using System.ComponentModel.DataAnnotations;

namespace Bank_Application.Model.AdminDto
{
    public class AddAdminDto
    {

        public string AdminFirstName { get; set; }

        public string AdminLastName { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }

        public bool IsAdminActive { get; set; }

        public IFormFile AdminProfilePhoto { get; set; }


    }
}
