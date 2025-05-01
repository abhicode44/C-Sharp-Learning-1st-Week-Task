using System.ComponentModel.DataAnnotations;

namespace Bank_Application.Model.LoginDto
{
    public class LoginDto
    {
        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }
    }
}
