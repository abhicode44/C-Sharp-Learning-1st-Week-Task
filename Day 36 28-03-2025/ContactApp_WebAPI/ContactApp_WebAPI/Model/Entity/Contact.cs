using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

namespace ContactApp_WebAPI.Model.Entity
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [NotNull]
        public string FirstName { get; set; }
        [NotNull]
        public string LastName { get; set; }
        [NotNull]
        public required bool IsActive { get; set; }
        [NotNull]
        public int UserId { get; set; }

        [JsonIgnore]
        [ValidateNever]
        public User User { get; set; }

    }
}
