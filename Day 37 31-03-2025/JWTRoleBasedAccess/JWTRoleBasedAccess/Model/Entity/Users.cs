using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JWTRoleBasedAccess.Model.Entity
{
    public class Users
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        
    }
}
