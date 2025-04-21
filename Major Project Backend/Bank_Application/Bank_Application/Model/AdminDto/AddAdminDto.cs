using System.ComponentModel.DataAnnotations;

namespace Bank_Application.Model.AdminDto
{
    public class AddAdminDto
    {
        [Key]
        public int AdminId { get; set; }

        public string AdminUserName { get; set; }

        public string AdminPassword { get; set; }
    }
}
