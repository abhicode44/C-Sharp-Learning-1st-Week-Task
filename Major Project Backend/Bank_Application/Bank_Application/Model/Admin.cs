using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

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


        public string AdminProfilePhoto { get; set; }


        

        [ForeignKey("Role")]
        public int  RoleId  { get; set; }


        [JsonIgnore]
        [ValidateNever]
        public Role Role { get; set; }


        

    }
}
