using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Bank_Application.Model
{
    public class Bank
    {
        public int BankId { get; set; }
        public string BankName { get; set; }
        public string BankBranchCode { get; set; }

        public string BankBranchName { get; set;}

        public string BankUserName { get; set; }
        public string BankPassword { get; set;}

        



    
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        // Navigation Property

        [JsonIgnore]
        [ValidateNever]
        public Role Role { get; set; }

    }
}
