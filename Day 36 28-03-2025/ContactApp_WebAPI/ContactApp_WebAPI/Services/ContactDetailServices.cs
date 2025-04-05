using ContactApp_WebAPI.Interface.IRepository;
using ContactApp_WebAPI.Interface.IServices;
using ContactApp_WebAPI.Model.ContactDetailsDto;
using ContactApp_WebAPI.Model.Entity;

namespace ContactApp_WebAPI.Services
{
    public class ContactDetailServices : IContactDetailsServices
    {
        IContactDetailsRepository repository;
        public ContactDetailServices(IContactDetailsRepository repository)
        {
            this.repository = repository;
        }


        public List<ContactDetails> GetAllContactDetails()
        {
            return repository.GetAllContactDetails();
        }


        public ContactDetails AddContactDetails(AddContactDetailsDto addContactDetailsDto)
        {
            return repository.AddContactDetails(addContactDetailsDto);
        }


        public ContactDetails UpdateContactDetailsType(int contactDetailsId, UpdateContactDetailsTypeDto updateContactDetailsTypeDto)
        {
            return repository.UpdateContactDetailsType(contactDetailsId, updateContactDetailsTypeDto);
        }


        public ContactDetails UpdateContactDetailsValue(int contactDetailsId, UpdateContactDetailsValueDto updateContactDetailsValueDto)
        {
            return repository.UpdateContactDetailsValue(contactDetailsId, updateContactDetailsValueDto);
        }


        public ContactDetails UpdateContactDetailsActivation(int contactDetailsId, UpdateContactDetailsActivationDto updateContactDetailsActivationDto)
        {
            return repository.UpdateContactDetailsActivation(contactDetailsId, updateContactDetailsActivationDto);
        }


        public ContactDetails DeleteContactDetails(int contactDetailsId)
        {
            return repository.DeleteContactDetails(contactDetailsId);
        }
    }
}
