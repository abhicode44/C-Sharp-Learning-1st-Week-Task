using ContactApp_WebAPI.Model.ContactDto;
using ContactApp_WebAPI.Model.Entity;

namespace ContactApp_WebAPI.Interface.IServices
{
    public interface IContactService
    {
        public List<Contact> GetAllContacts();
        public Contact AddContact(AddContactDto addContactDto);
        public Contact UpdateContactFirstName(int contactId, UpdateContactFirstNameDto updateContactFirstNameDto);
        public Contact UpdateContactLastName(int contactId, UpdateContactLastNameDto updateContactLastNameDto);
        public Contact UpdateContactActivation(int contactId, UpdateContactActivationDto updateContactActivationDto);
        public Contact DeleteContact(int contactId);
    }
}
