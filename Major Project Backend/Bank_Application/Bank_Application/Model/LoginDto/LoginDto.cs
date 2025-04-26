using System.ComponentModel.DataAnnotations;

namespace Bank_Application.Model.LoginDto
{
    public class LoginDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
