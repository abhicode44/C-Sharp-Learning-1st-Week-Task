using System.Collections.Generic;
using ContactApp_WebAPI.Interface;
using ContactApp_WebAPI.Interface.IRepository;
using ContactApp_WebAPI.Interface.IServices;
using ContactApp_WebAPI.Model.ContactDto;
using ContactApp_WebAPI.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace ContactApp_WebAPI.Services
{
    public class ContactServices : IContactService
    {
        //IContactRepository repository;

        IGenericRepository<Contact> repository;
        public ContactServices(IGenericRepository<Contact> repository)
        {
            this.repository = repository;
        }


        public List<Contact> GetAllContacts()
        {
            return repository.GetAll();
        }


        public Contact AddContact(AddContactDto addContactDto)
        {
            // return repository.Add(addContactDto);
            var contactEntity = new Contact
            {
                FirstName = addContactDto.FirstName,
                LastName = addContactDto.LastName,
                IsActive = true,
                UserId = addContactDto.UserId
            };

            repository.Add(contactEntity);
            //context.SaveChanges();
            return contactEntity;

        }


        public Contact UpdateContactFirstName(int contactId, UpdateContactFirstNameDto updateContactFirstNameDto)
        {
            //return repository.UpdateContactFirstName(contactId, updateContactFirstNameDto);
            var contactEntity = repository.GetById(contactId);
            if (contactEntity == null)
            {
                throw new KeyNotFoundException($"Contact with ID {contactId} not found.");
            }

            contactEntity.FirstName = updateContactFirstNameDto.FirstName;
            //context.SaveChanges();
            repository.Update(contactEntity);
            return contactEntity;
        }


        public Contact UpdateContactLastName(int contactId, UpdateContactLastNameDto updateContactLastNameDto)
        {

            //return repository.UpdateContactLastName(contactId, updateContactLastNameDto);

            var contactEntity = repository.GetById(contactId);
            if (contactEntity == null)
            {
                throw new KeyNotFoundException($"Contact with ID {contactId} not found.");
            }

            contactEntity.LastName = updateContactLastNameDto.LastName;
            repository.Update(contactEntity);
            //context.SaveChanges();
            return contactEntity;
        }


        public Contact UpdateContactActivation(int contactId, UpdateContactActivationDto updateContactActivationDto)
        {
            //return repository.UpdateContactActivation(contactId, updateContactActivationDto);
            var contactEntity = repository.GetById(contactId);
            if (contactEntity == null)
            {
                throw new KeyNotFoundException($"Contact with ID {contactId} not found.");
            }

            contactEntity.IsActive = updateContactActivationDto.IsActive;
            //context.SaveChanges();
            repository.Update(contactEntity);
            return contactEntity;
        }


        public Contact DeleteContact(int contactId)
        {
            //return repository.DeleteContact(contactId);
            var contactEntity = repository.GetById(contactId);
            if (contactEntity == null)
            {
                throw new KeyNotFoundException($"Contact with ID {contactId} not found.");
            }

            contactEntity.IsActive = false;
            repository.Delete(contactEntity);
            //context.SaveChanges();
            return contactEntity;
        }
    }
}
