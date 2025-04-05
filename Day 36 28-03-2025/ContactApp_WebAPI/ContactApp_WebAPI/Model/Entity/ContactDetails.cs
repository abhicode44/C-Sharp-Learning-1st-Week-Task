using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ContactApp_WebAPI.Model.Entity
{
    public class ContactDetails
    {
        [Key]
        public int ContactDetailsID { get; set; }
        [NotNull]
        public string Type { get; set; }
        [NotNull]
        public string Value { get; set; }
        [NotNull]
        public required bool IsActive { get; set; }
        [NotNull]
        public int ContactId { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public Contact Contact { get; set; }

    }
}
