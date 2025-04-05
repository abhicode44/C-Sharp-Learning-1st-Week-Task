using System.Diagnostics.CodeAnalysis;

namespace ContactApp_WebAPI.Model.ContactDetailsDto
{
    public class UpdateContactDetailsActivationDto
    {
        [NotNull]
        public required bool IsActive { get; set; }
    }
}
