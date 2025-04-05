using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Interface;
using ContactApp.Repository;

namespace ContactApp.Services
{
    internal class contactDetailsService : IcontactDetailsService
    {
        contactDetailsRepository contactDetailsRepository = new contactDetailsRepository();
        public void AddContactDetails()
        {
           contactDetailsRepository.AddContactDetails();
        }

      

        public void RemoveContactDetails()
        {
            contactDetailsRepository.RemoveContactDetails();
        }

        public void UpdateContactDetails()
        {
            contactDetailsRepository.UpdateContactDetails();
        }

        public void ViewContactDetails()
        {
            contactDetailsRepository.ViewContactDetails();
        }
    }
}
