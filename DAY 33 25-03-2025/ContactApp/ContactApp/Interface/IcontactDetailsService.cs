using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Interface
{
    internal interface IcontactDetailsService
    {
        public void AddContactDetails();

        public void RemoveContactDetails();

        public void UpdateContactDetails();
        public void ViewContactDetails();
    }
}
