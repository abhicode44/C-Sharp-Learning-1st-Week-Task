using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Interface;
using ContactApp.Repository;

namespace ContactApp.Services
{
    internal class contactService : IContactService
    {
        contactRepository contactRepository = new contactRepository();

        public void AddContact()
        {
            contactRepository.AddContact();
        }
        public void RemoveContact()
        {
            contactRepository.RemoveContact();
        }
        public void UpdateContact()
        {
            contactRepository.UpdateContact();
        }
        public void ViewContactDeatailsById()
        {
            contactRepository.ViewContactDeatailsById();
        }
    }
}
