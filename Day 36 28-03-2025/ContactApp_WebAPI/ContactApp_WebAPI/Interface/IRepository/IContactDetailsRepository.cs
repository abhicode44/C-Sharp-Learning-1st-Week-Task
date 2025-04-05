using ContactApp_WebAPI.Model.ContactDetailsDto;
using ContactApp_WebAPI.Model.Entity;

namespace ContactApp_WebAPI.Interface.IRepository
{
    public interface IContactDetailsRepository
    {
        public List<ContactDetails> GetAllContactDetails();
        public ContactDetails AddContactDetails(AddContactDetailsDto addContactDetailsDto);
        public ContactDetails UpdateContactDetailsType(int contactDetailsId, UpdateContactDetailsTypeDto updateContactDetailsTypeDto);
        public ContactDetails UpdateContactDetailsValue(int contactDetailsId, UpdateContactDetailsValueDto updateContactDetailsValueDto);
        public ContactDetails UpdateContactDetailsActivation(int contactDetailsId, UpdateContactDetailsActivationDto updateContactDetailsActivationDto);
        public ContactDetails DeleteContactDetails(int contactDetailsId);
    }
}
