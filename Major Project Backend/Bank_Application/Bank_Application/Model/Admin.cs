using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Application.Model
{
    public class Admin
    {
        public int AdminId { get; set; }

        public string AdminUserName { get; set; }

        public string AdminPassword { get; set; }



        [ForeignKey("Role")]
        public int RoleId { get; set; }

        // Navigation Property
        public Role Role { get; set; }

      

    }
}
