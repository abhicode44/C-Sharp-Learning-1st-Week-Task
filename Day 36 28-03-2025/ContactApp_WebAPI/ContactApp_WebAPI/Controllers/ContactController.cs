﻿using ContactApp_WebAPI.Interface.IServices;
using ContactApp_WebAPI.Model.ContactDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        IContactService contactServices;
        public ContactController(IContactService contactServices)
        {
            this.contactServices = contactServices;
        }

        [HttpGet("all-contacts")]
        public IActionResult GetAllContacts()
        {
            var contacts = contactServices.GetAllContacts();
            return Ok(contacts);
        }

        [HttpPost("add-contact")]
        public IActionResult AddContact(AddContactDto addContactDto)
        {
            var contactEntity = contactServices.AddContact(addContactDto);
            return Ok(contactEntity);
        }

        [HttpPut("update-contact-first-name/{contactId:int}")]
        public IActionResult UpdateContactFirstName(int contactId, UpdateContactFirstNameDto updateContactFirstNameDto)
        {
            var contactEntity = contactServices.UpdateContactFirstName(contactId, updateContactFirstNameDto);
            return Ok(contactEntity);
        }

        [HttpPut("update-contact-last-name/{contactId:int}")]
        public IActionResult UpdateContactLastName(int contactId, UpdateContactLastNameDto updateContactLastNameDto)
        {
            var contactEntity = contactServices.UpdateContactLastName(contactId, updateContactLastNameDto);
            return Ok(contactEntity);
        }

        [HttpPut("update-contact-activation/{contactId:int}")]
        public IActionResult UpdateContactActivation(int contactId, UpdateContactActivationDto updateContactActivationDto)
        {
            var contactEntity = contactServices.UpdateContactActivation(contactId, updateContactActivationDto);
            return Ok(contactEntity);
        }

        [HttpDelete("remove-contact-access/{contactId:int}")]
        public IActionResult DeleteContact(int contactId)
        {
            contactServices.DeleteContact(contactId);
            return Ok();
        }
    }
}
