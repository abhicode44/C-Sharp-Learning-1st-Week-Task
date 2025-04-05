using System.Diagnostics.CodeAnalysis;

namespace ContactApp_WebAPI.Model.ContactDto
{
    public class UpdateContactActivationDto
    {
        [NotNull]
        public bool IsActive { get; }
    }
}
