using ContactApp_WebAPI.Data;
using ContactApp_WebAPI.Interface.IRepository;
using ContactApp_WebAPI.Model.ContactDetailsDto;
using ContactApp_WebAPI.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace ContactApp_WebAPI.Repository
{
    public class ContactDetailsRepository : IContactDetailsRepository
    {
        private readonly MyContext context;

        DbSet<ContactDetails> dbSet;
        public ContactDetailsRepository(MyContext context)
        {
            this.context = context;
            dbSet = context.Set<ContactDetails>();
        }


        public List<ContactDetails> GetAllContactDetails()
        {
            return dbSet.ToList();
        }


        public ContactDetails AddContactDetails(AddContactDetailsDto addContactDetailsDto)
        {
            var contactDetailsEntity = new ContactDetails
            {
                Type = addContactDetailsDto.Type,
                Value = addContactDetailsDto.Value,
                IsActive = true,
                ContactId = addContactDetailsDto.ContactId
            };

            dbSet.Add(contactDetailsEntity);
            context.SaveChanges();
            return contactDetailsEntity;
        }


        public ContactDetails UpdateContactDetailsType(int contactDetailsId, UpdateContactDetailsTypeDto updateContactDetailsTypeDto)
        {
            var contactDetailsEntity = dbSet.Find(contactDetailsId);
            if (contactDetailsEntity == null)
            {
                throw new KeyNotFoundException($"ContactDetails with ID {contactDetailsId} not found.");
            }

            contactDetailsEntity.Type = updateContactDetailsTypeDto.Type;
            context.SaveChanges();
            return contactDetailsEntity;
        }


        public ContactDetails UpdateContactDetailsValue(int contactDetailsId, UpdateContactDetailsValueDto updateContactDetailsValueDto)
        {
            var contactDetailsEntity = dbSet.Find(contactDetailsId);
            if (contactDetailsEntity == null)
            {
                throw new KeyNotFoundException($"ContactDetails with ID {contactDetailsId} not found.");
            }

            contactDetailsEntity.Value = updateContactDetailsValueDto.Value;
            context.SaveChanges();
            return contactDetailsEntity;
        }


        public ContactDetails UpdateContactDetailsActivation(int contactDetailsId, UpdateContactDetailsActivationDto updateContactDetailsActivationDto)
        {
            var contactDetailsEntity = dbSet.Find(contactDetailsId);
            if (contactDetailsEntity == null)
            {
                throw new KeyNotFoundException($"ContactDetails with ID {contactDetailsId} not found.");
            }

            contactDetailsEntity.IsActive = updateContactDetailsActivationDto.IsActive;
            context.SaveChanges();
            return contactDetailsEntity;
        }


        public ContactDetails DeleteContactDetails(int contactDetailsId)
        {
            var contactDetailsEntity = dbSet.Find(contactDetailsId);
            if (contactDetailsEntity == null)
            {
                throw new KeyNotFoundException($"ContactDetails with ID {contactDetailsId} not found.");
            }

            contactDetailsEntity.IsActive = false;
            context.SaveChanges();
            return contactDetailsEntity;
        }
    }
}
