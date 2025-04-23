using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Application.Model
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        public string AdminFirstName { get; set; }

        public string AdminLastName { get; set; } 

        public string AdminEmail { get; set; } 

        public string AdminPassword { get; set; }

        public bool IsAdminActive { get; set; } 


        

        [ForeignKey("Role")]
        public int  RoleId  { get; set; }

        
        public Role Role { get; set; }


        

    }
}
