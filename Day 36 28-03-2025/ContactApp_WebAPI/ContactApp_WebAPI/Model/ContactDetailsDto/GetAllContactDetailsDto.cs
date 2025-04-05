using ContactApp_WebAPI.Model.Entity;
using System.Diagnostics.CodeAnalysis;

namespace ContactApp_WebAPI.Model.ContactDetailsDto
{
    public class GetAllContactDetailsDto
    {
        [NotNull]
        public string Type { get; set; }
        [NotNull]
        public string Value { get; set; }
        [NotNull]
        public bool IsActive { get; }
        [NotNull]
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
