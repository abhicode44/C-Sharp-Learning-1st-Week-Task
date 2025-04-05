using ContactApp_WebAPI.Interface.IRepository;
using ContactApp_WebAPI.Interface.IServices;
using ContactApp_WebAPI.Model.ContactDto;
using ContactApp_WebAPI.Model.Entity;

namespace ContactApp_WebAPI.Services
{
    public class ContactServices : IContactService
    {
        IContactRepository repository;
        public ContactServices(IContactRepository repository)
        {
            this.repository = repository;
        }


        public List<Contact> GetAllContacts()
        {
            return repository.GetAllContacts();
        }


        public Contact AddContact(AddContactDto addContactDto)
        {
            return repository.AddContact(addContactDto);
        }


        public Contact UpdateContactFirstName(int contactId, UpdateContactFirstNameDto updateContactFirstNameDto)
        {
            return repository.UpdateContactFirstName(contactId, updateContactFirstNameDto);
        }


        public Contact UpdateContactLastName(int contactId, UpdateContactLastNameDto updateContactLastNameDto)
        {
            return repository.UpdateContactLastName(contactId, updateContactLastNameDto);
        }


        public Contact UpdateContactActivation(int contactId, UpdateContactActivationDto updateContactActivationDto)
        {
            return repository.UpdateContactActivation(contactId, updateContactActivationDto);
        }


        public Contact DeleteContact(int contactId)
        {
            return repository.DeleteContact(contactId);
        }
    }
}
