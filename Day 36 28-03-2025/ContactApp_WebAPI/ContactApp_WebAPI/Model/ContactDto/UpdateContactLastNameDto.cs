using System.Diagnostics.CodeAnalysis;

namespace ContactApp_WebAPI.Model.ContactDto
{
    public class UpdateContactLastNameDto
    {
        [NotNull]
        public string LastName { get; set; }
    }
}
