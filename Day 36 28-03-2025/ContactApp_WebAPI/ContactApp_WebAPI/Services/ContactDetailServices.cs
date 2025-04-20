using System.Collections.Generic;
using ContactApp_WebAPI.Interface;
using ContactApp_WebAPI.Interface.IRepository;
using ContactApp_WebAPI.Interface.IServices;
using ContactApp_WebAPI.Model.ContactDetailsDto;
using ContactApp_WebAPI.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace ContactApp_WebAPI.Services
{
    public class ContactDetailServices : IContactDetailsServices
    {
        //IContactDetailsRepository repository;

        IGenericRepository<ContactDetails> repository;

        public ContactDetailServices(IGenericRepository<ContactDetails> repository)
        {
            this.repository = repository;
        }


        public List<ContactDetails> GetAllContactDetails()
        {
            return repository.GetAll();
        }


        public ContactDetails AddContactDetails(AddContactDetailsDto addContactDetailsDto)
        {
            //return repository.AddContactDetails(addContactDetailsDto);
            var contactDetailsEntity = new ContactDetails
            {
                Type = addContactDetailsDto.Type,
                Value = addContactDetailsDto.Value,
                IsActive = true,
                ContactId = addContactDetailsDto.ContactId
            };

            repository.Add(contactDetailsEntity);
            //context.SaveChanges();
            return contactDetailsEntity;
        }


        public ContactDetails UpdateContactDetailsType(int contactDetailsId, UpdateContactDetailsTypeDto updateContactDetailsTypeDto)
        {
            //return repository.UpdateContactDetailsType(contactDetailsId, updateContactDetailsTypeDto);
            var contactDetailsEntity = repository.GetById(contactDetailsId);
            if (contactDetailsEntity == null)
            {
                throw new KeyNotFoundException($"ContactDetails with ID {contactDetailsId} not found.");
            }

            contactDetailsEntity.Type = updateContactDetailsTypeDto.Type;
            //context.SaveChanges();
            repository.Update(contactDetailsEntity);
            return contactDetailsEntity;
        }


        public ContactDetails UpdateContactDetailsValue(int contactDetailsId, UpdateContactDetailsValueDto updateContactDetailsValueDto)
        {
            //return repository.UpdateContactDetailsValue(contactDetailsId, updateContactDetailsValueDto);
            var contactDetailsEntity = repository.GetById(contactDetailsId);
            if (contactDetailsEntity == null)
            {
                throw new KeyNotFoundException($"ContactDetails with ID {contactDetailsId} not found.");
            }

            contactDetailsEntity.Value = updateContactDetailsValueDto.Value;
            //context.SaveChanges();
            repository.Update(contactDetailsEntity);    
            return contactDetailsEntity;
        }


        public ContactDetails UpdateContactDetailsActivation(int contactDetailsId, UpdateContactDetailsActivationDto updateContactDetailsActivationDto)
        {
            //return repository.UpdateContactDetailsActivation(contactDetailsId, updateContactDetailsActivationDto);
            var contactDetailsEntity = repository.GetById(contactDetailsId);
            if (contactDetailsEntity == null)
            {
                throw new KeyNotFoundException($"ContactDetails with ID {contactDetailsId} not found.");
            }

            contactDetailsEntity.IsActive = updateContactDetailsActivationDto.IsActive;
            //context.SaveChanges();
            repository.Update(contactDetailsEntity);
            return contactDetailsEntity;
        }


        public ContactDetails DeleteContactDetails(int contactDetailsId)
        {
            //return repository.DeleteContactDetails(contactDetailsId);
            var contactDetailsEntity = repository.GetById(contactDetailsId);
            if (contactDetailsEntity == null)
            {
                throw new KeyNotFoundException($"ContactDetails with ID {contactDetailsId} not found.");
            }

            contactDetailsEntity.IsActive = false;
            //context.SaveChanges();
            repository.Delete(contactDetailsEntity);    
            return contactDetailsEntity;
        }
    }
}
