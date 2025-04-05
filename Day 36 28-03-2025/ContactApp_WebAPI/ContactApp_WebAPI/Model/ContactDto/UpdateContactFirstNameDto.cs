using System.Diagnostics.CodeAnalysis;

namespace ContactApp_WebAPI.Model.ContactDto
{
    public class UpdateContactFirstNameDto
    {
        [NotNull]
        public string FirstName { get; set; }
    }
}
