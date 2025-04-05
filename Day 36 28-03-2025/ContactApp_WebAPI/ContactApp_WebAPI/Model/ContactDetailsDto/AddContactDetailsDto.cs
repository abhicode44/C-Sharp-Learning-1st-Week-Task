using ContactApp_WebAPI.Model.Entity;
using System.Diagnostics.CodeAnalysis;

namespace ContactApp_WebAPI.Model.ContactDetailsDto
{
    public class AddContactDetailsDto
    {
        [NotNull]
        public string Type { get; set; }
        [NotNull]
        public string Value { get; set; }
        
        [NotNull]
        public int ContactId { get; set; }
        
    }
}
