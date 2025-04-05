using ContactApp_WebAPI.Model.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ContactApp_WebAPI.Model.ContactDto
{
    public class AddContactDto
    {
        [NotNull]
        public string FirstName { get; set; }
        [NotNull]
        public string LastName { get; set; }
        [NotNull]
        public bool IsActive { get; }
        [NotNull]

        
        public int UserId { get; set; }


       
    }
}
