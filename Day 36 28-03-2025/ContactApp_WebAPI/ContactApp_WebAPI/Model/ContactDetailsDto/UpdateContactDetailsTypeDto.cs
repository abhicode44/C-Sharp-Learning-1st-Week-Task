using System.Diagnostics.CodeAnalysis;

namespace ContactApp_WebAPI.Model.ContactDetailsDto
{
    public class UpdateContactDetailsTypeDto
    {
        [NotNull]
        public string Type { get; set; }
    }
}
