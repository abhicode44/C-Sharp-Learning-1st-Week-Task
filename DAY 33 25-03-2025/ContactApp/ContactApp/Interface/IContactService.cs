using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Interface
{
    internal interface IContactService
    {
        public void AddContact(int id);
        public void RemoveContact();
        public void UpdateContact();
        void ViewAllContact();
        public void ViewContactDeatailsById();
        
    }
}
