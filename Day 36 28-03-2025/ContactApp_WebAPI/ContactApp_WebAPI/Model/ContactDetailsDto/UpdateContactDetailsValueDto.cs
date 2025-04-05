using System.Diagnostics.CodeAnalysis;

namespace ContactApp_WebAPI.Model.ContactDetailsDto
{
    public class UpdateContactDetailsValueDto
    {

        [NotNull]
        public string Value { get; set; }
    }
}
